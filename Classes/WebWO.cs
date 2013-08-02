using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HNHUWO2.Classes
{
    public class WebWO
    {
        /// <summary>
        /// Gets a list of locations to place on the web
        /// </summary>
        /// <returns>List of web locations</returns>
        public static List<WebLocation> GetLocations()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WebLocations.ToList();
        }

        /// <summary>
        /// Formats a list of locations (stored as IDs) and creates a nice display string
        /// </summary>
        /// <param name="loc">Location string (as IDs)</param>
        /// <returns></returns>
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

        /// <summary>
        /// Get types of web work orders
        /// </summary>
        /// <returns>List of types of web work orders</returns>
        public static List<WebType> GetTypes()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WebTypes.ToList();
        }

        /// <summary>
        /// Get types of updates
        /// </summary>
        /// <returns>List of types of updates</returns>
        public static List<WebUpdateType> GetUpdateTypes()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WebUpdateTypes.ToList();
        }

        /// <summary>
        /// Get list of HU websites
        /// </summary>
        /// <returns>List of HU Websites</returns>
        public static List<WebSites> GetWebSites()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WebSites.ToList();
        }

        /// <summary>
        /// Gets a specific web work order
        /// </summary>
        /// <param name="ID">ID of work order</param>
        /// <returns>Web work order</returns>
        public static WorkOrdersWeb GetWebWorkOrder(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WorkOrdersWebs.Single(w => w.wID == ID);
        }

    }
}