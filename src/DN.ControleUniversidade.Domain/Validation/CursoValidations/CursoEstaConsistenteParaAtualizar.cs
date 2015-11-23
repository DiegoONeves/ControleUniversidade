using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Contracts.Repositories;
using DN.ControleUniversidade.Domain.Contracts.Specification;
using DN.ControleUniversidade.Domain.Specification.CursoSpecs;
using DN.ControleUniversidade.Domain.Validation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Validation.CursoValidations
{
    public class CursoEstaConsistenteParaAtualizar : FiscalBase<Curso>
    {
        public CursoEstaConsistenteParaAtualizar(ICursoRepository cursoRepository)
        {
            var cursoDescricaoUnica = new PossuiMesmaDescricaoParaMesmoIdSpec(cursoRepository);

            base.AdicionarRegra("DescricaoJaCadastrada", new Regra<Curso>(cursoDescricaoUnica, "Este curso já foi cadastrado na base de dados"));
        }
    }
}
