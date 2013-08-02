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
        /// <summary>
        /// Gets the current user's role
        /// </summary>
        /// <returns>Null, or the user's role ID</returns>
        public static int? GetUserRole()
        {
            return MySession.Current.Role == null ? GetUserRole(_GetUserName()) : MySession.Current.Role;
        }

        /// <summary>
        /// Gets the user role of a specific user
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Null, or the users's role ID</returns>
        public static int? GetUserRole(String username) 
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            var q = (from w in db.Users
                        where w.Username == username
                        select w).FirstOrDefault();
            // if the user doesn't exist or is inactive, return 0
            return (q == null || !q.Active) ? 0 : q.Role;
        }

        /// <summary>
        /// Is the user a coordinator?
        /// </summary>
        /// <returns>True/false</returns>
        public static bool IsUserCoordinator()
        {
            // admins see all the things too!
            return (MySession.Current.Role == 3 || MySession.Current.Role == 1);
        }

        /// <summary>
        /// Is the user a designer?
        /// </summary>
        /// <returns>True/false</returns>
        public static bool IsUserDesigner()
        {
            // admins see all the things!
            return (MySession.Current.Role == 2 || MySession.Current.Role == 1);
        }

        /// <summary>
        /// Is the user an admin?
        /// </summary>
        /// <returns>True/false</returns>
        public static bool IsUserAdmin()
        {
            // admins see all the... yeah.
            return MySession.Current.Role == 1;
        }

        /// <summary>
        /// Gets the user ID based on username
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <returns>ID of user, or null</returns>
        public static int? GetUserID(String username)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            var q = (from w in db.Users
                     where w.Username == username
                     select w.ID).FirstOrDefault();
            return q;
        }

        /// <summary>
        /// Shows the display name of the current user
        /// </summary>
        /// <returns>Display name</returns>
        public static string GetUsername()
        {
            return QueryAD("displayname", _GetUserName());
        }

        /// <summary>
        /// Shows the display name of a specific user
        /// </summary>
        /// <param name="username">Username of a specific user</param>
        /// <returns>Display name</returns>
        public static string GetUsername(string username)
        {
            return QueryAD("displayname", username);
        }

        /// <summary>
        /// Gets the username of the current user
        /// </summary>
        /// <returns>Username</returns>
        private static string _GetUserName()
        {
            return Function.GetUserName();
        }

        /// <summary>
        /// Get specific fields of a user from AD
        /// </summary>
        /// <param name="fieldname">Fieldname to return</param>
        /// <param name="username">Username to look up</param>
        /// <returns>The result</returns>
        private static string QueryAD(string fieldname, string username)
        {
            // AD credentials are needed to query from production server
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

        /// <summary>
        /// Gets the email address of a specific user
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>Email address</returns>
        public static string GetUserEmail(string username)
        {
            return QueryAD("mail", username);
        }

        /// <summary>
        /// Gets the first name of the current user
        /// </summary>
        /// <returns>First name</returns>
        public static string GetFirstName()
        {
            return GetFirstName(_GetUserName());
        }

        /// <summary>
        /// Gets the first name of a specific user
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <returns>First name</returns>
        public static string GetFirstName(string username)
        {
            return QueryAD("givenName", username);
        }

        /// <summary>
        /// Checks if the user exists in AD
        /// </summary>
        /// <param name="username">Username to search</param>
        /// <returns>True/false</returns>
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