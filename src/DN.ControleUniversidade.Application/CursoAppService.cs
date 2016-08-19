using DN.ControleUniversidade.Application.Interfaces;
using DN.ControleUniversidade.Application.Validation;
using DN.ControleUniversidade.Domain.Interfaces.Services;
using DN.ControleUniversidade.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.ControleUniversidade.Application.ViewModels.Curso;
using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Infra.Data.Interfaces;

namespace DN.ControleUniversidade.Application
{
    public class CursoAppService : AppServiceBase, ICursoAppService
    {
        private readonly ICursoService _cursoService;
        private readonly ITipoCursoService _tipoCursoService;

        public CursoAppService(ICursoService cursoService, ITipoCursoService tipoCursoService, IUnitOfWork uow)
            :base(uow)
        {
            _cursoService = cursoService;
            _tipoCursoService = tipoCursoService;
        }

        public ValidationAppResult CadastrarNovoCurso(NovoCursoViewModel novoCursoViewModel)
        {
            var resultadoValidacao = new ValidationAppResult();
            BeginTransaction();

            var novoCurso = new Curso(novoCursoViewModel.Nome, novoCursoViewModel.Ativo, _tipoCursoService.ObterPorId(novoCursoViewModel.TipoCursoId));

            resultadoValidacao = DomainToApplicationResult(_cursoService.AdicionarNovoCurso(novoCurso));

            if (resultadoValidacao.IsValid)
                Commit();

            return resultadoValidacao;
        }

        public ValidationAppResult EditarCurso(EdicaoCursoViewModel cursoViewModel)
        {
            BeginTransaction();
            var curso = _cursoService.ObterPorId(cursoViewModel.CursoId);
            var tipoCurso = _tipoCursoService.ObterPorId(cursoViewModel.TipoCursoId);
            curso.AtualizarCurso(cursoViewModel.Nome, cursoViewModel.Ativo, tipoCurso);

            var validationAppResult = DomainToApplicationResult(_cursoService.AtualizarCurso(curso));

            if (validationAppResult.IsValid)
                Commit();

            return validationAppResult;
        }
        public IEnumerable<GridCursoViewModel> ListarGrid()
        {
            var cursos = _cursoService.ObterGrid();
            var viewModels = new List<GridCursoViewModel>();
            foreach (var item in cursos)
            {
                viewModels.Add(new GridCursoViewModel {
                    CursoId = item.CursoId,
                    Nome = item.Nome,
                    DataCadastro = item.DataCadastro,
                    Ativo = item.Ativo,
                    TipoCurso = item.TipoCurso.Descricao
                });
            }

            return viewModels;
        }
        public EdicaoCursoViewModel ObterParaEditar(Guid id)
        {
            var curso = _cursoService.ObterPorIdComDependencias(id);

            var cursoViewModel = new EdicaoCursoViewModel
            {
                CursoId = curso.CursoId,
                Nome = curso.Nome,
                TipoCursoId = curso.TipoCurso.TipoCursoId,
                Ativo = curso.Ativo
            };

            return cursoViewModel;
        }
        public void Dispose()
        {
            _cursoService.Dispose();
            _tipoCursoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
