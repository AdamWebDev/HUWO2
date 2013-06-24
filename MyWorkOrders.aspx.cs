using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2
{
    public partial class MyWorkOrders : System.Web.UI.Page
    {
        Function fn = new Function();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RefreshPage();
                if (Request.QueryString["success"] != null && Request.QueryString["success"].Equals("true"))
                    notSuccess.Visible = true;
            }
        }

        public void RefreshPage()
        {
            IEnumerable<WO.WorkOrderWithDetails> data = WO.GetMyWorkOrders(Function.GetUserName());
            int itemsPerPage = int.Parse(ddItemsPerPage.SelectedValue);
            int skipAmount = int.Parse(hdnCurrentPage.Value) * itemsPerPage;
            var sorteddata = data;
            switch (ddFilters.SelectedValue)
            {
                case "open":
                    data = sorteddata.Where(w => w.status < 6);
                    break;
                case "unapproved":
                    data = sorteddata.Where(w => w.status == 1);
                    break;
                case "completed":
                    data = sorteddata.Where(w => w.status == 6);
                    break;
                case "deleted":
                    data = sorteddata.Where(w => w.status == 7);
                    break;
            }

            int totalCount = sorteddata.Count();
            
            if (totalCount > itemsPerPage)
                sorteddata = data.Skip(skipAmount).Take(itemsPerPage).ToList();
            
            lnkNextPage.Visible = (skipAmount + sorteddata.Count() < totalCount || sorteddata.Count() < itemsPerPage);
            
            rptWorkOrders.DataSource = sorteddata;
            rptWorkOrders.DataBind();
        }

        protected void ddItemsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnCurrentPage.Value = "0";
            RefreshPage();
        }

        protected void ddFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnCurrentPage.Value = "0";
            RefreshPage();
        }

        protected void lnkNextPage_Click(object sender, EventArgs e)
        {
            hdnCurrentPage.Value = (int.Parse(hdnCurrentPage.Value) + 1).ToString();
            RefreshPage();
        }
    }
}