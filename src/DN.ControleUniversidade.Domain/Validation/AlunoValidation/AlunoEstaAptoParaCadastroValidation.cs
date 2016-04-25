using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Specification.AlunoSpecification;
using DN.ControleUniversidade.Domain.Validation.Base;

namespace DN.ControleUniversidade.Domain.Validation.AlunoValidation
{
    public class AlunoEstaAptoParaCadastroValidation : FiscalBase<Aluno>
    {
        public AlunoEstaAptoParaCadastroValidation()
        {
            //Aluno
            var alunoNome = new NomeDeveTerEntre3E50CaracteresSpecification();
            var alunoCPF = new CPFAlunoDeveSerValidoSpecification();
            var alunoMaiorDeIdade = new AlunoDeveSerMaiorDeIdadeSpecificiation();

            //Usuário
            var alunoEmail = new EmailAlunoDeveSerValidoSpecification();
            var alunoSenha = new SenhaAlunoDeveTerEntre6E20CaracteresSpecification();

            base.AdicionarRegra("AlunoNome", new Regra<Aluno>(alunoNome, "O nome do aluno deve ter entre 3 e 50 caracteres."));
            base.AdicionarRegra("AlunoCPF", new Regra<Aluno>(alunoCPF, "O CPF do aluno é inválido."));
            base.AdicionarRegra("AlunoMaiorDeIdade", new Regra<Aluno>(alunoMaiorDeIdade, "O aluno deve ser maior de idade."));
            base.AdicionarRegra("AlunoEmail", new Regra<Aluno>(alunoEmail, "O e-mail do aluno é inválido."));
            base.AdicionarRegra("AlunoSenha", new Regra<Aluno>(alunoSenha, "A senha deve deve ter entre 6 e 20 caracteres."));
        }
    }
}
