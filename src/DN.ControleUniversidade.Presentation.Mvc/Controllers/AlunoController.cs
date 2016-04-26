using DN.ControleUniversidade.Application.Interfaces;
using DN.ControleUniversidade.Application.ViewModels.Aluno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DN.ControleUniversidade.Presentation.Mvc.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoAppService _alunoAppService;

        public AlunoController(IAlunoAppService alunoAppService)
        {
            _alunoAppService = alunoAppService;
        }
        // GET: Aluno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(NovoAlunoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _alunoAppService.CadastrarNovoAluno(model);

                if (result.IsValid)
                    return RedirectToAction("Index");
                else
                {
                    foreach (var item in result.Erros)
                        ModelState.AddModelError("", item.Message);
                }

            }
            return View(model);
        }

    }
}