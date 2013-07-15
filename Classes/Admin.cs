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

        public static bool? SetUserStatus(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            User u = db.Users.Single(i => i.ID == ID);
            if (u == null) return null;
            u.Active = !u.Active;
            db.SubmitChanges();
            return u.Active;
        }

    }
}