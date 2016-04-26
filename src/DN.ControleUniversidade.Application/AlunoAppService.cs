using DN.ControleUniversidade.Application.Interfaces;
using DN.ControleUniversidade.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.ControleUniversidade.Application.Validation;
using DN.ControleUniversidade.Application.ViewModels.Aluno;
using DN.ControleUniversidade.Domain.Interfaces.Services;
using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Infra.CrossCutting.Common.Security;
using DN.ControleUniversidade.Domain.ValueObjects;
using DN.ControleUniversidade.Infra.CrossCutting.Common.HelperTools;

namespace DN.ControleUniversidade.Application
{
    public class AlunoAppService : AppServiceBase<UniversidadeContext>, IAlunoAppService
    {
        private readonly IAlunoService _alunoService;

        public AlunoAppService(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }
        public ValidationAppResult CadastrarNovoAluno(NovoAlunoViewModel novoAlunoViewModel)
        {
            BeginTransaction();

            var usuario = new Usuario(novoAlunoViewModel.Email, novoAlunoViewModel.Senha, EncryptHelper.Encrypt(novoAlunoViewModel.Senha), TipoUsuario.Aluno);
            var aluno = new Aluno(novoAlunoViewModel.Nome, CaracteresHelper.SomenteNumeros(novoAlunoViewModel.CPF), novoAlunoViewModel.DataNascimento, novoAlunoViewModel.Ativo, usuario);
            aluno.AdicionarHistorico(new AlunoHistorico(aluno, SituacaoAluno.Cadastrado));

            var resultadoValidacao = DomainToApplicationResult(_alunoService.AdicionarNovoAluno(aluno));

            if (resultadoValidacao.IsValid)
                Commit();

            return resultadoValidacao;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
