using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Entities
{
    public class TipoCurso
    {
        protected TipoCurso()   {  }
        public TipoCurso(string descricao)
        {
            Descricao = descricao;
        }

        public Guid TipoCursoId { get; set; }
        public string Descricao { get; set; }

        public override string ToString()
        {
            return Descricao;
        }
    }
}
