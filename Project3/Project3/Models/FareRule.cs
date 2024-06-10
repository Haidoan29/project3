using Project3.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project3.Models
{
    public class FareRule : Base
    {
        public FareClass Class { get; set; }
        public int RouterID { get; set; }
        public decimal Fare { get; set; }
        [ForeignKey("RouterID")]
        public virtual MyRouter? Router { get; set; }
        
    }
    public enum FareClass
    {
        AC1,
        AC3,
        FirstClass,
        Sleeper
    }
}
