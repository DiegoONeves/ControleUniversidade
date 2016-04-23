using System;

namespace DN.ControleUniversidade.Application.ViewModels.TipoCurso
{
    public class TipoCursoViewModel
    {
        public Guid TipoCursoId { get; set; }
        public string Descricao { get; set; }

        public override string ToString()
        {
            return Descricao;
        }
    }
}
