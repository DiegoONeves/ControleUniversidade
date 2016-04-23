using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DN.ControleUniversidade.Application.ViewModels.Curso
{
    public class NovoCursoViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(5, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        public string Nome { get; set; }
        [Display(Name = "Situação")]
        public bool Ativo { get; set; }
        [Display(Name = "Tipo de Curso")]
        [RegularExpression(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$")]
        [Required(ErrorMessage = "Escolha um Tipo de Curso")]
        public Guid TipoCursoId { get; set; }
        public IEnumerable<SelectListItem> TiposCurso { get; set; }
    }
}