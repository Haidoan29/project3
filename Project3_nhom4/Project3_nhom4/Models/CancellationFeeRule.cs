namespace Project3_nhom4.Models
{
    public class CancellationFeeRule : Base
    {
       
        public FareClass Class { get; set; }
        public decimal CancellationFee { get; set; }
    }
}
