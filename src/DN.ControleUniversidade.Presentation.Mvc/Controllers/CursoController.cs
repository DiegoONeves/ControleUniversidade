using DN.ControleUniversidade.Application.Interfaces;
using DN.ControleUniversidade.Application.ViewModels;
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
        // GET: Curso
        public ActionResult Index()
        {
            var cursos = _cursoAppService.ObterTodos();
            return View(cursos);
        }

        [OutputCache(Duration = 300, VaryByParam = "none")]
        [NonAction]
        private IEnumerable<SelectListItem> PreencherTipoCurso()
        {
            return _tipoCursoAppService.ObterTodos()
            .Select(x => new SelectListItem
            {
                Text = x.Descricao,
                Value = x.TipoCursoId.ToString()
            });
        }

        public ActionResult Cadastrar()
        {
            var model = new CursoViewModel();
            model.TiposCurso = PreencherTipoCurso();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(CursoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var validationAppResult = _cursoAppService.AdicionarNovoCurso(model);

                foreach (var item in validationAppResult.Erros)
                    ModelState.AddModelError("", item.Message);

                if (validationAppResult.Erros.Count == 0)
                    return RedirectToAction("Index");
            }

            model.TiposCurso = PreencherTipoCurso();
            return View(model);
        }

        public ActionResult Editar(Guid cursoId)
        {
            var cursoParaEdicao = _cursoAppService.ObterCursoPorId(cursoId);
            return View(cursoParaEdicao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CursoViewModel curso)
        {
            if (ModelState.IsValid)
            {
                var validationAppResult = _cursoAppService.AtualizarCurso(curso);

                foreach (var item in validationAppResult.Erros)
                    ModelState.AddModelError("", item.Message);

                if (validationAppResult.Erros.Count == 0)
                    return RedirectToAction("Index");
            }
            return View(curso);
        }
    }
}