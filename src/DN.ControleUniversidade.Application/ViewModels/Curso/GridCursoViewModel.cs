using System;
using System.ComponentModel.DataAnnotations;


namespace DN.ControleUniversidade.Application.ViewModels.Curso
{
    public class GridCursoViewModel
    {
        public Guid CursoId { get; set; }
        [Display(Name = "Nome do Curso")]
        public string Nome { get; set; }
        [Display(Name = "Tipo de Curso")]
        public string TipoCurso { get; set; }
        [Display(Name = "Situação")]
        public bool Ativo { get; set; }
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
    }
}