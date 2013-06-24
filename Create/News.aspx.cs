using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2.Create
{
    public partial class News : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // populate Coordinators Drop Down
                ddCoordinators.Items.Insert(0, new ListItem("--Select--", String.Empty));
                ddCoordinators.DataSource = WO.GetCoordinators();
                ddCoordinators.DataValueField = "ID";
                ddCoordinators.DataTextField = "FullName";
                ddCoordinators.DataBind();

                // populate distro outlets
                ddDistributionOutlets.Items.Insert(0, new ListItem("--Select--", String.Empty));
                ddDistributionOutlets.DataSource = NewsWO.GetDistroOutlets();
                ddDistributionOutlets.DataValueField = "ID";
                ddDistributionOutlets.DataTextField = "Value";
                ddDistributionOutlets.DataBind();

            }
        }

        protected void ddDistributionOutlets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddDistributionOutlets.SelectedItem.Text.Equals("Other"))
                Function.ShowControls(phDistroOther);
            else
                Function.ClearControls(phDistroOther, false);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int ID = 0;
            using (WOLinqClassesDataContext db = new WOLinqClassesDataContext())
            {
                Workorder w = new Workorder();
                w.submitted_date = DateTime.Now;
                w.submitted_by = Function.GetUserName();
                w.wotype = 4;
                w.duedate = Function.FormatDate(txtDateToIssue.Text);
                w.coordinator = int.Parse(ddCoordinators.SelectedValue);
                w.title = txtTitleTopic.Text;
                w.status = 1;
                db.Workorders.InsertOnSubmit(w);
                WorkOrdersNews n = new WorkOrdersNews();
                n.Workorder = w;
                n.DistributionOutlets = int.Parse(ddDistributionOutlets.SelectedValue);
                n.DistributionDetails = txtDistributionOutletsOther.Text;
                n.Contact = txtContact.Text;
                n.AdditionalNotes = txtNotes.Text;
                db.WorkOrdersNews.InsertOnSubmit(n);
                db.SubmitChanges();
                ID = w.ID;
            }
            Function.LogAction(ID, "Work order created");
            Response.Redirect("~/MyWorkOrders.aspx?success=true");
        }
    }
}