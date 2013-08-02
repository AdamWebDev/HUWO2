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
        /// <summary>
        /// An easy way to convert a boolean value to a Yes/No string for display purposes
        /// </summary>
        /// <param name="value">Boolean value</param>
        /// <returns>Yes/No string</returns>
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
        /// <summary>
        /// Display dates in a consistant format
        /// </summary>
        /// <param name="value">Date to display</param>
        /// <returns>Fancy date</returns>
        public static string DisplayDate(this DateTime value)
        {
            return value.ToString("dddd, MMMM dd, yyyy");
        }

        /// <summary>
        /// Display dates in a consistant format
        /// </summary>
        /// <param name="value">Date to display</param>
        /// <returns>Fancy date</returns>
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
        /// <summary>
        /// Converts a string date (done with a datepicker) into a DateTime object
        /// </summary>
        /// <param name="value">string date</param>
        /// <returns>DateTime object</returns>
        public static DateTime? ConvertToDate(this String value)
        {
            DateTime dateValue;
            if (DateTime.TryParseExact(value, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateValue))
                return dateValue;
            else
                return null;
        }

        /// <summary>
        /// Replaces line breaks with HTML breaks
        /// </summary>
        /// <param name="value">Original string</param>
        /// <returns>String with HTML breaks</returns>
        public static String IncludeLineBreaks(this String value)
        {
            return (value == null) ? String.Empty : value.Replace("\n", "<br />");
        }
    }

    public static class DropDownListExtensions
    {
        /// <summary>
        /// Adds a consistant item for dropdown lists
        /// </summary>
        /// <param name="dd"></param>
        public static void AddInitialItem(this System.Web.UI.WebControls.DropDownList dd)
        {
            dd.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", String.Empty));
        }

    }

    


    
}