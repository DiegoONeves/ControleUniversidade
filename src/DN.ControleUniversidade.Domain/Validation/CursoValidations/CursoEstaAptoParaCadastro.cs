using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Specification.CursoSpecs;
using DN.ControleUniversidade.Domain.Validation.Base;

namespace DN.ControleUniversidade.Domain.Validation.CursoValidations
{
    public class CursoEstaAptoParaCadastro : FiscalBase<Curso>
    {
        public CursoEstaAptoParaCadastro()
        {
            //Especificações de Curso
            var cursoDescricao = new DescricaoEstaValidaSpec();

            base.AdicionarRegra("DescricaoInvalida", new Regra<Curso>(cursoDescricao, "A descrição deve conter entre 5 e 50 caracteres"));

        }
    }
}
