using System.ComponentModel.DataAnnotations.Schema;

namespace Project3_nhom4.Models
{
    public class Train : Base
    {
        public string TrainName { get; set; }
        public int NumCoachesAC3 { get; set; }
        public int NumCoachesFirstClass { get; set; }
        public int NumCoachesSleeper { get; set; }
        public UpDownStatus UpDownStatus { get; set; }
        public int RouteID { get; set; }
        [ForeignKey("RouteID")]
        public virtual Routes? Routes { get; set; }
        public ICollection<TrainSchedule>? TrainSchedules { get; set; }
        public ICollection<DayMaster>? DayMasters { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
    public enum UpDownStatus
    {
        Up,
        Down
    }
}
