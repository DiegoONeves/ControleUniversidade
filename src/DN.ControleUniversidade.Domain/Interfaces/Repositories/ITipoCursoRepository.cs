using DN.ControleUniversidade.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DN.ControleUniversidade.Domain.Interfaces.Repositories
{
    public interface ITipoCursoRepository : IRepositoryBase<TipoCurso>
    {
        IEnumerable<TipoCurso> Listar();
    }
}
