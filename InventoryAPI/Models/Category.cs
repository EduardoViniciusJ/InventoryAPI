using System.ComponentModel.DataAnnotations;

namespace TestesAPI.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome da categoria deve ter no máximo 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "É obrigatório informar se a categoria está ativa")]
        public bool Active { get; set; }

        public DateTime RegistrationDate { get; set; }

    }
}
