using Project3.Models;

namespace Project3.Models
{
    public class ReservationSuperFastFee : Base
    {
        public FareClass Class { get; set; }
        public decimal ReservationFee { get; set; }
        public decimal SuperFastFee { get; set; }
    }
}
