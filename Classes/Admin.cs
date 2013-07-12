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
        }

        public static List<UserDetails> GetUsers()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            var q = from u in db.Users
                    select new UserDetails
                    {
                        ID = u.ID,
                        Username = u.Username,
                        Role = "role"
                    };
            return q.ToList();
        }

    }
}