using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Specification;
using DN.ControleUniversidade.Domain.Validation.DocumentoValidation;

namespace DN.ControleUniversidade.Domain.Specification.AlunoSpecification
{
    public class CPFAlunoDeveSerValidoSpecification : ISpecification<Aluno>
    {
        public bool IsSatisfiedBy(Aluno aluno)
        {
            return CPFValidation.Validar(aluno.CPF);
        }
    }
}
