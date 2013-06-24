using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNHUWO2.UserControls
{
    public partial class StatusMessages : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String msgID = Request.QueryString["status"];

            switch (msgID)
            {
                case "1":
                    notMsg.Type = Notification.Types.Success;
                    notMsg.Message = "You have unapproved this work order!";
                    break;
                case "2":
                case "3":
                    notMsg.Type = Notification.Types.Success;
                    notMsg.Message = "You have approved this work order! Woohoo!";
                    break;
                case "4":
                    notMsg.Type = Notification.Types.Success;
                    notMsg.Message = "This work order is now in progress! Go get 'em!";
                    break;
                case "5":
                    notMsg.Type = Notification.Types.Success;
                    notMsg.Message = "Proof sent! Let's hope for a quick turnaround!";
                    break;
                case "6":
                    notMsg.Type = Notification.Types.Success;
                    notMsg.Message = "Work order complete? Awesome!";
                    break;
                case "7":
                    notMsg.Type = Notification.Types.Success;
                    notMsg.Message = "Deleted? I'm sure you had your reasons... :)";
                    break;
                default:
                    notMsg.Visible = false;
                    break;
            }
        }
    }
}