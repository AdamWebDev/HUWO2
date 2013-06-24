using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;

namespace HNHUWO_2._0
{
    public class ActiveDirectory
    {
        public string ExtractUserName(string path)
        {
            string[] userPath = path.Split(new char[] { '\\' });
            return userPath[userPath.Length - 1];
        }

        public string QueryAD(string fieldname = "cn")
        {
            string userName = ExtractUserName(HttpContext.Current.User.Identity.Name);
            DirectorySearcher search = new DirectorySearcher();
            search.Filter = String.Format("(SAMAccountName={0})", userName);
            search.PropertiesToLoad.Add(fieldname);
            SearchResult result = search.FindOne();
            return (string)result.Properties[fieldname][0];
        }
        public string QueryAD(string fieldname, string querystring)
        {
            string userName = ExtractUserName(querystring);
            DirectorySearcher search = new DirectorySearcher();
            search.Filter = String.Format("(SAMAccountName={0})", userName);
            search.PropertiesToLoad.Add(fieldname);
            SearchResult result = search.FindOne();
            return (string)result.Properties[fieldname][0];
        }
    }
}