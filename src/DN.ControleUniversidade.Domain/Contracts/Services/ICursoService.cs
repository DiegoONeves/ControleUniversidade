using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Contracts.Services
{
    public interface ICursoService
    {
        ValidationResult AdicionarNovoCurso(Curso curso);
        ValidationResult AtualizarCurso(Guid cursoId, string descricao);
        IEnumerable<Curso> ObterTodos();
        Curso ObterPorId(Guid cursoId);
        void Dispose();
    }
}
