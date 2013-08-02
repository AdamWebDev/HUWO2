using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace HNHUWO2.UserControls
{
    public partial class CoordinatorRevisions : System.Web.UI.UserControl
    {
        /// <summary>
        /// A user control that takes adds supplementary information by program managers to work orders
        /// </summary>
        
        // program managers notes
        public string Notes
        {
            get { return txtCoordintorNotes.Text; }
        }

        // attached files
        public UploadedFileCollection Files
        {
            get { return uploadFiles.UploadedFiles; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Once the postback completes, then files are uploaded
        /// </summary>
        protected void uploadFiles_FileUploaded(object sender, FileUploadedEventArgs e)
        {           
            if (uploadFiles.UploadedFiles.Count > 0)
            {
                int ID = int.Parse(Request.QueryString["ID"]);
                Classes.WO.UploadFiles(ID, uploadFiles.UploadedFiles,true);
            }
        }

        /// <summary>
        /// In order to have the buttons updated the content in the parent page, we use this fancy workaround to fire a method from this user control
        /// From: http://www.aspsnippets.com/Articles/Calling-Parent-Page-method-from-Child-Usercontrol-using-Reflection-in-ASP.Net.aspx
        /// </summary>
        protected void btnSaveWithChanges_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["ID"]);
            //change the status with notse
            Classes.WO.ApproveWithChanges(ID, txtCoordintorNotes.Text);
            
            // In order to get the page to refresh, we have to call this function (which is on all of the calling pages)
            // manually, as this fires AFTER the inital page population.
            this.Page.GetType().InvokeMember("PopulatePage", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { ID });
        }
    }
}