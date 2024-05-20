using Project3.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Project3.Models
{
    public class Station:Base
    {
        //public Station()
        //{
        //    StartRoutes = new HashSet<Routers>();
        //    EndRoutes = new HashSet<Routers>();
        //    StartTrainSchedules = new HashSet<TrainSchedule>();
        //    EndTrainSchedules = new HashSet<TrainSchedule>();
        //    FromTransaction = new HashSet<Transaction>();
        //    ToTransaction = new HashSet<Transaction>();


        //}

        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string DivisionName { get; set; }
        //public ICollection<Routers> StartRoutes { get; set; }
        //public ICollection<Routers> EndRoutes { get; set; }
        //public ICollection<TrainSchedule> StartTrainSchedules { get; set; }
        //public ICollection<TrainSchedule> EndTrainSchedules { get; set; }
        //public ICollection<Transaction> FromTransaction { get; set; }
        //public ICollection<Transaction> ToTransaction { get; set; }
    }
}
