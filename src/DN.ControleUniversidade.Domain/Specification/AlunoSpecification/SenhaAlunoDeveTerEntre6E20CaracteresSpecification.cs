using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Specification;

namespace DN.ControleUniversidade.Domain.Specification.AlunoSpecification
{
    public class SenhaAlunoDeveTerEntre6E20CaracteresSpecification : ISpecification<Aluno>
    {
        public bool IsSatisfiedBy(Aluno aluno)
        {
            return aluno.Usuario.Senha.Length >= 6 && aluno.Usuario.Senha.Length <= 20;
        }
    }
}
