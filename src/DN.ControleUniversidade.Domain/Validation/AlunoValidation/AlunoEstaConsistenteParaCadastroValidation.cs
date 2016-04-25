using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Repositories;
using DN.ControleUniversidade.Domain.Specification.AlunoSpecification;
using DN.ControleUniversidade.Domain.Validation.Base;

namespace DN.ControleUniversidade.Domain.Validation.AlunoValidation
{
    public class AlunoEstaConsistenteParaCadastroValidation : FiscalBase<Aluno>
    {
        public AlunoEstaConsistenteParaCadastroValidation(IAlunoRepository alunoRepository)
        {
            var cpfAlunoUnico = new CPFDeveSerUnicoSpecification(alunoRepository);
            var emailUsuarioAlunoUnico = new EmailAlunoDeveSerUnicoSpecification(alunoRepository);

            base.AdicionarRegra("CPFAlunoUnico", new Regra<Aluno>(cpfAlunoUnico, "Já existe um aluno com esse CPF."));
            base.AdicionarRegra("EmailUsuarioAlunoUnico", new Regra<Aluno>(emailUsuarioAlunoUnico, "Já existe um aluno com esse e-mail."));
        }
    }
}
