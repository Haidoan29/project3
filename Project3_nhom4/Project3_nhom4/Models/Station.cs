namespace Project3_nhom4.Models
{
    public class Station:Base
    {
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string DivisionName { get; set; }
        public ICollection<Route>? Routes { get; set; }
        public ICollection<TrainSchedule> TrainSchedules { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
