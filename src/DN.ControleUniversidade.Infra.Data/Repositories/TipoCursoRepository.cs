using DN.ControleUniversidade.Domain.Interfaces.Repositories;
using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Infra.Data.Repositories
{
    public class TipoCursoRepository : RepositoryBase<TipoCurso>, ITipoCursoRepository
    {
        public TipoCursoRepository(UniversidadeContext dbContext)
            : base(dbContext)
        {

        }

        public IEnumerable<TipoCurso> Listar()
        {
            return GetAllReadOnly();
        }
    }
}
