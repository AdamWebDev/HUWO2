using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNHUWO2
{
    public partial class TrueFalseDropDown : System.Web.UI.UserControl
    {
        public event EventHandler SelectedIndexChanged
        {
            add { dd.SelectedIndexChanged += value; }
            remove { dd.SelectedIndexChanged -= value; }
        }

        public Boolean AutoPostBack
        {
            set
            {
                dd.AutoPostBack = value;
            }
        }
        
        public bool? Value
        {
            get
            {
                if (dd.SelectedValue.Equals("true"))
                    return true;
                else if (dd.SelectedValue.Equals("false"))
                    return false;
                else
                    return null;
            }
            set
            {
                if (value == null)
                    dd.SelectedIndex = 0;
                else if ((bool)value)
                    dd.SelectedValue = "true";
                else
                    dd.SelectedValue = "false";
            }
        }

        public String CssClass
        {
            set {
                dd.CssClass = value;
            }
        }

        public void Clear()
        {
            dd.SelectedIndex = 0;
        }


        public Boolean Enabled
        {
            set
            {
                if (!value)
                    dd.Enabled = false;
                else
                    dd.Enabled = true;
            }
        }
    }
}