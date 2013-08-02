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
        /// <summary>
        /// Get a list of work order types
        /// </summary>
        /// <returns>List of work order types</returns>
        public static List<WOType> GetWorkOrderTypes()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WOTypes.ToList();
        }

        /// <summary>
        /// Get a list of program managers (previously called coordinators)
        /// </summary>
        /// <returns>List of program managers/coordinators</returns>
        public static List<User> GetCoordinators()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.Users.Where(u => u.Active == true && u.Role == 3).ToList();
        }

        /// <summary>
        /// For displaying in various tables, here are the details we want to see
        /// </summary>
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

        /// <summary>
        /// Get a list of work orders
        /// </summary>
        /// <returns>List of work orders with details</returns>
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

        /// <summary>
        /// Gets work orders submitted by a specific user
        /// </summary>
        /// <param name="username">username of user</param>
        /// <returns>List of work orders</returns>
        public static List<WorkOrderWithDetails> GetMyWorkOrders(String username)
        {
            var q = GetWorkOrders();
            // get wo's related to the logged in user
            return q.Where(w => w.submitted_by == username).ToList();
        }

        /// <summary>
        /// Gets open work orders (open = approved, not completed, not deleted)
        /// </summary>
        /// <returns>List of work orders</returns>
        public static List<WorkOrderWithDetails> GetOpenWorkOrders()
        {
            var q = GetWorkOrders();
            return q.Where(w => w.status > 1 && w.status < 6).ToList();
        }

        /// <summary>
        /// Gets unapproved work orders
        /// </summary>
        /// <returns>List of work orders</returns>
        public static List<WorkOrderWithDetails> GetUnapprovedWorkOrders()
        {
            var q = GetWorkOrders();
            return q.Where(w => w.status < 2).ToList();
        }

        /// <summary>
        /// Gets completed work orders
        /// </summary>
        /// <returns>List of work orders</returns>
        public static List<WorkOrderWithDetails> GetCompletedWorkOrders()
        {
            var q = GetWorkOrders();
            return q.Where(w => w.status == 6).ToList();
        }

        /// <summary>
        /// Gets deleted work orders
        /// </summary>
        /// <returns>List of work orders</returns>
        public static List<WorkOrderWithDetails> GetDeletedWorkOrders()
        {
            var q = GetWorkOrders();
            return q.Where(w => w.status == 7).ToList();
        }
        
        /// <summary>
        /// Gets a specific work order
        /// </summary>
        /// <param name="ID">ID of work order</param>
        /// <returns>Work order</returns>
        public static Workorder GetWorkOrder(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.Workorders.SingleOrDefault(w => w.ID == ID);
        }

        /// <summary>
        /// Get work orders submitted to the current logged in user
        /// </summary>
        /// <returns>List of work orders</returns>
        public static List<WorkOrderWithDetails> GetMyStaffWorkOrders()
        {
            return GetMyStaffWorkOrders(Function.GetUserName());
        }

        /// <summary>
        /// Get unapproved work orders submitted to the logged in user
        /// </summary>
        /// <returns>List of work orders</returns>
        public static List<WorkOrderWithDetails> GetMyStaffUnapprovedWorkOrders()
        {
            return GetMyStaffWorkOrders(Function.GetUserName(), 1);
        }

        /// <summary>
        /// Get approved work orders submitted to the logged in user
        /// </summary>
        /// <returns>List of work orders</returns>
        public static List<WorkOrderWithDetails> GetMyStaffApprovedWorkOrders()
        {
            return GetMyStaffWorkOrders(Function.GetUserName(), 2, 5);
        }

        /// <summary>
        /// Get work orders that are in progress submitted to the logged in user
        /// </summary>
        /// <returns>List of work orders</returns>
        public static List<WorkOrderWithDetails> GetMyStaffInProgressWorkOrders()
        {
            return GetMyStaffWorkOrders(Function.GetUserName(), 3, 5);
        }

        /// <summary>
        /// Get completed work orders submitted to the logged in user
        /// </summary>
        /// <returns>List of work orders</returns>
        public static List<WorkOrderWithDetails> GetMyStaffCompletedWorkOrders()
        {
            return GetMyStaffWorkOrders(Function.GetUserName(), 6);
        }

        /// <summary>
        /// Get deleted work orders submitted to the logged in user
        /// </summary>
        /// <returns>List of work orders</returns>
        public static List<WorkOrderWithDetails> GetMyStaffDeletedWorkOrders()
        {
            return GetMyStaffWorkOrders(Function.GetUserName(), 7);
        }

        /// <summary>
        /// Get work orders submitted to a specific user
        /// </summary>
        /// <param name="username">username of specific user</param>
        /// <returns>List of work orders</returns>
        public static List<WorkOrderWithDetails> GetMyStaffWorkOrders(String username)
        {
            int? ID = HNHUWO2.Classes.Users.GetUserID(username);
            var wo = GetWorkOrders();
            return wo.Where(w => w.ProgramManager == ID).ToList();
        }

        /// <summary>
        /// Get work orders with a specifc status submitted to a specific user
        /// </summary>
        /// <param name="username">Username of user</param>
        /// <param name="status">Status of work order</param>
        /// <returns>List of work orders</returns>
        public static List<WorkOrderWithDetails> GetMyStaffWorkOrders(String username, int status)
        {
            var q = GetMyStaffWorkOrders(username);
            return q.Where(w => w.status == status).ToList();
        }

        /// <summary>
        /// Get work orders with a status range submitted to a specific user
        /// </summary>
        /// <param name="username">Username of user</param>
        /// <param name="statusStart">Start of status range</param>
        /// <param name="statusEnd">End of status range</param>
        /// <returns>List of work orders</returns>
        public static List<WorkOrderWithDetails> GetMyStaffWorkOrders(String username, int statusStart, int statusEnd)
        {
            var q = GetMyStaffWorkOrders(username);
            return q.Where(w => w.status >= statusStart && w.status <= statusEnd).ToList();
        }

        /// <summary>
        /// Get activity log related to a specific work order
        /// </summary>
        /// <param name="ID">ID of work order</param>
        /// <returns>List of activities</returns>
        public static List<LogActivity> GetLog(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.LogActivities.Where(l => l.wID == ID).ToList();
        }

        /// <summary>
        /// Uploads files
        /// </summary>
        /// <param name="ID">ID of related work order</param>
        /// <param name="files">Files uploaded in work order</param>
        public static void UploadFiles(int ID, UploadedFileCollection files)
        {
            UploadFiles(ID, files, false);
        }

        /// <summary>
        /// Uploads files
        /// </summary>
        /// <param name="ID">ID of related work order</param>
        /// <param name="files">Files upload in work order</param>
        /// <param name="isRevision">Whether or not this is a revised file from the program manager</param>
        public static void UploadFiles(int ID, UploadedFileCollection files, bool isRevision)
        {
            // files are uploaded to a uploaded directory in subfolders of the ID number
            var destination = HttpContext.Current.Server.MapPath("~/uploads/" + ID + "/");
            if (!System.IO.Directory.Exists(destination))
                System.IO.Directory.CreateDirectory(destination);
            // let's file the files accordingly, then add an entry to the files table in the db
            foreach (UploadedFile file in files)
            {
                file.SaveAs(destination + file.FileName, true);
                WO.AddFile(ID, file.FileName, isRevision);
            }
        }

        /// <summary>
        /// Adds file information to the database
        /// </summary>
        /// <param name="wID">Work order ID</param>
        /// <param name="filename">Name of the file</param>
        /// <param name="IsRevision">Whether this was uploaded by a program manager</param>
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
        
        /// <summary>
        /// Delete a file (deletes the file AND removes it from the db)
        /// </summary>
        /// <param name="ID">ID of the file</param>
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

        /// <summary>
        /// Removes a file entry from the db
        /// </summary>
        /// <param name="ID">File ID</param>
        /// <returns>Filepath (used by DeleteFile())</returns>
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

        /// <summary>
        /// Gets files associated with a work order
        /// </summary>
        /// <param name="wID">Work order ID</param>
        /// <returns>List of files</returns>
        public static List<File> GetFiles(int wID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.Files.Where(f => f.wID == wID).ToList();
        }

        /// <summary>
        /// Sends email notificaitons when a new work order is created
        /// </summary>
        /// <param name="ID">Work order ID</param>
        public static void SendNewWONotification(int ID) 
        {
            // get work order
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            Workorder wo = db.Workorders.Single(w => w.ID == ID);

            // get program manager's email address
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

        /// <summary>
        /// Send email notifications when a work order is approved
        /// </summary>
        /// <param name="ID">Work order ID</param>
        private static void SendApprovedNotification(int ID)
        {
            // get the work order in question
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            Workorder wo = db.Workorders.Single(w => w.ID == ID);

            // get user's email address
            string email = Users.GetUserEmail(wo.submitted_by);

            // create the emails
            // one to the creator, one to the designers
            string subject = "Work Order Approved";
            string opening = "Greetings!<br /><br />A workorder that you have submitted has been approved by " + Users.GetUsername() +". Please proceed to the following link to approve the work order.<br /><br />";
            string linkurl = HttpContext.Current.Request.Url.Host + "/View/Default.aspx?type=" + wo.wotype + "&ID=" + ID;
            string message = "<a href='" + linkurl + "'>" + linkurl + "</a><br /><br />";
            message += "Thank you,<br /><br />Your friendly neighbourhood Work Order System";
            MailMessage mail = new MailMessage("no-reply@hnhu.org", email, subject, opening + message);
            mail.IsBodyHtml = true;
            SendMail(mail);

            opening = "Greetings!<br /><br />A workorder has been approved and is ready for you to do your magic! Follow this link to check out the details.<br /><br />";
            mail = new MailMessage("no-reply@hnhu.org", "communications@hnhu.org", subject, opening + message);
            mail.IsBodyHtml = true;
            SendMail(mail);
        }

        /// <summary>
        /// Send that email!
        /// </summary>
        /// <param name="msg">Email message</param>
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
        /// Unapprove a work order
        /// </summary>
        /// <param name="ID">Work order ID</param>
        public static void Unapprove(int ID)
        {
            UpdateStatus(ID, 1);
        }

        /// <summary>
        /// Approve a work order
        /// </summary>
        /// <param name="ID">Work order ID</param>
        public static void Approve(int ID) {
            SendApprovedNotification(ID);
            UpdateStatus(ID, 2);
            
        }

        /// <summary>
        /// Approve a work order (with changes by the program manager)
        /// </summary>
        /// <param name="ID">Work order ID</param>
        /// <param name="notes">Additional notes</param>
        public static void ApproveWithChanges(int ID, string notes)
        {
            UpdateStatus(ID, 3, notes);
        }

        /// <summary>
        /// Set a work order to be "In Progress"
        /// </summary>
        /// <param name="ID">Work order ID</param>
        public static void MarkInProgress(int ID)
        {
            UpdateStatus(ID, 4);
        }

        /// <summary>
        /// Set a work order to "Mark Proof Sent"
        /// </summary>
        /// <param name="ID">Work order ID</param>
        public static void MarkProofSent(int ID)
        {
            UpdateStatus(ID, 5);
        }

        /// <summary>
        /// Set a work order to be complete
        /// </summary>
        /// <param name="ID">Work order ID</param>
        public static void MarkComplete(int ID)
        {
            UpdateStatus(ID, 6);
        }

        /// <summary>
        /// Delete a work order
        /// </summary>
        /// <param name="ID">Work order ID</param>
        public static void Delete(int ID)
        {
            /// this doesn't actually delete the work order from the system - it just flags it appropriately
            UpdateStatus(ID, 7);
        }

        /// <summary>
        /// Sets the status of a work order accordingly
        /// </summary>
        /// <param name="ID">Work order ID</param>
        /// <param name="newStatus">New status ID</param>
        private static void UpdateStatus(int ID, int newStatus)
        {
            UpdateStatus(ID, newStatus, String.Empty);
        }

        /// <summary>
        /// Sets the status of a work order accordingly
        /// </summary>
        /// <param name="ID">Work order ID</param>
        /// <param name="newStatus">New status ID</param>
        /// <param name="notes">Program coordinator notes</param>
        private static void UpdateStatus(int ID, int newStatus, string notes)
        {
            using  (WOLinqClassesDataContext db = new WOLinqClassesDataContext())
            {
                Workorder wo = db.Workorders.Single(w => w.ID == ID);
                wo.status = newStatus;
                wo.coordinatorNotes = notes;
                
                // we want to add this to the activity log as well
                LogActivity log = new LogActivity();
                log.action = "Marked '" + wo.Status1.status + "'";
                log.DateTime = DateTime.Now;
                log.username = Function.GetUserName();
                log.wID = wo.ID;
                db.LogActivities.InsertOnSubmit(log);
                db.SubmitChanges();
                
            }
        }

        /// <summary>
        /// Adds an action to the activity log
        /// </summary>
        /// <param name="wID">Work order ID</param>
        /// <param name="action">Text that will be added to the activity log</param>
        public static void LogAction(int wID, string action)
        {
            using (WOLinqClassesDataContext db = new WOLinqClassesDataContext())
            {
                LogActivity l = new LogActivity();
                l.DateTime = DateTime.Now;
                l.wID = wID;
                l.username = Function.GetUserName();
                l.action = action;
                db.LogActivities.InsertOnSubmit(l);
                db.SubmitChanges();
            }
        }

        /// <summary>
        /// Is the work order approved?
        /// </summary>
        /// <param name="ID">Work order ID</param>
        /// <returns>True/false</returns>
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