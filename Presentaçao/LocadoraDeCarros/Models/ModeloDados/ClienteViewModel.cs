using System.ComponentModel.DataAnnotations;

namespace LocadoraDeCarros.Models.ModeloDados
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo nome é obrigatório.")]
        [Display(Name = "Nome e sobrenome")]
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        [Required]
        [Display(Name ="Endereço do cliente")]
        public string? Endereco { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? CarteiraDeMotorista { get; set; }
        [Required]
        public string? CartaoDeCredito { get; set; }
 

    }
}
