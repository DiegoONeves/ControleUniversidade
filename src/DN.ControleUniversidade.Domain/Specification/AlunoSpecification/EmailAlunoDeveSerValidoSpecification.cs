using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Specification;
using DN.ControleUniversidade.Domain.Validation.UsuarioValidation;

namespace DN.ControleUniversidade.Domain.Specification.AlunoSpecification
{
    public class EmailAlunoDeveSerValidoSpecification : ISpecification<Aluno>
    {
        public bool IsSatisfiedBy(Aluno aluno)
        {
            return EmailValidation.Validar(aluno.Usuario.Email);
        }
    }
}
