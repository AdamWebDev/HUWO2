using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HNHUWO2.Classes
{
    public class WebWO
    {
        public static List<WebLocation> GetLocations()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WebLocations.ToList();
        }

        public static string DisplayLocations(string loc)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            string [] locations = loc.Split(new Char [] {','});
            string output = String.Empty;
            for (int i = 0; i < locations.Length-1; i++)
            {
                var q = (from w in db.WebLocations
                         where w.ID == int.Parse(locations[i])
                         select w.Value).FirstOrDefault();
                output += q.ToString() + "; ";
            }
            return output;
        }

        public static List<WebType> GetTypes()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WebTypes.ToList();
        }

        public static List<WebUpdateType> GetUpdateTypes()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WebUpdateTypes.ToList();
        }

        public static List<WebSites> GetWebSites()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WebSites.ToList();
        }

        public static WorkOrdersWeb GetWebWorkOrder(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WorkOrdersWebs.Single(w => w.wID == ID);
        }

    }
}