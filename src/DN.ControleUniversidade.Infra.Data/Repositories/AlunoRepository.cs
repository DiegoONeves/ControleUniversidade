using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Repositories;
using DN.ControleUniversidade.Infra.Data.Context;
using System.Linq;

namespace DN.ControleUniversidade.Infra.Data.Repositories
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
    {
        public AlunoRepository(UniversidadeContext dbContext)
            : base(dbContext)
        {

        }
        public Aluno ObterPorCPF(string cpf)
        {
            return DbSet.FirstOrDefault(x => x.CPF == cpf);
        }

        public Aluno ObterPorEmail(string email)
        {
            return DbSet.FirstOrDefault(x => x.Usuario.Email == email);
        }
    }
}
