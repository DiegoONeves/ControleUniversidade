using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Repositories;
using DN.ControleUniversidade.Domain.Specification.CursoSpecification;
using DN.ControleUniversidade.Domain.Validation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Validation.CursoValidation
{
    public class CursoEstaAptoParaAtualizacaoValidation : FiscalBase<Curso>
    {
        public CursoEstaAptoParaAtualizacaoValidation()
        {
            //Especificações de Curso
            var cursoDescricao = new DescricaoEstaValidaSpecification();

            base.AdicionarRegra("DescricaoInvalida", new Regra<Curso>(cursoDescricao, "A descrição deve conter entre 5 e 50 caracteres"));
        }
    }
}
