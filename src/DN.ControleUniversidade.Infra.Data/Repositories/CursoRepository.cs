using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Contracts.Repositories;
using DN.ControleUniversidade.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Infra.Data.Repositories
{
    public class CursoRepository : RepositoryBase<Curso, UniversidadeContext>, ICursoRepository
    {
        public Curso ObterPorDescricao(string descricao)
        {
            return Find(x => x.Descricao == descricao).FirstOrDefault();
        }
    }
}
