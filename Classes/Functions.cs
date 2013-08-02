using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Data;
using Telerik.Web.UI;

namespace HNHUWO2.Classes
{
    /// <summary>
    /// This is a group of general functions used throughout the application
    /// </summary>
    public class Function
    {
        /// <summary>
        /// Used for showing/hiding form sections. Has the option to both clear and hide the fields. Also turns off validation as required.
        /// </summary>
        /// <param name="o">Any type of control</param>
        /// <param name="visible">Whether the control should be visible or not</param>
        public static void ClearControls(Control o, bool visible = true)
        {
            // if it's a placeholder, there's nothing to clear. let's just hide it if needed
            if (o is PlaceHolder)
            {
                o.Visible = visible;
            }

            // let's loop through all controls within the original control and clear them.
            // different controls have different clearing methods, hence the breakdown.
            foreach (Control c in o.Controls)
            {
                if (c is TextBox)
                {
                    TextBox d = (TextBox)c;
                    d.Text = String.Empty;
                }
                else if (c is DropDownList)
                {
                    DropDownList d = (DropDownList)c;
                    d.SelectedIndex = 0;
                }
                else if (c is CheckBoxList)
                {
                    CheckBoxList d = (CheckBoxList)c;
                    foreach (ListItem f in d.Items)
                    {
                        f.Selected = false;
                    }
                }
                else if (c is TrueFalseDropDown)
                {
                    TrueFalseDropDown d = (TrueFalseDropDown)c;
                    d.Clear();
                }
                else if (c is RequiredFieldValidator)
                {
                    RequiredFieldValidator d = (RequiredFieldValidator)c;
                    d.Enabled = visible;
                }
                else if (c is CompareValidator)
                {
                    CompareValidator d = (CompareValidator)c;
                    d.Enabled = visible;
                }
                else if (c is CustomValidator)
                {
                    CustomValidator d = (CustomValidator)c;
                    d.Enabled = visible;   
                }
                // if there's a placeholder within a placeholder, let's do it again
                // (inception?)
                else if (c is PlaceHolder)
                {
                    ClearControls(c, visible);
                }
                
            }
        }

        /// <summary>
        /// Show controls!
        /// </summary>
        /// <param name="o">The control to toggle visibility. Also turns on validation of those elements</param>
        /// <param name="ShowChildPlaceholders">An option to show placeholders within the original control (o)</param>
        public static void ShowControls(Control o, bool ShowChildPlaceholders)
        {
            // show that placeholder!
            if (o is PlaceHolder)
            {
                o.Visible = true;
            }
            // loop through all of the controls within and make sure they're visible and enabled
            foreach (Control c in o.Controls)
            {
                if (c is PlaceHolder && ShowChildPlaceholders)
                {
                    PlaceHolder d = (PlaceHolder)c;
                    d.Visible = true;
                }
                else if (c is RequiredFieldValidator)
                {
                    RequiredFieldValidator d = (RequiredFieldValidator)c;
                    d.Enabled = true;
                }
                else if (c is CompareValidator)
                {
                    CompareValidator d = (CompareValidator)c;
                    d.Enabled = true;
                }
                else if (c is CustomValidator)
                {
                    CustomValidator d = (CustomValidator)c;
                    d.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Show controls, but keep any child placeholders hidden
        /// </summary>
        /// <param name="o">Control to hide</param>
        public static void ShowControls(Control o)
        {
            ShowControls(o, false);
        }

        /// <summary>
        /// Gets the username of the current user
        /// </summary>
        /// <returns>username</returns>
        public static string GetUserName()
        {
            // we're just grabbing the user's name and stripping the domain name from it.
            String username = HttpContext.Current.User.Identity.Name.ToString();
            username = username.Replace("NORFOLK\\", "");
            return username;
        }

        /// <summary>
        /// A quick method of getting all of hte values form a checkbox list and combining them into a string
        /// </summary>
        /// <param name="chk">The checkbox list control</param>
        /// <returns>String of comma separated values</returns>
        public static String GetChecklistItems(CheckBoxList chk)
        {
            String value = String.Empty;
            foreach (ListItem item in chk.Items)
            {
                if (item.Selected)
                {
                    value = value + item.Value + ",";
                }
            }
            return value;
        }

    }
}