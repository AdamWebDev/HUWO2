using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HNHUWO2.Classes
{
    public class VideoWO
    {
        /// <summary>
        /// Gets available video sources
        /// </summary>
        /// <returns>List of video sources</returns>
        public static List<VideoSources> GetVideoSources()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.VideoSources.ToList();
        }

        /// <summary>
        /// Gets available video destinations
        /// </summary>
        /// <returns>List of video destinations</returns>
        public static List<VideoDestination> GetVideoDestinations()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.VideoDestinations.ToList();
        }

        /// <summary>
        /// Gets Narration options
        /// </summary>
        /// <returns>List of narration options</returns>
        public static List<VideoNarration> GetNarration()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.VideoNarrations.ToList();
        }

        /// <summary>
        /// Gets a specific video work order
        /// </summary>
        /// <param name="ID">ID of work order</param>
        /// <returns>Video work order</returns>
        public static WorkOrdersVideo GetVideoWorkOrder(int ID)
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return db.WorkOrdersVideos.Single(w => w.wID == ID);
        }

        /// <summary>
        /// Gets the number of days notice required for a video work order
        /// </summary>
        /// <returns>Number of days notice</returns>
        public static int? GetDaysNotice()
        {
            WOLinqClassesDataContext db = new WOLinqClassesDataContext();
            return (from d in db.lookupVideoDaysNotices
                        select d.DaysNotice).First();
        }

        /// <summary>
        /// Takes the video destinations from db (stored as IDs) and displays them in a nice format
        /// </summary>
        /// <param name="loc">Location string</param>
        /// <returns>Locations (nice format)</returns>
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