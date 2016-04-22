using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Repositories;
using DN.ControleUniversidade.Domain.Interfaces.Specification;
using System.Linq;

namespace DN.ControleUniversidade.Domain.Specification.CursoSpecification
{
    public class DescricaoDeveSerUnicaSpecification : ISpecification<Curso>
    {
        private readonly ICursoRepository _cursoRepository;
        public DescricaoDeveSerUnicaSpecification(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }
        public bool IsSatisfiedBy(Curso curso)
        {
            return _cursoRepository.ObterPorDescricao(curso.Descricao) == null;
        }
    }
}
