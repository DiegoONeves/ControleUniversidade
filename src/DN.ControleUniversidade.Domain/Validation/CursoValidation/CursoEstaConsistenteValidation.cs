using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Repositories;
using DN.ControleUniversidade.Domain.Specification.CursoSpecification;
using DN.ControleUniversidade.Domain.Validation.Base;

namespace DN.ControleUniversidade.Domain.Validation.CursoValidation
{
    public class CursoEstaConsistenteValidation: FiscalBase<Curso>
    {
        public CursoEstaConsistenteValidation(ICursoRepository cursoRepository)
        {
            var cursoNomeUnico = new NomeDeveSerUnicaSpecification(cursoRepository);

            base.AdicionarRegra("NomeJaCadastrado", new Regra<Curso>(cursoNomeUnico, "Este curso já foi cadastrado na base de dados."));
        }
    }
}
