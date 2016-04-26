using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Interfaces.Services
{
    public interface ICursoService: IDisposable
    {
        ValidationResult AdicionarNovoCurso(Curso curso);
        ValidationResult AtualizarCurso(Curso curso);
        IEnumerable<Curso> ObterTodos();
        IEnumerable<Curso> ObterGrid();
        Curso ObterPorId(Guid cursoId);
        Curso ObterPorIdComDependencias(Guid cursoId);
    }
}
