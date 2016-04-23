using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Repositories;
using DN.ControleUniversidade.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DN.ControleUniversidade.Infra.Data.Repositories
{
    public class CursoRepository : RepositoryBase<Curso, UniversidadeContext>, ICursoRepository
    {
        public IEnumerable<Curso> ObterGrid()
        {
            return DbSet
                .Include("TipoCurso")
                .AsNoTracking()
                .ToList();
        }

        public Curso ObterPorIdComDependencias(Guid cursoId)
        {
            return DbSet
                 .Include("TipoCurso")
                 .FirstOrDefault(x => x.CursoId == cursoId);
        }

        public Curso ObterPorNome(string descricao)
        {
            return Find(x => x.Nome == descricao).FirstOrDefault();
        }
    }
}
