using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNHUWO2
{
    public partial class Notification : System.Web.UI.UserControl
    {
        private Types _type;
        public enum Types
        {
            Attention,
            Success,
            Error,
            Information
        }

        public Types Type
        {
            set { 
                _type = value;
                switch (_type.ToString())
                {
                    case "Attention":
                        pnNotification.CssClass = "notification attention png_bg";
                        break;
                    case "Success":
                        pnNotification.CssClass = "notification success png_bg";
                        break;
                    case "Error":
                        pnNotification.CssClass = "notification error png_bg";
                        break;
                    default:
                        pnNotification.CssClass = "notification information png_bg";
                        break;
                }
            }
        }

        public String Message
        {
            set { ltMessage.Text = value; }
        }

    }
}


            