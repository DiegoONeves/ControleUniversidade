using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Contracts.Specification;


namespace DN.ControleUniversidade.Domain.Specification.CursoSpecs
{
    public class DescricaoEstaValidaSpec : ISpecification<Curso>
    {
        public bool IsSatisfiedBy(Curso curso)
        {
            if (!string.IsNullOrEmpty(curso.Descricao))
            {
                return curso.Descricao.Length > 5 && curso.Descricao.Length < 50;
            }
            return false;
        }
    }
}
