using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HNHUWO2.Classes
{
    public class Admin
    {
        public class UserDetails
        {
            public string Username { get;  set; }
            public string Role { get; set; }
            public int ID { get; set; }
            public string Fullname { get; set; }
            public string Email { get; set; }
            public bool Active { get; set; }
        }

        /// <summary>
        /// Get all of the users in the system. Users are only in the system if they have elevated priveleges (program managers, designers or admins)
        /// </summary>
        /// <returns>List of users with viewable details</returns>
        public static List<UserDetails> GetUsers()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            var q = from u in db.Users
                    select new UserDetails
                    {
                        ID = u.ID,
                        Username = u.Username,
                        Role = u.UserRole.Role,
                        Fullname = u.FullName,
                        Email = u.Email,
                        Active = u.Active
                    };
            return q.ToList();
        }

        /// <summary>
        /// Gets a specific user
        /// </summary>
        /// <param name="ID">ID of a user</param>
        /// <returns>A single user</returns>
        public static User GetUser(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.Users.Single(u => u.ID == ID);
        }

        /// <summary>
        /// Toggles the status of a user (active to inactive and vice versa)
        /// </summary>
        /// <param name="ID">ID of a specific user</param>
        /// <returns>Updated Status (boolean)</returns>
        public static bool? SetUserStatus(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            User u = db.Users.Single(i => i.ID == ID);
            if (u == null) return null;
            u.Active = !u.Active;
            db.SubmitChanges();
            return u.Active;
        }

        /// <summary>
        /// Gets all available roles
        /// </summary>
        /// <returns>List of roles</returns>
        public static List<UserRole> GetRoles()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.UserRoles.ToList();
        }

    }
}