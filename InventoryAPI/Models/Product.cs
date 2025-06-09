using System.ComponentModel.DataAnnotations;

namespace TestesAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome do produto deve ter no máximo 100 caracteres")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "O status do produto é obrigatório")]
        public bool Active { get; set; }
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
