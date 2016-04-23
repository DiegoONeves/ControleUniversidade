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
            var cursoNome = new NomeEstaValidaSpecification();

            base.AdicionarRegra("NomeInvalido", new Regra<Curso>(cursoNome, "O nome deve conter entre 5 e 50 caracteres."));

        }
    }
}
