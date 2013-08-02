using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HNHUWO2.Classes
{
    public class RadioWO
    {
        /// <summary>
        /// Get available radio ad types
        /// </summary>
        /// <returns>List of radio ad types</returns>
        public static List<RadioAdType> GetRadioAdTypes()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.RadioAdTypes.ToList();
        }

        /// <summary>
        /// Get available radio stations
        /// </summary>
        /// <returns>List of radio stations</returns>
        public static List<RadioStations> GetRadioStations()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.RadioStations.ToList();
        }

        /// <summary>
        /// Get available ad lengths
        /// </summary>
        /// <returns>List of ad lengths</returns>
        public static List<RadioLength> GetRadioAdLengths()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.RadioLengths.ToList();
        }

        /// <summary>
        /// Get available recording options
        /// </summary>
        /// <returns>List of recording options</returns>
        public static List<RadioRecordingOption> GetRecordingOptions() 
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.RadioRecordingOptions.ToList();
        }

        /// <summary>
        /// Get a single radio work order
        /// </summary>
        /// <param name="ID">ID of work order</param>
        /// <returns>Single Radio Work Order object</returns>
        public static WorkOrdersRadio GetRadioWorkOrder(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WorkOrdersRadios.Single(w => w.wID == ID);
        }
    }
}