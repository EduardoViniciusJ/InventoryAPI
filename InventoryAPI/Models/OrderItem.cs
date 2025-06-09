using System.ComponentModel.DataAnnotations;

namespace TestesAPI.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        [Required(ErrorMessage = "O ID do pedido é obrigatório")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required(ErrorMessage = "O pedido é obrigatório")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
