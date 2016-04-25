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
        public TipoCurso(string descricao, bool ativo)
        {
            TipoCursoId = Guid.NewGuid();
            Descricao = descricao;
            Ativo = ativo;
        }

        public Guid TipoCursoId { get; protected set; }
        public string Descricao { get; protected set; }
        public bool Ativo { get; protected set; }
        public virtual ICollection<Curso> CursoLista { get; protected set; }

        public override string ToString()
        {
            return Descricao;
        }
    }
}
