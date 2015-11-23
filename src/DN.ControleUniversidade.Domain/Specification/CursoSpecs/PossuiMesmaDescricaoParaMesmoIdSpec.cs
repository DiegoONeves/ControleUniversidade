using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Contracts.Repositories;
using DN.ControleUniversidade.Domain.Contracts.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Specification.CursoSpecs
{
    public class PossuiMesmaDescricaoParaMesmoIdSpec : ISpecification<Curso>
    {
        private readonly ICursoRepository _cursoRepository;
        public PossuiMesmaDescricaoParaMesmoIdSpec(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public bool IsSatisfiedBy(Curso curso)
        {
            var cursoDb = _cursoRepository.ObterPorDescricao(curso.Descricao);

            if (cursoDb != null)
                return (cursoDb.CursoId == curso.CursoId);

            return true;
        }
    }
}
