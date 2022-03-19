using System.ComponentModel.DataAnnotations;

namespace LocadoraDeCarros.Models.ModeloDados
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Senha")]
        public string? Password { get; set; }
    }
}
