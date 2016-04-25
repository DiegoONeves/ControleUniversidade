using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Repositories;
using DN.ControleUniversidade.Domain.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Specification.AlunoSpecification
{
    public class EmailAlunoDeveSerUnicoSpecification : ISpecification<Aluno>
    {
        private readonly IAlunoRepository _alunoRepository;

        public EmailAlunoDeveSerUnicoSpecification(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        public bool IsSatisfiedBy(Aluno aluno)
        {
            return _alunoRepository.ObterPorEmail(aluno.Usuario.Email) == null;
        }
    }
}
