using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNHUWO2.View
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "";
            string msg = "";
            if (Request.QueryString["ID"] == null || Request.QueryString["type"] == null)
            {
                url = "~/Default.aspx";
            }
            else
            {
                if (Request.QueryString["status"] != null)
                {
                    msg = Request.QueryString["status"];
                }

                switch (int.Parse(Request.QueryString["type"]))
                {
                    case 1:
                        url = "~/View/Print.aspx?ID=" + Request.QueryString["ID"];
                        break;
                    case 2:
                        url = "~/View/Web.aspx?ID=" + Request.QueryString["ID"];
                        break;
                    case 3:
                        url = "~/View/Radio.aspx?ID=" + Request.QueryString["ID"];
                        break;
                    case 4:
                        url = "~/View/News.aspx?ID=" + Request.QueryString["ID"];
                        break;
                    case 5:
                        url = "~/View/Print.aspx?ID=" + Request.QueryString["ID"];
                        break;
                    case 6:
                        url = "~/View/Video.aspx?ID=" + Request.QueryString["ID"];
                        break;
                    default:
                        url = "~/MyWorkOrders.aspx";
                        break;
                }
            }
            if (!msg.Equals(String.Empty))
                url += "&status=" + msg;
            Response.Redirect(url);
        }
    }
}