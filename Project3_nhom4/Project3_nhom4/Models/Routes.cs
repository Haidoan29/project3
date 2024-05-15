using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace Project3_nhom4.Models
{
    public class Routes:Base
    {
        
        public string RouteName { get; set; }
        public int StartStationID { get; set; }
        public int EndStationID { get; set; }

        [ForeignKey("StartStationID")]

        public virtual Station? StartStation { get; set; }
        [ForeignKey("EndStationID")]
        public virtual Station? EndStation { get; set; }

        public ICollection<Train>? Trains { get; set; }
        // Constructor
       
    }
}
