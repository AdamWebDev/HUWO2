using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HNHUWO2.Classes
{
    public class PrintWO
    {
        public static List<PrintTypeOfProject> GetTypeOfProjects()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.PrintTypeOfProjects.ToList();
        }

        public static List<PrintTypeOfDisplay> GetTypeOfDisplays()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.PrintTypeOfDisplays.ToList();
        }

        public static List<PrintMethod> GetPrintMethods()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.PrintMethods.ToList();
        }

        public static List<PrintPaperSize> GetPaperSizes()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.PrintPaperSizes.ToList();
        }

        public static List<PrintPaperType> GetPaperTypes()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.PrintPaperTypes.ToList();
        }

        public static List<PrintColourInfo> GetColourInfo()
        {
            return GetColourInfo(false);
        }

        public static List<PrintColourInfo> GetColourInfo(bool showOneColour)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            List<PrintColourInfo> results = db.PrintColourInfos.ToList();
            if (showOneColour)
                results.RemoveAt(results.Count); // removes the last item (the one colour option)
            return results;

        }

        public static List<PrintCreditType> GetCreditType()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.PrintCreditTypes.ToList();
        }

        public static WorkOrdersPrint GetPrintWorkOrder(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WorkOrdersPrints.Single(w => w.wID == ID);
        }

        public static PrintDaysNotice GetDaysNoticeAndMessage(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.PrintDaysNotices.Single(d => d.pID == ID);
        }

        public static bool HasWebWorkOrder(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return (db.WorkOrdersWebs.Any(w => w.pID == ID));
        }
    }
}