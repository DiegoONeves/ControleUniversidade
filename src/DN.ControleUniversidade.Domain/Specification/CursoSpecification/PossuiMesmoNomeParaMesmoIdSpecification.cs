using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Repositories;
using DN.ControleUniversidade.Domain.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Specification.CursoSpecification
{
    public class PossuiMesmoNomeParaMesmoIdSpecification : ISpecification<Curso>
    {
        private readonly ICursoRepository _cursoRepository;
        public PossuiMesmoNomeParaMesmoIdSpecification(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public bool IsSatisfiedBy(Curso curso)
        {
            var cursoDb = _cursoRepository.ObterPorNome(curso.Nome);

            if (cursoDb != null)
                return (cursoDb.CursoId == curso.CursoId);

            return true;
        }
    }
}
