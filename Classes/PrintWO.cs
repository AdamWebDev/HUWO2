using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HNHUWO2.Classes
{
    public class PrintWO
    {
        /// <summary>
        /// Gets type of projects to populate dropdowns
        /// </summary>
        /// <returns>List of types of print projects</returns>
        public static List<PrintTypeOfProject> GetTypeOfProjects()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.PrintTypeOfProjects.ToList();
        }

        /// <summary>
        /// Gets the types of displays available
        /// </summary>
        /// <returns>List of types of displays</returns>
        public static List<PrintTypeOfDisplay> GetTypeOfDisplays()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.PrintTypeOfDisplays.ToList();
        }

        /// <summary>
        /// Gets the available print methods
        /// </summary>
        /// <returns>List of print methods</returns>
        public static List<PrintMethod> GetPrintMethods()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.PrintMethods.ToList();
        }

        /// <summary>
        /// Gets the available paper sizes
        /// </summary>
        /// <returns>List of paper sizes</returns>
        public static List<PrintPaperSize> GetPaperSizes()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.PrintPaperSizes.ToList();
        }

        /// <summary>
        /// Gets the available paper types
        /// </summary>
        /// <returns>List of paper types</returns>
        public static List<PrintPaperType> GetPaperTypes()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.PrintPaperTypes.ToList();
        }

        /// <summary>
        /// Gets the available Colour options
        /// </summary>
        /// <returns>List of colour options</returns>
        public static List<PrintColourInfo> GetColourInfo()
        {
            return GetColourInfo(false);
        }

        /// <summary>
        /// Gets the available colour options
        /// </summary>
        /// <param name="showOneColour">Include the "one colour" option?</param>
        /// <returns>List of colour options</returns>
        public static List<PrintColourInfo> GetColourInfo(bool showOneColour)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            List<PrintColourInfo> results = db.PrintColourInfos.ToList();
            if (showOneColour)
                results.RemoveAt(results.Count); // removes the last item (the one colour option)
            return results;

        }

        /// <summary>
        /// Gets the credit options
        /// </summary>
        /// <returns>List of credit options</returns>
        public static List<PrintCreditType> GetCreditType()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.PrintCreditTypes.ToList();
        }

        /// <summary>
        /// Gets a single print work order
        /// </summary>
        /// <param name="ID">ID of a work order</param>
        /// <returns>Single print work order</returns>
        public static WorkOrdersPrint GetPrintWorkOrder(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WorkOrdersPrints.Single(w => w.wID == ID);
        }

        /// <summary>
        /// Gets the number of days notice needed for a type of work order
        /// </summary>
        /// <param name="ID">Type of print work order</param>
        /// <returns>Days Notice object</returns>
        public static PrintDaysNotice GetDaysNoticeAndMessage(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.PrintDaysNotices.Single(d => d.pID == ID);
        }

        /// <summary>
        /// Checks to see if there is a related web work order
        /// </summary>
        /// <param name="ID">ID of the print work order</param>
        /// <returns>If there is a related web work order</returns>
        public static bool HasWebWorkOrder(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return (db.WorkOrdersWebs.Any(w => w.pID == ID));
        }
    }
}