using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Specification;

namespace DN.ControleUniversidade.Domain.Specification.AlunoSpecification
{
    public class NomeDeveTerEntre3E50CaracteresSpecification : ISpecification<Aluno>
    {
        public bool IsSatisfiedBy(Aluno aluno)
        {
            return aluno.Nome.Length >= 3 && aluno.Nome.Length <= 50;
        }
    }
}
