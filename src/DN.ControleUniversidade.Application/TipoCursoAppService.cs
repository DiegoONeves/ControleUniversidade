using DN.ControleUniversidade.Application.Interfaces;
using DN.ControleUniversidade.Application.Mapper;
using DN.ControleUniversidade.Application.ViewModels;
using DN.ControleUniversidade.Domain.Contracts.Services;
using DN.ControleUniversidade.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Application
{
    public class TipoCursoAppService : AppServiceBase<UniversidadeContext>, ITipoCursoAppService
    {
        private readonly ITipoCursoService _tipoCursoService;

        public TipoCursoAppService(ITipoCursoService tipoCursoService)
        {
            _tipoCursoService = tipoCursoService;
        }

        public IEnumerable<TipoCursoViewModel> ObterTodos()
        {
            return TipoCursoMapper.ListTipoCursoParaListTipoCursoViewModel(_tipoCursoService.ObterTodos());
        }
    }
}
