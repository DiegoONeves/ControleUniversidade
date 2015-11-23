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
        private readonly ICursoAppService _cursoApp;
        public CursoController(ICursoAppService cursoApp)
        {
            _cursoApp = cursoApp;
        }
        // GET: Curso
        public ActionResult Index()
        {
            var cursos = _cursoApp.ObterTodos();
            return View(cursos);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(CursoViewModel curso)
        {
            if (ModelState.IsValid)
            {
                var validationAppResult = _cursoApp.AdicionarNovoCurso(curso);

                foreach (var item in validationAppResult.Erros)
                    ModelState.AddModelError("", item.Message);

                if (validationAppResult.Erros.Count == 0)
                    return RedirectToAction("Index");
            }
            return View(curso);
        }

        public ActionResult Editar(Guid cursoId)
        {
            var cursoParaEdicao = _cursoApp.ObterCursoPorId(cursoId);
            return View(cursoParaEdicao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CursoViewModel curso)
        {
            if (ModelState.IsValid)
            {
                var validationAppResult = _cursoApp.AtualizarCurso(curso);

                foreach (var item in validationAppResult.Erros)
                    ModelState.AddModelError("", item.Message);

                if (validationAppResult.Erros.Count == 0)
                    return RedirectToAction("Index");
            }
            return View(curso);
        }
    }
}