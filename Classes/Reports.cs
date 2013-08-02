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

        public class ProjectReport 
        {
            public string ProjectType { get; set; }
            public int Count { get; set; }
        }

        public class PrintReport
        {
            public string PrintType { get; set; }
            public int Count { get; set; }
        }

        /// <summary>
        /// For reporting, the start date and end dates are optional - so let's use these values when they're blank
        /// (this was launched in 2013, so the 2012 date will work just fine)
        /// </summary>
        private static DateTime _minDate = new DateTime(2012, 12, 21);
        private static DateTime _maxDate = new DateTime(2050, 12, 21);

        /// <summary>
        /// Gets a report based on work orders by coordinator
        /// </summary>
        /// <param name="startDate">Optional start date</param>
        /// <param name="endDate">Optional end date</param>
        /// <returns>List of work orders assigned to coordinators</returns>
        public static List<CoordinatorReport> ByCoordinator(DateTime? startDate, DateTime? endDate)
        {
            DateTime start = startDate.HasValue ? (DateTime)startDate : _minDate;
            DateTime end = endDate.HasValue ? (DateTime)endDate : _maxDate;
            return ByCoordinator(start, end);
        }

        /// <summary>
        /// Gets a report based on work orders by coordinator
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>List of work orders assigned to coordinators</returns>
        public static List<CoordinatorReport> ByCoordinator(DateTime startDate, DateTime endDate)
        {   
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            // make sure we don't include the deleted work orders!
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

        /// <summary>
        /// Gets a report based on work orders by project type
        /// </summary>
        /// <param name="startDate">Optional start date</param>
        /// <param name="endDate">Optional end date</param>
        /// <returns>List of work orders grouped by project type</returns>
        public static List<ProjectReport> ByProjectType(DateTime? startDate, DateTime? endDate)
        {
            DateTime start = startDate.HasValue ? (DateTime)startDate : _minDate;
            DateTime end = endDate.HasValue ? (DateTime)endDate : _maxDate;
            return ByProjectType(start, end);
        }

        /// <summary>
        /// Gets a report based on work orders by project type
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>List of work orders grouped by project type</returns>
        public static List<ProjectReport> ByProjectType(DateTime startDate, DateTime endDate)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            var q = from w in db.Workorders
                    where w.submitted_date.Date >= startDate.Date && w.submitted_date <= endDate.Date && w.status < 7
                    group w by w.WOType1.type into g
                    select new ProjectReport
                    {
                        ProjectType = g.Key,
                        Count = g.Count()
                    };
            return q.ToList();
        }

        /// <summary>
        /// Gets a report based on work orders by print type
        /// </summary>
        /// <param name="startDate">Optional start date</param>
        /// <param name="endDate">Optional end date</param>
        /// <returns>List of work orders grouped by print type</returns>
        public static List<PrintReport> ByPrintType(DateTime? startDate, DateTime? endDate)
        {
            DateTime start = startDate.HasValue ? (DateTime)startDate : _minDate;
            DateTime end = endDate.HasValue ? (DateTime)endDate : _maxDate;
            return ByPrintType(start, end);
        }

        /// <summary>
        /// Gets a report based on work orders by print type
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>List of work orders grouped by print type</returns>
        public static List<PrintReport> ByPrintType(DateTime startDate, DateTime endDate)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            // make sure not to include deleted work orders
            var q = from w in db.WorkOrdersPrints
                    where w.Workorder.submitted_date.Date >= startDate.Date && w.Workorder.submitted_date <= endDate.Date && w.Workorder.status < 7 && w.Workorder.WOType1.type.Equals("Print")
                    group w by w.lookupPrintTypeOfProject.Value into g
                    select new PrintReport
                    {
                        PrintType = g.Key,
                        Count = g.Count()
                    };
            return q.ToList();
        }
    }
}