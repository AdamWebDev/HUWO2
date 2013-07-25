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

        public string Notes
        {
            get { return txtCoordintorNotes.Text; }
        }

        public UploadedFileCollection Files
        {
            get { return uploadFiles.UploadedFiles; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void uploadFiles_FileUploaded(object sender, FileUploadedEventArgs e)
        {           
            if (uploadFiles.UploadedFiles.Count > 0)
            {
                int ID = int.Parse(Request.QueryString["ID"]);
                Classes.WO.UploadFiles(ID, uploadFiles.UploadedFiles,true);
            }
        }

        protected void btnSaveWithChanges_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["ID"]);
            Classes.WO.ApproveWithChanges(ID, txtCoordintorNotes.Text);
            this.Page.GetType().InvokeMember("PopulatePage", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { ID });
        }
    }
}