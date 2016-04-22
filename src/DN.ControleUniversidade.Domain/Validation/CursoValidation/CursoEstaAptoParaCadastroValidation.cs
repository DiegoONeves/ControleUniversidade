using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Specification.CursoSpecification;
using DN.ControleUniversidade.Domain.Validation.Base;

namespace DN.ControleUniversidade.Domain.Validation.CursoValidation
{
    public class CursoEstaAptoParaCadastroValidation : FiscalBase<Curso>
    {
        public CursoEstaAptoParaCadastroValidation()
        {
            //Especificações de Curso
            var cursoDescricao = new DescricaoEstaValidaSpecification();

            base.AdicionarRegra("DescricaoInvalida", new Regra<Curso>(cursoDescricao, "A descrição deve conter entre 5 e 50 caracteres"));

        }
    }
}
