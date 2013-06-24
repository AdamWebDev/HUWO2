using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HNHUWO2.Classes
{
    public class NewsWO
    {
        public static List<NewsDistroOutlet> GetDistroOutlets()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.NewsDistroOutlets.ToList();
        }

        public static WorkOrdersNews GetNewsWorkOrder(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            var q = (from n in db.WorkOrdersNews
                     where n.wID == ID
                     select n).FirstOrDefault();
            return q;
        }

    }
}