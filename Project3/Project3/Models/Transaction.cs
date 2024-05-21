using Project3.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project3.Models
{
    public class Transaction : Base
    {
        public string PRNNo { get; set; }
        public int TrainID { get; set; }
        public int CustomerID { get; set; }
        public DateTime JourneyDate { get; set; }
        public int FromStationID { get; set; }
        public int ToStationID { get; set; }
        public string SeatNo { get; set; }
        public string CoachNo { get; set; }
        public decimal ReservationFee { get; set; }
        [ForeignKey("TrainID")]
        public virtual Train? Train { get; set; }
        [ForeignKey("FromStationID")]
        public virtual Station? FromStation { get; set; }
        [ForeignKey("ToStationID")]
        public virtual Station? ToStation { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer? Customer { get; set; }
    }
}
