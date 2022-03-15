﻿using System.ComponentModel.DataAnnotations;

namespace LocadoraDeCarros.Models.ModeloDados
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage= "A {0} deve ter ao menos {2} e como máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name ="Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirmar Senha")]
        [Compare("Pssword", ErrorMessage ="A senha informada não confere com a confirmação da senha")]
        public string ConfirmPassword { get; set; }
    }
}
