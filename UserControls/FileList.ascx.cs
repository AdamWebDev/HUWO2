using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2.UserControls
{
    /// <summary>
    /// Displays a list of all of the files associated with a work order
    /// </summary>
    public partial class FileList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateFileList();
            // hide the repeater if the table is empty
            if (rptFiles.Items.Count == 0)
            {
                rptFiles.Visible = false;
            }
        }

        /// <summary>
        /// Populate the file list
        /// </summary>
        public void UpdateFileList()
        {
            UpdateFileList(int.Parse(Request.QueryString["ID"]));
        }

        /// <summary>
        /// Populate the file list
        /// </summary>
        /// <param name="ID">Work order ID</param>
        public void UpdateFileList(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            rptFiles.DataSource = db.Files.Where(f => f.wID == ID).ToList();
            rptFiles.DataBind();
        }

        /// <summary>
        /// Delete the file
        /// </summary>
        protected void lnkDelete_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "DeleteFile")
            {
                int ID = int.Parse(e.CommandArgument.ToString());
                WO.DeleteFile(ID);
                UpdateFileList();
            }
        }

        /// <summary>
        /// Show delete button when necessary
        /// </summary>
        protected void rptFiles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
            int ID = int.Parse(Request.QueryString["ID"]);
            // only show button if WO is not approved and user is a ProgramManager
            bool showDeleteButton = HNHUWO2.Classes.Users.IsUserCoordinator() && !WO.IsApproved(ID);
            RepeaterItem item = e.Item;

            if ((item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem))
            {
                if (showDeleteButton)
                {
                    LinkButton lnk = item.FindControl("lnkDelete") as LinkButton;
                    if (lnk != null) lnk.Visible = true;
                }
            }
        }
    }
}