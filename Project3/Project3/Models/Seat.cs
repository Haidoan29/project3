﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Project3.Models
{
    public class Seat:Base
    {
        public int TrainID { get; set; }
        public string SeatNo { get; set; }
        public string TicketClass { get; set; }
        public bool IsAvailable { get; set; } = true;
        [ForeignKey("TrainID")]
        public virtual Train? Train { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
