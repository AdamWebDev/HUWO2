using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HNHUWO2.Classes
{
    public class RadioWO
    {
        public static List<RadioAdType> GetRadioAdTypes()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.RadioAdTypes.ToList();
        }

        public static List<RadioStations> GetRadioStations()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.RadioStations.ToList();
        }

        public static List<RadioLength> GetRadioAdLengths()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.RadioLengths.ToList();
        }

        public static List<RadioRecordingOption> GetRecordingOptions() 
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.RadioRecordingOptions.ToList();
        }
        public static WorkOrdersRadio GetRadioWorkOrder(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WorkOrdersRadios.Single(w => w.wID == ID);
        }
    }
}