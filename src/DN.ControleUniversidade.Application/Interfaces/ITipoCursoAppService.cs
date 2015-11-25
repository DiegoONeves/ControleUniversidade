using DN.ControleUniversidade.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Application.Interfaces
{
    public interface ITipoCursoAppService
    {
        IEnumerable<TipoCursoViewModel> ObterTodos();
    }
}
