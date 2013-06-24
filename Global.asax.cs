using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace HNHUWO2
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }


    public static class BooleanExtensions
    {
        public static string ToYesNoString(this bool? value)
        {
            switch (value)
            {
                case true: return "Yes";
                case false: return "No";
                default: return String.Empty;
            }
        }
    }

    public static class DateTimeExtensions
    {
        public static string DisplayDate(this DateTime value)
        {
            return value.ToString("dddd, MMMM dd, yyyy");
        }

        public static string DisplayDate(this DateTime? value)
        {
            if (value == null)
                return String.Empty;
            else
            {
                return DisplayDate((DateTime)value);
            }
        }
    }

    public static class StringExtensions
    {
        public static DateTime? ConvertToDate(this String value)
        {
            DateTime dateValue;
            if (DateTime.TryParseExact(value, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateValue))
                return dateValue;
            else
                return null;
        }
    }

    public static class DropDownListExtensions
    {
        public static void AddInitialItem(this System.Web.UI.WebControls.DropDownList dd)
        {
            dd.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", String.Empty));
        }

    }

    


    
}