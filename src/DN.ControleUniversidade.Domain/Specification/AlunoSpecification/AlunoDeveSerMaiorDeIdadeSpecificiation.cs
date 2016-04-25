using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Specification;
using System;

namespace DN.ControleUniversidade.Domain.Specification.AlunoSpecification
{
    public class AlunoDeveSerMaiorDeIdadeSpecificiation : ISpecification<Aluno>
    {
        public bool IsSatisfiedBy(Aluno aluno)
        {

            var timeSpan = DateTime.Now.Subtract(aluno.DataNascimento);
            if (timeSpan.Days >= 365)
            {
                var idade = (new DateTime() + timeSpan).AddYears(-1).AddDays(-1);
                return idade.Year >= 18;
            }
            return false;
        }
    }
}
