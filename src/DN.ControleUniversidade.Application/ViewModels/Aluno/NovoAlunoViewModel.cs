using System;
using System.ComponentModel.DataAnnotations;

namespace DN.ControleUniversidade.Application.ViewModels.Aluno
{
    public class NovoAlunoViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CPF { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name ="E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Password)]
        [MaxLength(20, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(6, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        public string Senha { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Compare("Senha", ErrorMessage = "As senhas não são iguais")]
        [DataType(DataType.Password)]
        public string ConfirmarSenha { get; set; }

        [Display(Name = "Situação")]
        public bool Ativo { get; set; }
    }
}
