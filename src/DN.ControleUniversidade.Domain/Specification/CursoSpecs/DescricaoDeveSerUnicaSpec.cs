using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Contracts.Repositories;
using DN.ControleUniversidade.Domain.Contracts.Specification;
using System.Linq;

namespace DN.ControleUniversidade.Domain.Specification.CursoSpecs
{
    public class DescricaoDeveSerUnicaSpec : ISpecification<Curso>
    {
        private readonly ICursoRepository _cursoRepository;
        public DescricaoDeveSerUnicaSpec(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }
        public bool IsSatisfiedBy(Curso curso)
        {
            return _cursoRepository.ObterPorDescricao(curso.Descricao) == null;
        }
    }
}
