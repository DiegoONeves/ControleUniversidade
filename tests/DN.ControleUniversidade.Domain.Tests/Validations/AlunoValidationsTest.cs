using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Repositories;
using DN.ControleUniversidade.Domain.Validation.AlunoValidation;
using DN.ControleUniversidade.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Tests.Validations
{
    [TestClass]
    public class AlunoValidationsTest
    {
        #region Cadastro

        [TestMethod]
        [TestCategory("Validations - Aluno - Cadastro")]
        public void Aluno_Com_CPF_Já_Cadastrado()
        {
            var usuario = new Usuario("diegoneves1989@gmail.com", "123456", "123456", TipoUsuario.Aluno);
            var aluno = new Aluno("DIEGO NEVES", "94514198455", new DateTime(1989, 5, 24), true, usuario);

            var stubRepo = MockRepository.GenerateStub<IAlunoRepository>();
            stubRepo.Stub(x => x.ObterPorCPF("94514198455")).Return(aluno);

            var alunoValidation = new AlunoEstaConsistenteParaCadastroValidation(stubRepo);
            var result = alunoValidation.Validar(aluno);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Erros.Any(x => x.Message == "Já existe um aluno com esse CPF."));
        }

        [TestMethod]
        [TestCategory("Validations - Aluno - Cadastro")]
        public void Aluno_Com_CPF_Não_Cadastrado()
        {
            var usuario = new Usuario("diegoneves1989@gmail.com", "123456", "123456", TipoUsuario.Aluno);
            var aluno = new Aluno("DIEGO NEVES", "94514198455", new DateTime(1989, 5, 24), true, usuario);

            var stubRepo = MockRepository.GenerateStub<IAlunoRepository>();
            stubRepo.Stub(x => x.ObterPorCPF("94514198453")).Return(aluno);

            var alunoValidation = new AlunoEstaConsistenteParaCadastroValidation(stubRepo);
            var result = alunoValidation.Validar(aluno);

            Assert.IsFalse(result.Erros.Any(x => x.Message == "Já existe um aluno com esse CPF."));
        }

        [TestMethod]
        [TestCategory("Validations - Aluno - Cadastro")]
        public void Aluno_Com_Email_Já_Cadastrado()
        {
            var usuario = new Usuario("diegoneves1989@gmail.com", "123456", "123456", TipoUsuario.Aluno);
            var aluno = new Aluno("DIEGO NEVES", "94514198455", new DateTime(1989, 5, 24), true, usuario);

            var stubRepo = MockRepository.GenerateStub<IAlunoRepository>();
            stubRepo.Stub(x => x.ObterPorEmail(aluno.Usuario.Email)).Return(aluno);

            var alunoValidation = new AlunoEstaConsistenteParaCadastroValidation(stubRepo);
            var result = alunoValidation.Validar(aluno);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Erros.Any(x => x.Message == "Já existe um aluno com esse e-mail."));
        }

        [TestMethod]
        [TestCategory("Validations - Aluno - Cadastro")]
        public void Aluno_Com_Email_Não_Cadastrado()
        {
            var usuario = new Usuario("diegoneves1989@gmail.com", "123456", "123456", TipoUsuario.Aluno);
            var aluno = new Aluno("DIEGO NEVES", "94514198455", new DateTime(1989, 5, 24), true, usuario);

            var stubRepo = MockRepository.GenerateStub<IAlunoRepository>();
            stubRepo.Stub(x => x.ObterPorEmail(aluno.Usuario.Email)).Return(null);

            var alunoValidation = new AlunoEstaConsistenteParaCadastroValidation(stubRepo);
            var result = alunoValidation.Validar(aluno);

            Assert.IsFalse(result.Erros.Any(x => x.Message == "Já existe um aluno com esse e-mail."));
        }



        #endregion Cadastro

        #region Alteração
        #endregion Alteração
    }
}
