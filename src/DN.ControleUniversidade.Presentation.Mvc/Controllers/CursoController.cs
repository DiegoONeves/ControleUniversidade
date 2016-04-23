using DN.ControleUniversidade.Application.Interfaces;
using DN.ControleUniversidade.Application.ViewModels.Curso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DN.ControleUniversidade.Presentation.Mvc.Controllers
{
    public class CursoController : Controller
    {
        private readonly ICursoAppService _cursoAppService;
        private readonly ITipoCursoAppService _tipoCursoAppService;
        public CursoController(ICursoAppService cursoAppService, ITipoCursoAppService tipoCursoAppService)
        {
            _cursoAppService = cursoAppService;
            _tipoCursoAppService = tipoCursoAppService;
        }

        public ActionResult Index()
        {
            var model = _cursoAppService.ListarGrid();
            return View(model);
        }

        public ActionResult Cadastrar()
        {
            var model = new NovoCursoViewModel();
            model.TiposCurso = PreencherTipoCurso();
            model.Ativo = false;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(NovoCursoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _cursoAppService.CadastrarNovoCurso(model);

                if (result.IsValid)
                    return RedirectToAction("Index");
                else
                {
                    foreach (var item in result.Erros)
                        ModelState.AddModelError("", item.Message);
                }

            }
            model.TiposCurso = PreencherTipoCurso();
            return View(model);
        }

        public ActionResult Editar(Guid cursoId)
        {
            var model = _cursoAppService.ObterParaEditar(cursoId);
            model.TiposCurso = PreencherTipoCurso();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(EdicaoCursoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _cursoAppService.EditarCurso(model);

                if (result.IsValid)
                    return RedirectToAction("Index");
                else
                {
                    foreach (var item in result.Erros)
                        ModelState.AddModelError("", item.Message);
                }

            }
            model.TiposCurso = PreencherTipoCurso();
            return View(model);
        }

        [OutputCache(Duration = 300, VaryByParam = "none")]
        [NonAction]
        private IEnumerable<SelectListItem> PreencherTipoCurso()
        {
            return _tipoCursoAppService.ListarTodos()
            .Select(x => new SelectListItem
            {
                Text = x.Descricao,
                Value = x.TipoCursoId.ToString()
            });
        }




    }
}