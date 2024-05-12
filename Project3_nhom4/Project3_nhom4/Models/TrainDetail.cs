using System.ComponentModel.DataAnnotations;

namespace Project3_nhom4.Models
{
    public class TrainDetail : Base
    {
        [Key]
        public int Train_no { get; set; }
        public string Train_Name { get; set; }
        public string Route_from_to { get; set; }
        public DateTime Departure_time { get; set; }
        public int No_of_compartment { get; set; }
        public int _1AC { get; set; }
        public int _2AC { get; set; }
        public int _3AC { get; set; }
        public int Sleeper { get; set; }
        public int General { get; set; }

        //public ICollection<PassengerDetail> PassengerDetails { get; set; }
    }
}
