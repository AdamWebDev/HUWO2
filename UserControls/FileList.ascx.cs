using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2.UserControls
{
    public partial class FileList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateFileList();
            if (rptFiles.Items.Count == 0)
            {
                rptFiles.Visible = false;
            }
        }

        public void UpdateFileList()
        {
            UpdateFileList(int.Parse(Request.QueryString["ID"]));
        }

        public void UpdateFileList(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            rptFiles.DataSource = db.Files.Where(f => f.wID == ID).ToList();
            rptFiles.DataBind();
        }

        protected void lnkDelete_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "DeleteFile")
            {
                int ID = int.Parse(e.CommandArgument.ToString());
                WO.DeleteFile(ID);
                UpdateFileList();
            }
        }

        protected void rptFiles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
            int ID = int.Parse(Request.QueryString["ID"]);
            bool showDeleteButton = HNHUWO2.Classes.Users.IsUserCoordinator() && !WO.IsApproved(ID); // only show button if WO is not approved and user is a ProgramManager
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