using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2.Reports
{
    public partial class ByCoordinator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Users.IsUserDesigner() || Users.IsUserCoordinator())
            {
                //rptReport.DataSource = HNHUWO2.Classes.Reports.ByCoordinator();
                //rptReport.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //rptReport.DataSource = HNHUWO2.Classes.Reports.ByCoordinator(txtStartDate.Text.ConvertToDate(),txtEndDate.Text.ConvertToDate());
        }
    }
}