namespace Project3_nhom4.Models
{
    public class Customer: Base
    {
        public string Name { get; set; }
        public string NumberCCCD { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
