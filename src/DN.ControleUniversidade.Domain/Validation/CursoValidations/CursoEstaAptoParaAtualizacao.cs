using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Contracts.Repositories;
using DN.ControleUniversidade.Domain.Specification.CursoSpecs;
using DN.ControleUniversidade.Domain.Validation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Validation.CursoValidations
{
    public class CursoEstaAptoParaAtualizacao : FiscalBase<Curso>
    {
        public CursoEstaAptoParaAtualizacao()
        {
            //Especificações de Curso
            var cursoDescricao = new DescricaoEstaValidaSpec();

            base.AdicionarRegra("DescricaoInvalida", new Regra<Curso>(cursoDescricao, "A descrição deve conter entre 5 e 50 caracteres"));
        }
    }
}
