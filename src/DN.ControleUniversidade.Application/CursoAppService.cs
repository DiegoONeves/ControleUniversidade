using DN.ControleUniversidade.Application.Interfaces;
using DN.ControleUniversidade.Application.Mapper;
using DN.ControleUniversidade.Application.Validation;
using DN.ControleUniversidade.Application.ViewModels;
using DN.ControleUniversidade.Domain.Interfaces.Services;
using DN.ControleUniversidade.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Application
{
    public class CursoAppService : AppServiceBase<UniversidadeContext>, ICursoAppService
    {
        private readonly ICursoService _cursoService;
        private readonly ITipoCursoService _tipoCursoService;

        public CursoAppService(ICursoService cursoService, ITipoCursoService tipoCursoService)
        {
            _cursoService = cursoService;
            _tipoCursoService = tipoCursoService;
        }
        public ValidationAppResult AdicionarNovoCurso(CursoViewModel cursoViewModel)
        {
            var tipoCursoDb = _tipoCursoService.ObterPorId(cursoViewModel.TipoCursoId);
            var cursoDomain = CursoMapper.CursoViewModelParaCursoDomain(cursoViewModel, tipoCursoDb);

            BeginTransaction();

            var validationAppResult = DomainToApplicationResult(_cursoService.AdicionarNovoCurso(cursoDomain));

            if (validationAppResult.IsValid)
                Commit();

            return validationAppResult;    
        }

        public IEnumerable<CursoViewModel> ObterTodos()
        {
            var cursosDb = _cursoService.ObterTodos();

            return CursoMapper.ListCursoParaListCursoViewModel(cursosDb);
          
        }

        public CursoViewModel ObterCursoPorId(Guid cursoId) 
        {
            var cursoDb = _cursoService.ObterPorId(cursoId);

            return CursoMapper.CursoDomainParaCursoViewModel(cursoDb);
        }

        public void Dispose()
        {
            _cursoService.Dispose();
            GC.SuppressFinalize(this);
        }


        public ValidationAppResult AtualizarCurso(CursoViewModel cursoViewModel)
        {
            BeginTransaction();
            var cursoDomain = CursoMapper.CursoViewModelParaCursoDomain(cursoViewModel, null);

            var validationAppResult = DomainToApplicationResult(_cursoService.AtualizarCurso(cursoDomain));

            if (validationAppResult.IsValid)
                Commit();

            return validationAppResult;  
        }
    }
}
