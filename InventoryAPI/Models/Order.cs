namespace TestesAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public decimal TotalPrice { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();  

    }
}
