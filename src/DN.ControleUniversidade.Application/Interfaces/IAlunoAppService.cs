using DN.ControleUniversidade.Application.Validation;
using DN.ControleUniversidade.Application.ViewModels.Aluno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Application.Interfaces
{
    public interface IAlunoAppService : IDisposable
    {
        ValidationAppResult CadastrarNovoAluno(NovoAlunoViewModel novoAlunoViewModel);
    }
}
