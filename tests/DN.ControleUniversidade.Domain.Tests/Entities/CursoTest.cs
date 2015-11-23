using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DN.ControleUniversidade.Domain.Entities;
using System.Linq;

namespace DN.ControleUniversidade.Domain.Tests.Entities
{
    [TestClass]
    public class CursoTest
    {
       

        [TestMethod]
        [TestCategory("Entity - Curso")]
        public void DescricaoDeveTerEntre5e50Caracteres() 
        {
            string validacaoEsperada = "A descrição deve conter entre 5 e 50 caracteres";
            var curso = new Curso("mater");


            string validacaoQuebrada = curso.ResultadoValidacao.Erros.FirstOrDefault(x => x.Message == validacaoEsperada).Message;

            Assert.AreEqual(validacaoEsperada, validacaoQuebrada);
        }


        [TestMethod]
        [TestCategory("Entity - Curso")]
        public void Na_Atualizacao_Do_Curso_Deve_Alterar_DataAtualizacao()
        {
            var curso = new Curso("Ciências da Computação");
            DateTime dataAtuzalicaoCriacao = curso.DataAtualizacao;
            System.Threading.Thread.Sleep(2000);
            curso.AtualizarCurso("Novo Nome de Curso");

            Assert.IsTrue(dataAtuzalicaoCriacao != curso.DataAtualizacao);
        }
    }
}
