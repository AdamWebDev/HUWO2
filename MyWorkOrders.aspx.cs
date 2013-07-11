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
                {
                    pnSuccess.Visible = true;
                    int ID;
                    int type;
                    if (Request.QueryString["ID"] != null && int.TryParse(Request.QueryString["ID"], out ID) && Request.QueryString["type"] != null && int.TryParse(Request.QueryString["type"],out type))
                    {
                        lnkWorkOrder.NavigateUrl = "~/View/Default.aspx?ID=" + ID + "&type=" + type;
                    }
                }
            }
        }

        public void RefreshPage()
        {
            IEnumerable<WO.WorkOrderWithDetails> data = WO.GetMyWorkOrders(Function.GetUserName()); // get all of the users's work orders
            int itemsPerPage = int.Parse(ddItemsPerPage.SelectedValue); // get the number of items per page from dropdown
            int skipAmount = int.Parse(hdnCurrentPage.Value) * itemsPerPage; // the starting point for the first record on page 2
            var sorteddata = data;
            switch (ddFilters.SelectedValue) // filter the data based on the dropdown based on status
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

            int totalCount = sorteddata.Count(); // count of total records

            if (totalCount > itemsPerPage) // if more than 1 page, get the first page of records based on which page and items per page
                sorteddata = data.Skip(skipAmount).Take(itemsPerPage).ToList();
            
            // when to show/hide the next/previou buttons
            lnkNextPage.Visible = (skipAmount + sorteddata.Count() < totalCount || sorteddata.Count() < itemsPerPage);
            lnkPrevPage.Visible = int.Parse(hdnCurrentPage.Value) > 0;
            
            // populate!
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

        protected void lnkPrevPage_Click(object sender, EventArgs e)
        {
            hdnCurrentPage.Value = (int.Parse(hdnCurrentPage.Value) - 1).ToString();
            RefreshPage();
        }
    }
}