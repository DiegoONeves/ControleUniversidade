using DN.ControleUniversidade.Application.Validation;
using DN.ControleUniversidade.Application.ViewModels.Curso;
using System;
using System.Collections.Generic;

namespace DN.ControleUniversidade.Application.Interfaces
{
    public interface ICursoAppService : IDisposable
    {
        ValidationAppResult CadastrarNovoCurso(NovoCursoViewModel novoCursoViewModel);
        ValidationAppResult EditarCurso(EdicaoCursoViewModel cursoViewModel);
        EdicaoCursoViewModel ObterParaEditar(Guid cursoId);
        IEnumerable<GridCursoViewModel> ListarGrid();
    }
}
