using DN.ControleUniversidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Interfaces.Repositories
{
    public interface IAlunoRepository : IRepositoryBase<Aluno>
    {
        Aluno ObterPorCPF(string cpf);
        Aluno ObterPorEmail(string email);
    }
}
