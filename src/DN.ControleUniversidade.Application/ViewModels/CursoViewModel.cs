using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DN.ControleUniversidade.Application.ViewModels
{
    public class CursoViewModel
    {
        public Guid CursoId { get; set; }

        [Display(Name="Nome do Curso")]
        [Required(ErrorMessage="O campo Nome do Curso é obrigatório")]
        [MaxLength(50, ErrorMessage="O campo Nome do Curso permite no máximo 50 caracteres")]
        public string Descricao { get; set; }

        [Display(Name="Tipo de Curso")]
        [Required(ErrorMessage="Selecione um Tipo de Curso")]
        public Guid TipoCursoId { get; set; }
        public IEnumerable<SelectListItem> TiposCurso { get; set; }
        [Display(Name="Situação")]
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
