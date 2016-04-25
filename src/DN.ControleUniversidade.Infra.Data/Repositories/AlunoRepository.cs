using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Repositories;
using DN.ControleUniversidade.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Infra.Data.Repositories
{
    public class AlunoRepository : RepositoryBase<Aluno, UniversidadeContext>, IAlunoRepository
    {
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
