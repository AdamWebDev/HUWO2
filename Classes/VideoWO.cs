using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HNHUWO2.Classes
{
    public class VideoWO
    {
        public static List<VideoSources> GetVideoSources()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.VideoSources.ToList();
        }

        public static List<VideoDestination> GetVideoDestinations()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.VideoDestinations.ToList();
        }

        public static List<VideoNarration> GetNarration()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.VideoNarrations.ToList();
        }
        public static WorkOrdersVideo GetVideoWorkOrder(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WorkOrdersVideos.Single(w => w.wID == ID);
        }

        public static int? GetDaysNotice()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return (from d in db.lookupVideoDaysNotices
                        select d.DaysNotice).First();
        }

        public static string DisplayFormats(string loc)
        {
            using (WOLinqClassesDataContext db = new WOLinqClassesDataContext())
            {
                string[] formats = loc.Split(new Char[] { ',' });
                string output = String.Empty;
                for (int i = 0; i < formats.Length - 1; i++)
                {
                    var q = (from w in db.VideoDestinations
                             where w.ID == int.Parse(formats[i])
                             select w.Value).FirstOrDefault();
                    output += q.ToString() + "; ";
                }
                return output;
            }
        }
    }
}