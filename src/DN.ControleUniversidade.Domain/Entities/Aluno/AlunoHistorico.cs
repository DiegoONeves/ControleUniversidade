using DN.ControleUniversidade.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Entities
{
    public class AlunoHistorico
    {
        protected AlunoHistorico() { }
        public AlunoHistorico(Aluno aluno, SituacaoAluno situacaoAluno)
        {
            AlunoHistoricoId = Guid.NewGuid();
            Aluno = aluno;
            SituacaoAluno = situacaoAluno;
            DataCadastro = DateTime.Now;
        }
        public Guid AlunoHistoricoId { get; protected set; }
        public virtual Aluno Aluno { get; protected set; }
        public SituacaoAluno SituacaoAluno { get; protected set; }
        public DateTime DataCadastro { get; protected set; }


        public override string ToString()
        {
            return SituacaoAluno.ToString();
        }
    }
}
