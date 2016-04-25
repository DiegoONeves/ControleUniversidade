using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Repositories;
using DN.ControleUniversidade.Domain.Interfaces.Specification;

namespace DN.ControleUniversidade.Domain.Specification.AlunoSpecification
{
    public class CPFDeveSerUnicoSpecification : ISpecification<Aluno>
    {
        private readonly IAlunoRepository _alunoRepository;

        public CPFDeveSerUnicoSpecification(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        public bool IsSatisfiedBy(Aluno aluno)
        {
            return _alunoRepository.ObterPorCPF(aluno.CPF) == null;
        }
    }
}
