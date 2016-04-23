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
        public void NomeDeveTerEntre5e50Caracteres() 
        {
            string validacaoEsperada = "A descrição deve conter entre 5 e 50 caracteres";
            var tipoCurso = new TipoCurso("Tecnólogo", true);
            var curso = new Curso("mater", true, tipoCurso);


            string validacaoQuebrada = curso.ResultadoValidacao.Erros.FirstOrDefault(x => x.Message == validacaoEsperada).Message;

            Assert.AreEqual(validacaoEsperada, validacaoQuebrada);
        }

    }
}
