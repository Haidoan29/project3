using Project3.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project3.Models
{
    public class Routers:Base
    {
        public string RouteName { get; set; }
        public int StartStationID { get; set; }
        public int EndStation { get; set; }

        
        public ICollection<Train>? Trains { get; set; }
    }
}
