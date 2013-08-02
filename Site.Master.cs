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
            // set session variables if needed.
            if (MySession.Current.Role == null) MySession.Current.Role = Users.GetUserRole();
            if (MySession.Current.FirstName == null) MySession.Current.FirstName = Users.GetFirstName();
            
            // add a warming welcome message!
            ltWelcomeMessage.Text = "Welcome, " + MySession.Current.FirstName;

            // show menu options if user has the correct permissions
            coordMenu.Visible = Users.IsUserCoordinator();
            reportsMenu.Visible = designersMenu.Visible = adminMenu.Visible = Users.IsUserDesigner();
        }
    }
}