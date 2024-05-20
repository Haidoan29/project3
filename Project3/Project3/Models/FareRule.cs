using Project3.Models;

namespace Project3.Models
{
    public class FareRule : Base
    {
        public FareClass Class { get; set; }
        public int Distance { get; set; }
        public decimal Fare { get; set; }
    }
    public enum FareClass
    {
        AC1,
        AC3,
        FirstClass,
        Sleeper
    }
}
