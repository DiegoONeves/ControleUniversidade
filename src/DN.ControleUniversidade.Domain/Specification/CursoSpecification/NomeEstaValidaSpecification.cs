using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Specification;


namespace DN.ControleUniversidade.Domain.Specification.CursoSpecification
{
    public class NomeEstaValidaSpecification : ISpecification<Curso>
    {
        public bool IsSatisfiedBy(Curso curso)
        {
            if (!string.IsNullOrEmpty(curso.Nome))
            {
                return curso.Nome.Length > 5 && curso.Nome.Length < 50;
            }
            return false;
        }
    }
}
