using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Repositories;
using DN.ControleUniversidade.Domain.Interfaces.Specification;
using DN.ControleUniversidade.Domain.Specification.CursoSpecification;
using DN.ControleUniversidade.Domain.Validation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Validation.CursoValidation
{
    public class CursoEstaConsistenteParaAtualizarValidation : FiscalBase<Curso>
    {
        public CursoEstaConsistenteParaAtualizarValidation(ICursoRepository cursoRepository)
        {
            var cursoDescricaoUnica = new PossuiMesmaDescricaoParaMesmoIdSpecification(cursoRepository);

            base.AdicionarRegra("DescricaoJaCadastrada", new Regra<Curso>(cursoDescricaoUnica, "Este curso já foi cadastrado na base de dados"));
        }
    }
}
