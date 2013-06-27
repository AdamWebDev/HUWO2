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
            txtCoordintorNotes.Text = "THIS FIRED!";
            
            if (uploadFiles.UploadedFiles.Count > 0)
            {
                var destination = HttpContext.Current.Server.MapPath("~/uploads/" + Request.QueryString["ID"]  + "/");
                if (!System.IO.Directory.Exists(destination))
                  System.IO.Directory.CreateDirectory(destination);
                foreach (UploadedFile file in Files)
                {
                    file.SaveAs(destination + file.FileName);
                }
            }
        }
    }
}