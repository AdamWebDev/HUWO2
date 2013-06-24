using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2.UserControls
{
    public partial class ActivityLog : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["ID"]);
            string output = "<ul class=\"activity-log\">";
            List<LogActivity> logs = HNHUWO2.Classes.WO.GetLog(ID);
            foreach (LogActivity log in logs)
            {
                output+= "<li><span class=\"action\">" + log.action + "</span> by <span class=\"user\">" + Users.GetUsername(log.username) + "</span> on <span class=\"date\">" + log.DateTime.DisplayDate() + "</span></li>";
            }
            output += "</ul>";
            lblLog.Text = output;
        }
    }
}