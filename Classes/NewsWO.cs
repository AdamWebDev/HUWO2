using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HNHUWO2.Classes
{
    public class NewsWO
    {
        /// <summary>
        /// Gets outlets for distribution
        /// </summary>
        /// <returns>List of Distro outlets</returns>
        public static List<NewsDistroOutlet> GetDistroOutlets()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.NewsDistroOutlets.ToList();
        }

        /// <summary>
        /// Gets a specific New Work Order
        /// </summary>
        /// <param name="ID">ID of the work order</param>
        /// <returns>News Work Order</returns>
        public static WorkOrdersNews GetNewsWorkOrder(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WorkOrdersNews.Single(u => u.wID == ID);
        }
    }
}