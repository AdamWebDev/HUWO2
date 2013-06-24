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
            var q = (from v in db.WorkOrdersVideos
                     where v.wID == ID
                     select v).FirstOrDefault();
            return q;
        }

        public static int? GetDaysNotice()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return (from d in db.lookupVideoDaysNotices
                        select d.DaysNotice).First();
        }
    }
}