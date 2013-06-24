using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HNHUWO2.Classes
{
    public class Reports
    {
        public class CoordinatorReport
        {
            public string CoordinatorName { get; set; }
            public int Count { get; set; }
        }

        private static DateTime _minDate = new DateTime(2012, 12, 21);
        private static DateTime _maxDate = new DateTime(2050, 12, 21);

        public static List<CoordinatorReport> ByCoordinator(DateTime startDate, DateTime endDate)
        {   
            
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            var q = from w in db.Workorders
                    where w.submitted_date.Date >= startDate.Date && w.submitted_date <= endDate.Date && w.status < 7
                    group w by w.User.FullName into g
                    select new CoordinatorReport
                    {
                        CoordinatorName = g.Key,
                        Count = g.Count()
                    };
            return q.ToList();
        }

        public static List<CoordinatorReport> ByCoordinator(DateTime? startDate, DateTime? endDate)
        {
            if (startDate.HasValue && endDate.HasValue)
            {
                DateTime start = (DateTime)startDate;
                DateTime end = (DateTime)endDate;
                return ByCoordinator(start, end);
            }
            else if (startDate.HasValue)
            {
                DateTime start = (DateTime)startDate;
                return ByCoordinator(start, _maxDate);
            }
            else if (endDate.HasValue)
            {
                DateTime end = (DateTime)endDate;
                return ByCoordinator(_minDate, endDate);
            }
            else
            {
                return ByCoordinator(_minDate, _maxDate);
            }
        }

        public static List<CoordinatorReport> ByCoordinator()
        {
            return ByCoordinator(_minDate,_maxDate);
        }
    }
}