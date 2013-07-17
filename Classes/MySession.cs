using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HNHUWO2.Classes
{
    public class MySession
    {
        public static MySession Current
        {
            get
            {
                MySession session = (MySession)HttpContext.Current.Session["__MySession__"];
                if (session == null)
                {
                    session = new MySession();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
        }

        public string FirstName { get; set; }
        public string UserName { get; set; }
        public int? Role { get; set; }
    }
}