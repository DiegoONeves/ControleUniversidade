using DN.ControleUniversidade.Application.Interfaces;
using DN.ControleUniversidade.Application.Validation;
using DN.ControleUniversidade.Application.ViewModels.Aluno;
using DN.ControleUniversidade.Domain.Factories;
using DN.ControleUniversidade.Domain.Interfaces.Services;
using DN.ControleUniversidade.Infra.CrossCutting.Common.HelperTools;
using DN.ControleUniversidade.Infra.CrossCutting.Common.Security;
using DN.ControleUniversidade.Infra.Data.Interfaces;
using System;

namespace DN.ControleUniversidade.Application
{
    public class AlunoAppService : AppServiceBase, IAlunoAppService
    {
        private readonly IAlunoService _alunoService;

        public AlunoAppService(IAlunoService alunoService, IUnitOfWork uow)
            :base(uow)
        {
            _alunoService = alunoService;
        }
        public ValidationAppResult CadastrarNovoAluno(NovoAlunoViewModel novoAlunoViewModel)
        {
            BeginTransaction();

            var aluno = AlunoFactory.CriarAlunoParaCadastro(novoAlunoViewModel.Email, novoAlunoViewModel.Senha, EncryptHelper.Encrypt(novoAlunoViewModel.Senha), novoAlunoViewModel.Nome, CaracteresHelper.SomenteNumeros(novoAlunoViewModel.CPF), novoAlunoViewModel.DataNascimento, novoAlunoViewModel.Ativo);

            var resultadoValidacao = DomainToApplicationResult(_alunoService.AdicionarNovoAluno(aluno));

            if (resultadoValidacao.IsValid)
                Commit();

            return resultadoValidacao;
        }

        public void Dispose()
        {
            _alunoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
