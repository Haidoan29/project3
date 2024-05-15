namespace Project3_nhom4.Models
{
    public class ReservationSuperFastFee : Base
    {
        public FareClass Class { get; set; }
        public decimal ReservationFee { get; set; }
        public decimal SuperFastFee { get; set; }
    }
}
