using DN.ControleUniversidade.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DN.ControleUniversidade.Domain.Contracts.Services
{
    public interface ITipoCursoService
    {
        IEnumerable<TipoCurso> ObterTodos();
        TipoCurso ObterPorId(Guid id);
    }
}
