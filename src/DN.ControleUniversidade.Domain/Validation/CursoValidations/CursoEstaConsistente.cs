using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Contracts.Repositories;
using DN.ControleUniversidade.Domain.Specification.CursoSpecs;
using DN.ControleUniversidade.Domain.Validation.Base;

namespace DN.ControleUniversidade.Domain.Validation.CursoValidations
{
    public class CursoEstaConsistente: FiscalBase<Curso>
    {
        public CursoEstaConsistente(ICursoRepository cursoRepository)
        {
            var cursoDescricaoUnica = new DescricaoDeveSerUnicaSpec(cursoRepository);

            base.AdicionarRegra("DescricaoJaCadastrada", new Regra<Curso>(cursoDescricaoUnica, "Este curso já foi cadastrado na base de dados"));
        }
    }
}
