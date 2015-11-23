using DN.ControleUniversidade.Application.Validation;
using DN.ControleUniversidade.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace DN.ControleUniversidade.Application.Interfaces
{
    public interface ICursoAppService : IDisposable
    {
        ValidationAppResult AdicionarNovoCurso(CursoViewModel cursoViewModel);

        ValidationAppResult AtualizarCurso(CursoViewModel cursoViewModel);

        IEnumerable<CursoViewModel> ObterTodos();
        CursoViewModel ObterCursoPorId(Guid cursoId);
    }
}
