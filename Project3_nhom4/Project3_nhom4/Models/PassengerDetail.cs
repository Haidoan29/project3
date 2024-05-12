using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project3_nhom4.Models
{
    public class PassengerDetail:Base
    {
        [Key]
        public int PNR_no { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public int Total_Passenger { get; set; }
        public string Date_of_Travel { get; set; }
        public string Class { get; set; }
        public string Train_no { get; set; }

        //[ForeignKey("Train_no")]
        //public virtual TrainDetail TrainDetail { get; set; }
    }
}
