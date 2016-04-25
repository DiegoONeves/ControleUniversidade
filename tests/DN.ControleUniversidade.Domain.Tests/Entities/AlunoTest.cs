using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Tests.Entities
{
    [TestClass]
    public class AlunoTest
    {
        #region Cadastro

        [TestMethod]
        [TestCategory("Entity - Aluno - Cadastro")]
        public void Aluno_Deve_Ter_Nome_Com_Mais_De_50_Caracteres()
        {
            var usuario = new Usuario("", "", "", TipoUsuario.Aluno);
            var aluno = new Aluno("PEDRO JORGE CAMARGO PEREIRA DE CASTRO ALVES DA SILVA SAURO FERNANDEZ DE MELO REGO COM BATATAS E FRITAS E MUITA COCA COLA", "00000000000", new DateTime(1989, 5, 24), true, usuario);

            Assert.IsFalse(aluno.IsValid);
            Assert.IsTrue(aluno.ResultadoValidacao.Erros.Any(x => x.Message == "O nome do aluno deve ter entre 3 e 50 caracteres."));
        }

        [TestMethod]
        [TestCategory("Entity - Aluno - Cadastro")]
        public void Aluno_Deve_Ter_Nome_Com_Menos_De_3_Caracteres()
        {
            var usuario = new Usuario("", "", "", TipoUsuario.Aluno);
            var aluno = new Aluno("PE", "00000000000", new DateTime(1989, 5, 24), true, usuario);

            Assert.IsFalse(aluno.IsValid);
            Assert.IsTrue(aluno.ResultadoValidacao.Erros.Any(x => x.Message == "O nome do aluno deve ter entre 3 e 50 caracteres."));
        }

        [TestMethod]
        [TestCategory("Entity - Aluno - Cadastro")]
        public void Aluno_Deve_Ter_CPF_Inválido()
        {
            var usuario = new Usuario("", "", "", TipoUsuario.Aluno);
            var aluno = new Aluno("DIEGO NEVES", "22211121111", new DateTime(1989, 5, 24), true, usuario);

            Assert.IsFalse(aluno.IsValid);
            Assert.IsTrue(aluno.ResultadoValidacao.Erros.Any(x => x.Message == "O CPF do aluno é inválido."));
        }

        [TestMethod]
        [TestCategory("Entity - Aluno - Cadastro")]
        public void Aluno_Deve_Ter_CPF_Válido()
        {
            var usuario = new Usuario("", "", "", TipoUsuario.Aluno);
            var aluno = new Aluno("DIEGO NEVES", "66823100990", new DateTime(1989, 5, 24), true, usuario);

            Assert.IsFalse(aluno.ResultadoValidacao.Erros.Any(x => x.Message == "O CPF do aluno é inválido."));
        }

        [TestMethod]
        [TestCategory("Entity - Aluno - Cadastro")]
        public void Aluno_Deve_Ter_Senha_Com_Mais_De_20_Caracteres()
        {
            var usuario = new Usuario("diegoneves1989@gmail.com", "senha222JHDSSSER@3###!@!1ssd23223232", "", TipoUsuario.Aluno);
            var aluno = new Aluno("DIEGO NEVES", "66823100990", new DateTime(1989, 5, 24), true, usuario);

            Assert.IsFalse(aluno.IsValid);
            Assert.IsTrue(aluno.ResultadoValidacao.Erros.Any(x => x.Message == "A senha deve deve ter entre 6 e 20 caracteres."));
        }

        [TestMethod]
        [TestCategory("Entity - Aluno - Cadastro")]
        public void Aluno_Deve_Ter_Senha_Com_Menos_De_6_Caracteres()
        {
            var usuario = new Usuario("diegoneves1989@gmail.com", "12234", "", TipoUsuario.Aluno);
            var aluno = new Aluno("DIEGO NEVES", "66823100990", new DateTime(1989, 5, 24), true, usuario);

            Assert.IsFalse(aluno.IsValid);
            Assert.IsTrue(aluno.ResultadoValidacao.Erros.Any(x => x.Message == "A senha deve deve ter entre 6 e 20 caracteres."));
        }

        [TestMethod]
        [TestCategory("Entity - Aluno - Cadastro")]
        public void Aluno_Deve_Ter_Senha_Com_6_Caracteres()
        {
            var usuario = new Usuario("diegoneves1989@gmail.com", "senha1", "", TipoUsuario.Aluno);
            var aluno = new Aluno("DIEGO NEVES", "66823100990", new DateTime(1989, 5, 24), true, usuario);

            Assert.IsTrue(aluno.Usuario.Senha.Length == 6);
            Assert.IsFalse(aluno.ResultadoValidacao.Erros.Any(x => x.Message == "A senha deve deve ter entre 6 e 20 caracteres."));
        }

        [TestMethod]
        [TestCategory("Entity - Aluno - Cadastro")]
        public void Aluno_Deve_Ter_Senha_Com_20_Caracteres()
        {
            var usuario = new Usuario("diegoneves1989@gmail.com", "12345678901234567890", "", TipoUsuario.Aluno);
            var aluno = new Aluno("DIEGO NEVES", "66823100990", new DateTime(1989, 5, 24), true, usuario);

            Assert.IsTrue(aluno.Usuario.Senha.Length == 20);
            Assert.IsFalse(aluno.ResultadoValidacao.Erros.Any(x => x.Message == "A senha deve deve ter entre 6 e 20 caracteres."));
        }

        [TestMethod]
        [TestCategory("Entity - Aluno - Cadastro")]
        public void Aluno_Deve_Ter_Email_Inválido()
        {
            var usuario = new Usuario("892jhhhd", "123456", "123456", TipoUsuario.Aluno);
            var aluno = new Aluno("DIEGO NEVES", "00000000000", new DateTime(1989, 5, 24), true, usuario);

            Assert.IsFalse(aluno.IsValid);
            Assert.IsTrue(aluno.ResultadoValidacao.Erros.Any(x => x.Message == "O e-mail do aluno é inválido."));
        }

        [TestMethod]
        [TestCategory("Entity - Aluno - Cadastro")]
        public void Aluno_Deve_Ter_Email_Válido()
        {
            var usuario = new Usuario("diegoneves1989@gmail.com", "123456", "123456", TipoUsuario.Aluno);
            var aluno = new Aluno("DIEGO NEVES", "00000000000", new DateTime(1989, 5, 24), true, usuario);

            Assert.IsFalse(aluno.ResultadoValidacao.Erros.Any(x => x.Message == "O e-mail do aluno é inválido."));
        }

        [TestMethod]
        [TestCategory("Entity - Aluno - Cadastro")]
        public void Aluno_Deve_Ser_Menor_De_Idade()
        {
            var usuario = new Usuario("892jhhhd", "123456", "123456", TipoUsuario.Aluno);
            var aluno = new Aluno("DIEGO NEVES", "00000000000", new DateTime(2015, 5, 24), true, usuario);

            Assert.IsTrue(aluno.ResultadoValidacao.Erros.Any(x => x.Message == "O aluno deve ser maior de idade."));
        }

        [TestMethod]
        [TestCategory("Entity - Aluno - Cadastro")]
        public void Aluno_Deve_Ser_Maior_De_Idade()
        {
            var usuario = new Usuario("892jhhhd", "123456", "123456", TipoUsuario.Aluno);
            var aluno = new Aluno("DIEGO NEVES", "00000000000", new DateTime(1989, 5, 24), true, usuario);

            Assert.IsFalse(aluno.ResultadoValidacao.Erros.Any(x => x.Message == "O aluno deve ser maior de idade."));
        }

        #endregion Cadastro

        #region Alteração
        #endregion
    }
}
