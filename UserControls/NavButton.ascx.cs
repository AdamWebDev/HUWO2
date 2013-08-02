using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNHUWO2
{
    public partial class NavButton : System.Web.UI.UserControl
    {

        public String NavURL
        {
            set { lnkLink.NavigateUrl = value; }
        }

        public String Text
        {
            set { ltText.Text = value; }
        }

        public String Icon
        {
            set
            {
                icon.Attributes.Add("class", value + " icon-4x" );
            }
        }

        
        public event EventHandler Click;

        /// <summary>
        /// Allows click events to happen
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnClick(EventArgs e)
        {
            if (Click != null)
                Click(this, e);
        }

        /// <summary>
        /// This allows the postbacks from user controls within user controls... inception?
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            string arg = "@@@@" + lnkLink.ClientID;
            lnkLink.Attributes.Add("OnClick", Page.ClientScript.GetPostBackEventReference(lnkLink, arg));
            if (IsPostBack)
            {
                string eventArg = Request["__EVENTARGUMENT"];
                if (!string.IsNullOrEmpty(eventArg) && eventArg.StartsWith("@@@@"))
                {
                    if (eventArg == arg)
                        OnClick(EventArgs.Empty);
                }
            }
        }
    }

   
}