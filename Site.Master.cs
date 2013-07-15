using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Function.GetUserName();
            if (Session["firstname"] == null)
                Session["firstname"] = Users.GetFirstName(username);

            ltWelcomeMessage.Text = "Welcome, " + Session["firstname"];

            if (Session["role"] == null)
                Session["role"] = Users.GetUserRole(username);

            coordMenu.Visible = Users.IsUserCoordinator();
            var isDesigner = Users.IsUserDesigner();
            reportsMenu.Visible = isDesigner;
            designersMenu.Visible = isDesigner;
            adminMenu.Visible = isDesigner;
        }
    }
}