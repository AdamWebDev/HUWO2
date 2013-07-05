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
    public class Function
    {
        public static void ClearControls(Control o, bool visible = true)
        {
            if (o is PlaceHolder)
            {
                o.Visible = visible;
            }
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
                else if (c is PlaceHolder)
                {
                    ClearControls(c, visible);
                }
                
            }
        }

        public static void ShowControls(Control o)
        {
            if (o is PlaceHolder)
            {
                o.Visible = true;
            }
            foreach (Control c in o.Controls)
            {
                if (c is PlaceHolder)
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

        public static void DisableControls(Control parent)
        {
            bool hide = false;
            DisableControls(parent, hide);
        }

        public static void DisableControls(Control parent, Boolean hide)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                {
                    TextBox d = (TextBox)c;
                    d.Enabled = false;
                    d.CssClass += " disabled";
                    if (hide) d.Visible = false;

                }
                else if (c is DropDownList)
                {
                    DropDownList d = (DropDownList)c;
                    d.Enabled = false;
                    d.CssClass += " disabled";
                    if (hide) d.Visible = false;
                }
                else if (c is CheckBoxList)
                {
                    CheckBoxList d = (CheckBoxList)c;
                    foreach (ListItem f in d.Items)
                    {
                        f.Enabled = false;
                    }
                    d.CssClass += " disabled";
                    if (hide) d.Visible = false;
                }
                else if (c is TrueFalseDropDown)
                {
                    TrueFalseDropDown d = (TrueFalseDropDown)c;
                    d.Enabled = false;
                    if (hide) d.Visible = false;
                }
                else if (c is RadUpload)
                {
                    RadUpload d = (RadUpload)c;
                    d.Enabled = false;
                    d.CssClass += " disabled";
                    if (hide) d.Visible = false;
                }
                DisableControls(c,hide);
            }
        }

        public void ScrollToTop(Page Page)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "ScrollPage", "ResetScrollPosition();", true);
        }

        public static string GetUserName()
        {
            String username = HttpContext.Current.User.Identity.Name.ToString();
            username = username.Replace("NORFOLK\\", "");
            return username;
        }

        public static void LogAction(int wID, string action)
        {
            using (WOLinqClassesDataContext db = new WOLinqClassesDataContext())
            {
                LogActivity l = new LogActivity();
                l.DateTime = DateTime.Now;
                l.wID = wID;
                l.username = GetUserName();
                l.action = action;
                db.LogActivities.InsertOnSubmit(l);
                db.SubmitChanges();
            }
        }
        
        public static void LogErrors(string message)
        {
            using (WOLinqClassesDataContext db = new WOLinqClassesDataContext())
            {
                LogError e = new LogError();
                e.DateTime = DateTime.Now;
                e.username = GetUserName();
                e.message = message;
                e.URL = HttpContext.Current.Request.Url.ToString();
                db.LogErrors.InsertOnSubmit(e);
                db.SubmitChanges();
            }
        }

        public static void PopulateChecklist(CheckBoxList chk, String values)
        {
            // this takes a comma delimited string and populates a checkbox with the matching values
            string [] separator = new string[] {","};
            string[] arr = values.Split(separator,StringSplitOptions.RemoveEmptyEntries);
            foreach (string value in arr)
            {
                ListItem item = chk.Items.FindByValue(value);
                item.Selected = true;
            }
        }

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

        public static String BoolToYesNo(bool? b)
        {
            switch (b) {
                case true: return "Yes"; 
                case false: return "No";
                default: return String.Empty;
            }
        }

        public static String DisplayDate(DateTime? dt)
        {
            if (dt == null)
                return String.Empty;
            else
                return dt.Value.ToString("dddd, dd MMMM, yyyy");
        }

        public static String DisplayDateToEdit(DateTime? dt)
        {
            if (dt == null)
                return String.Empty;
            else
                return dt.Value.ToString("MM/dd/yyyy");
        }

        public static void AddInitialItem(DropDownList dd)
        {
            dd.Items.Insert(0, new ListItem("--Select--",String.Empty));
        }

    }
}