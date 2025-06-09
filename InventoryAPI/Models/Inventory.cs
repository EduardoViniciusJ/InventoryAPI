using System.ComponentModel.DataAnnotations;

namespace TestesAPI.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o status")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "O produto é obrigatório")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
