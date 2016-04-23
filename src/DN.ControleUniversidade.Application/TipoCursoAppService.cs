using DN.ControleUniversidade.Application.Interfaces;
using DN.ControleUniversidade.Domain.Interfaces.Services;
using DN.ControleUniversidade.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.ControleUniversidade.Application.ViewModels.TipoCurso;

namespace DN.ControleUniversidade.Application
{
    public class TipoCursoAppService : AppServiceBase<UniversidadeContext>, ITipoCursoAppService
    {
        private readonly ITipoCursoService _tipoCursoService;

        public TipoCursoAppService(ITipoCursoService tipoCursoService)
        {
            _tipoCursoService = tipoCursoService;
        }

        public void Dispose()
        {
            _tipoCursoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TipoCursoViewModel> ListarTodos()
        {
            var tipos = _tipoCursoService.Listar();
            var viewModels = new List<TipoCursoViewModel>();
            foreach (var item in tipos)
            {
                viewModels.Add(new TipoCursoViewModel {
                    TipoCursoId = item.TipoCursoId,
                    Descricao = item.Descricao
                });
            }

            return viewModels;
        }
    }
}
