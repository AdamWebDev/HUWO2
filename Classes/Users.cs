using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;
using System.Web.Configuration;

namespace HNHUWO2.Classes
{
    public class Users
    {

        public static int? GetUserRole()
        {
            return GetUserRole(_GetUserName());
        }

        public static int? GetUserRole(String username) 
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            var q = (from w in db.Users
                     where w.Username == username
                     select w).FirstOrDefault();
            return q.Active ? q.Role : null;
        }

        public static bool IsUserCoordinator()
        {
            return IsUserCoordinator(_GetUserName());
        }

        public static bool IsUserCoordinator(String username)
        {
            int? role = GetUserRole(username);
            if (role == 3 || role == 1)
                return true;
            else
                return false;
        }

        public static bool IsUserDesigner()
        {
            return IsUserDesigner(_GetUserName());
        }

        public static bool IsUserDesigner(String username)
        {
            int? role = GetUserRole(username);
            if (role == 2 || role == 1)
                return true;
            else
                return false;
        }

        public static bool IsUserAdmin()
        {
            int? role = GetUserRole(_GetUserName());
            if (role == 1)
                return true;
            else
                return false;
        }

        public static int? GetUserID(String username)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            var q = (from w in db.Users
                     where w.Username == username
                     select w.ID).FirstOrDefault();
            return q;
        }

        public static string GetUsername()
        {
            return QueryAD("displayname", _GetUserName());
        }

        public static string GetUsername(string username)
        {
            return QueryAD("displayname", username);
        }

        private static string _GetUserName()
        {
            return Function.GetUserName();
        }

        private static string QueryAD(string fieldname, string username)
        {
            // hanging on to this in case users need this - I don't
            string ADServer = WebConfigurationManager.AppSettings["ADServer"];
            string ADUser = WebConfigurationManager.AppSettings["ADUser"];
            string ADPassword = WebConfigurationManager.AppSettings["ADPassword"];
            DirectoryEntry entry = new DirectoryEntry();
            DirectorySearcher search = new DirectorySearcher(entry);
            search.SearchRoot = entry;
            search.Filter = String.Format("(SAMAccountName={0})", username);
            search.PropertiesToLoad.Add(fieldname);
            SearchResult result = search.FindOne();
            return (string)result.Properties[fieldname][0];
        }

        public static string GetUserEmail(string username)
        {
            return QueryAD("mail", username);
        }

        public static string GetFirstName(string username)
        {
            return QueryAD("givenName", username);
        }

        public static bool DoesUserExist(string username)
        {
            DirectoryEntry entry = new DirectoryEntry();
            DirectorySearcher search = new DirectorySearcher(entry);
            search.SearchRoot = entry;
            search.Filter = String.Format("(SAMAccountName={0})", username);
            SearchResultCollection results = search.FindAll();
            return results.Count > 0;
        }


    }
}