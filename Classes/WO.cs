using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using Telerik.Web.UI;

namespace HNHUWO2.Classes
{
    public class WO
    {
        public static List<WOType> GetWorkOrderTypes()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WOTypes.ToList();
        }

        public static List<User> GetCoordinators()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            var query = from u in db.Users
                        where (u.Active == true) && (u.Role == 4)
                        select u;
            return query.ToList();
        }

        public class WorkOrderWithDetails
        {
            public int ID { get; set; }
            public string submitted_by { get; set; }
            public DateTime submitted_date { get; set; }
            public int? coordinator { get; set; }
            public string coordinatorName { get; set; }
            public DateTime? duedate { get; set; }
            public int wotype { get; set; }
            public string wotypeText { get; set; }
            public string title { get; set; }
            public int status { get; set; }
            public string statusText { get; set; }

        }

        public static List<WorkOrderWithDetails> GetWorkOrders()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            var q = from w in db.Workorders
                    select new WorkOrderWithDetails
                    { 
                        ID = w.ID,
                        submitted_by = w.submitted_by,
                        submitted_date = w.submitted_date,
                        coordinator = w.coordinator,
                        coordinatorName = w.User.FullName,
                        duedate = w.duedate,
                        wotype = w.wotype,
                        wotypeText = w.WOType1.type,
                        title = w.title,
                        status = w.status,
                        statusText = w.Status1.status
                    };
            return q.ToList();
        }

        public static List<WorkOrderWithDetails> GetMyWorkOrders(String username)
        {
            var q = GetWorkOrders();
            // get wo's related to the logged in user
            var z = from w in q
                    where w.submitted_by == username
                    select w;
            return z.ToList();
            
        }

        public static List<WorkOrderWithDetails> GetOpenWorkOrders()
        {
            var q = GetWorkOrders();
            var z = from w in q
                    where w.status > 1 && w.status < 6
                    select w;
            return z.ToList();
        }

        public static List<WorkOrderWithDetails> GetUnapprovedWorkOrders()
        {
            var q = GetWorkOrders();
            var z = from w in q
                    where w.status < 2
                    select w;
            return z.ToList();
        }

        public static List<WorkOrderWithDetails> GetCompletedWorkOrders()
        {
            var q = GetWorkOrders();
            var z = from w in q
                    where w.status == 6
                    select w;
            return z.ToList();
        }

        public static List<WorkOrderWithDetails> GetDeletedWorkOrders()
        {
            var q = GetWorkOrders();
            var z = from w in q
                    where w.status == 7
                    select w;
            return z.ToList();
        }
        

        public static Workorder GetWorkOrder(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            var q = (from w in db.Workorders
                     where w.ID == ID
                     select w).FirstOrDefault();
            return q;
        }

        public static List<WorkOrderWithDetails> GetMyStaffWorkOrders()
        {
            return GetMyStaffWorkOrders(Function.GetUserName());
        }

        public static List<WorkOrderWithDetails> GetMyStaffUnapprovedWorkOrders()
        {
            return GetMyStaffWorkOrders(Function.GetUserName(), 1);
        }

        public static List<WorkOrderWithDetails> GetMyStaffApprovedWorkOrders()
        {
            return GetMyStaffWorkOrders(Function.GetUserName(), 2, 5);
        }

        public static List<WorkOrderWithDetails> GetMyStaffInProgressWorkOrders()
        {
            return GetMyStaffWorkOrders(Function.GetUserName(), 3, 5);
        }

        public static List<WorkOrderWithDetails> GetMyStaffCompletedWorkOrders()
        {
            return GetMyStaffWorkOrders(Function.GetUserName(), 6);
        }

        public static List<WorkOrderWithDetails> GetMyStaffDeletedWorkOrders()
        {
            return GetMyStaffWorkOrders(Function.GetUserName(), 7);
        }

        public static List<WorkOrderWithDetails> GetMyStaffWorkOrders(String username)
        {
            int? ID = HNHUWO2.Classes.Users.GetUserID(username);
            var wo = GetWorkOrders();
            var q = from w in wo
                    where w.coordinator == ID
                    select w;
            return q.ToList();
        }


        public static List<WorkOrderWithDetails> GetMyStaffWorkOrders(String username, int status)
        {
            var q = GetMyStaffWorkOrders(username);
            var z = from wo in q
                    where wo.status == status
                    select wo;
            return z.ToList();
        }

        public static List<WorkOrderWithDetails> GetMyStaffWorkOrders(String username, int statusStart, int statusEnd)
        {
            var q = GetMyStaffWorkOrders(username);
            var z = from wo in q
                    where wo.status >= statusStart && wo.status <= statusEnd
                    select wo;
            return z.ToList();
        }

        public static List<LogActivity> GetLog(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            var q = from l in db.LogActivities
                    where l.wID == ID
                    select l;
            return q.ToList();
        }

        public static void UploadFiles(int ID, UploadedFileCollection Files)
        {
            UploadFiles(ID, Files, false);
        }

        public static void UploadFiles(int ID, UploadedFileCollection Files,bool IsRevision)
        {
            if (Files.Count > 0)
            {
                System.IO.Directory.CreateDirectory("~/uploads/" + ID);
            }
            foreach (UploadedFile file in Files)
            {
                string src = "~/uploads/" + file.FileName;
                string dest = "~/uploads/" + ID + "/" + file.FileName;
                System.IO.File.Move(src, dest);
                WO.AddFile(ID, file.FileName,IsRevision);
            }
        }

        private static void AddFile(int wID, string filename, bool IsRevision)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            File f = new File();
            f.wID = wID;
            f.Filename = filename;
            f.Revision = IsRevision;
            db.Files.InsertOnSubmit(f);
            db.SubmitChanges();
        }

        public static void DeleteFile(int ID)
        {
            /// deletes a file with the corresponding ID

            // find file in DB and remove it
            string filepath = RemoveFile(ID);

            // if file exists...
            if (filepath.Equals(String.Empty))
            {
                // delete the physical file
                System.IO.File.Delete(filepath);
            }
        }

        private static string RemoveFile(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            File f = db.Files.Single(fi => fi.ID == ID);
            if (f == null)
                return String.Empty;
            else
            {
                String filepath = f.Filename;
                db.Files.DeleteOnSubmit(f);
                db.SubmitChanges();
                return filepath;
            }
        }

        public static List<File> GetFiles(int wID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            var q = from f in db.Files
                    where f.wID == wID
                    select f;
            return q.ToList();
        }

        public static void SendNewWONotification(int ID) 
        {
            // get work order
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            Workorder wo = db.Workorders.Single(w => w.ID == ID);

            // get coordinator's email address
            string email = wo.User.Email;

            // create the email
            string subject = "Workorder Submitted - Requires Approval";
            string message = "Greetings!<br /><br />A workorder has been submitted to the HNHU Communications team that requires your approval. Please proceed to the following link to approve the work order.<br /><br />";
            string linkurl = HttpContext.Current.Request.Url.Host + "/View/Default.aspx?ID=" + ID;
            message += "<a href='" + linkurl + "'>" + linkurl + "</a><br /><br />";
            message += "Thank you,<br /><br />Your friendly neighbourhood Word Order System";
            MailMessage mail = new MailMessage("no-reply@hnhu.org", email, subject, message);
            mail.IsBodyHtml = true;
            SendMail(mail);
        }

        private static void SendApprovedNotification(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            Workorder wo = db.Workorders.Single(w => w.ID == ID);

            // get user's email address
            string email = Users.GetUserEmail(wo.submitted_by);

            // create the email
            string subject = "Workorder Approved";
            string message = "Greetings!<br /><br />A workorder that you have submitted has been approved by " + Users.GetUsername() +". Please proceed to the following link to approve the work order.<br /><br />";
            string linkurl = HttpContext.Current.Request.Url.Host + "/View/Default.aspx?ID=" + ID;
            message += "<a href='" + linkurl + "'>" + linkurl + "</a><br /><br />";
            message += "Thank you,<br /><br />Your friendly neighbourhood Word Order System";
            MailMessage mail = new MailMessage("no-reply@hnhu.org", email, subject, message);
            mail.IsBodyHtml = true;
            SendMail(mail);
        }

        private static void SendMail(MailMessage msg)
        {
            SmtpClient smtp = new SmtpClient("localhost");
            try
            {
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        /// <summary>
        /// Functions related to changing the status of work orders
        /// </summary>

        public static void Unapprove(int ID)
        {
            UpdateStatus(ID, 1);
        }

        public static void Approve(int ID) {
            SendApprovedNotification(ID);
            UpdateStatus(ID, 2);
            
        }

        public static void ApproveWithChanges(int ID, string notes)
        {
            UpdateStatus(ID, 3, notes);
        }

        public static void MarkInProgress(int ID)
        {
            UpdateStatus(ID, 4);
        }

        public static void MarkProofSent(int ID)
        {
            UpdateStatus(ID, 5);
        }

        public static void MarkComplete(int ID)
        {
            UpdateStatus(ID, 6);
        }

        public static void Delete(int ID)
        {
            UpdateStatus(ID, 7);
        }

        private static void UpdateStatus(int ID, int newStatus)
        {
            UpdateStatus(ID, newStatus, String.Empty);
        }

        private static void UpdateStatus(int ID, int newStatus, string notes)
        {
            using  (WOLinqClassesDataContext db = new WOLinqClassesDataContext())
            {
                Workorder wo = db.Workorders.Single(w => w.ID == ID);
                wo.status = newStatus;
                wo.coordinatorNotes = notes;
                LogActivity log = new LogActivity();
                log.action = "Marked '" + wo.Status1.status + "'";
                log.DateTime = DateTime.Now;
                log.username = Function.GetUserName();
                log.wID = wo.ID;
                db.LogActivities.InsertOnSubmit(log);
                db.SubmitChanges();
                string url = "~/View/Default.aspx?type=" + wo.wotype + "&ID=" + wo.ID + "&status=" + newStatus;
                HttpContext.Current.Response.Redirect(url);
            }
        }

        public static bool IsApproved(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            Workorder wo = db.Workorders.Single(w => w.ID == ID);
            if (wo != null)
            {
                if (wo.status > 1 && wo.status < 7)
                    return true;
                else
                    return false;
            }
            else return false;
        }
    }
}