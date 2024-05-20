using Project3.Models;

namespace Project3.Models
{
    public class CancellationFeeRule : Base
    {
       
        public FareClass Class { get; set; }
        public decimal CancellationFee { get; set; }
    }
}
