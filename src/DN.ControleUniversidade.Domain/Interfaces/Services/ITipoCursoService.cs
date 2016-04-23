using DN.ControleUniversidade.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DN.ControleUniversidade.Domain.Interfaces.Services
{
    public interface ITipoCursoService : IDisposable
    {
        IEnumerable<TipoCurso> ObterTodos();
        IEnumerable<TipoCurso> Listar();
        TipoCurso ObterPorId(Guid id);
    }
}
