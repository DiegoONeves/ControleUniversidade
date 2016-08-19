using DN.ControleUniversidade.Application.Interfaces;
using DN.ControleUniversidade.Application.ViewModels.TipoCurso;
using DN.ControleUniversidade.Domain.Interfaces.Services;
using DN.ControleUniversidade.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace DN.ControleUniversidade.Application
{
    public class TipoCursoAppService : AppServiceBase, ITipoCursoAppService
    {
        private readonly ITipoCursoService _tipoCursoService;

        public TipoCursoAppService(ITipoCursoService tipoCursoService, IUnitOfWork uow)
            :base(uow)
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
