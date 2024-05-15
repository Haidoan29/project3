namespace Project3_nhom4.Models
{
    public class Cancellation : Base
    {
        public string PRNNo { get; set; }
        public DateTime CancellationDate { get; set; }
        public decimal CancellationFee { get; set; }

    }
}
