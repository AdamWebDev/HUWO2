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
            return db.Users.Where(u => u.Active == true && u.Role == 3).ToList();
        }

        public class WorkOrderWithDetails
        {
            public int ID { get; set; }
            public string submitted_by { get; set; }
            public DateTime submitted_date { get; set; }
            public int? ProgramManager { get; set; }
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
                        ProgramManager = w.ProgramManager,
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
            return q.Where(w => w.submitted_by == username).ToList();
        }

        public static List<WorkOrderWithDetails> GetOpenWorkOrders()
        {
            var q = GetWorkOrders();
            return q.Where(w => w.status > 1 && w.status < 6).ToList();
        }

        public static List<WorkOrderWithDetails> GetUnapprovedWorkOrders()
        {
            var q = GetWorkOrders();
            return q.Where(w => w.status < 2).ToList();
        }

        public static List<WorkOrderWithDetails> GetCompletedWorkOrders()
        {
            var q = GetWorkOrders();
            return q.Where(w => w.status == 6).ToList();
        }

        public static List<WorkOrderWithDetails> GetDeletedWorkOrders()
        {
            var q = GetWorkOrders();
            return q.Where(w => w.status == 7).ToList();
        }
        

        public static Workorder GetWorkOrder(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.Workorders.SingleOrDefault(w => w.ID == ID);
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
            return wo.Where(w => w.ProgramManager == ID).ToList();
        }


        public static List<WorkOrderWithDetails> GetMyStaffWorkOrders(String username, int status)
        {
            var q = GetMyStaffWorkOrders(username);
            return q.Where(w => w.status == status).ToList();
        }

        public static List<WorkOrderWithDetails> GetMyStaffWorkOrders(String username, int statusStart, int statusEnd)
        {
            var q = GetMyStaffWorkOrders(username);
            return q.Where(w => w.status >= statusStart && w.status <= statusEnd).ToList();
        }

        public static List<LogActivity> GetLog(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.LogActivities.Where(l => l.wID == ID).ToList();
        }

        public static void UploadFiles(int ID, UploadedFileCollection files)
        {
            UploadFiles(ID, files, false);
        }

        public static void UploadFiles(int ID, UploadedFileCollection files, bool isRevision)
        {
            var destination = HttpContext.Current.Server.MapPath("~/uploads/" + ID + "/");
            if (!System.IO.Directory.Exists(destination))
                System.IO.Directory.CreateDirectory(destination);
            foreach (UploadedFile file in files)
            {
                file.SaveAs(destination + file.FileName, true);
                WO.AddFile(ID, file.FileName, isRevision);
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
            if (!filepath.Equals(String.Empty))
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
                String filepath = HttpContext.Current.Server.MapPath("~/uploads/" + f.wID + "/" + f.Filename);
                db.Files.DeleteOnSubmit(f);
                db.SubmitChanges();
                return filepath;
            }
        }

        public static List<File> GetFiles(int wID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.Files.Where(f => f.wID == wID).ToList();
        }

        public static void SendNewWONotification(int ID) 
        {
            // get work order
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            Workorder wo = db.Workorders.Single(w => w.ID == ID);

            // get ProgramManager's email address
            string email = wo.User.Email;

            // create the email
            string subject = "Work Order Submitted - Requires Approval";
            string message = "Greetings!<br /><br />A workorder has been submitted to the HNHU Communications team that requires your approval. Please proceed to the following link to approve the work order.<br /><br />";
            string linkurl = HttpContext.Current.Request.Url.Host + "/View/Default.aspx?type=" + wo.wotype + "&ID=" + ID;
            message += "<a href='" + linkurl + "'>" + linkurl + "</a><br /><br />";
            message += "Thank you,<br /><br />Your friendly neighbourhood Work Order System";
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
            string subject = "Work Order Approved";
            string message = "Greetings!<br /><br />A workorder that you have submitted has been approved by " + Users.GetUsername() +". Please proceed to the following link to approve the work order.<br /><br />";
            string linkurl = HttpContext.Current.Request.Url.Host + "/View/Default.aspx?type=" + wo.wotype + "&ID=" + ID;
            message += "<a href='" + linkurl + "'>" + linkurl + "</a><br /><br />";
            message += "Thank you,<br /><br />Your friendly neighbourhood Work Order System";
            MailMessage mail = new MailMessage("no-reply@hnhu.org", email, subject, message);
            mail.IsBodyHtml = true;
            SendMail(mail);
        }

        private static void SendMail(MailMessage msg)
        {
            SmtpClient smtp = new SmtpClient();
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