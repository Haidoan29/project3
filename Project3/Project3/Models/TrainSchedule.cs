using Project3.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project3.Models
{
    public class TrainSchedule : Base
    {
        public int ScheduleID { get; set; }
        public int TrainID { get; set; }
        public int StartStationID { get; set; }
        public int EndStationID { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        [ForeignKey("TrainNo")]
        public virtual Train? Train { get; set; }
    //    [ForeignKey("StartStationID")]

    //    public virtual Station? StartStation { get; set; }
    //    [ForeignKey("EndStationID")]
    //    public virtual Station? EndStation { get; set; }
    }
}
