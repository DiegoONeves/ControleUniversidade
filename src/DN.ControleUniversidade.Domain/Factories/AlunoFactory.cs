using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Factories
{
    public class AlunoFactory
    {
        public static Aluno CriarAlunoParaCadastro(string email, string senha, string SenhaCriptografada, string nome, string cpf, DateTime dataNascimento, bool ativo)
        {
            var usuario = new Usuario(email, senha, SenhaCriptografada, TipoUsuario.Aluno);
            var aluno = new Aluno(nome, cpf, dataNascimento, ativo, usuario);
            aluno.AdicionarHistorico(new AlunoHistorico(aluno, SituacaoAluno.Cadastrado));

            return aluno;
        }
    }
}
