using DN.ControleUniversidade.Domain.Interfaces.Validation;
using DN.ControleUniversidade.Domain.Validation.CursoValidation;
using DN.ControleUniversidade.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace DN.ControleUniversidade.Domain.Entities
{
    public class Curso : ISelfValidator
    {
        protected Curso() { }

        public Curso(string nome, bool ativo, TipoCurso tipoCurso)
        {
            CursoId = Guid.NewGuid();
            Nome = nome;
            TipoCurso = tipoCurso;
            Ativo = ativo;
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;


            var fiscal = new CursoEstaAptoParaCadastroValidation();
            ResultadoValidacao = fiscal.Validar(this);
        }

        public Curso(Guid id, string nome, bool ativo, TipoCurso tipoCurso)
        {
            CursoId = id;
            Nome = nome;
            TipoCurso = tipoCurso;
            Ativo = ativo;
            DataCadastro = DateTime.Now;


            var fiscal = new CursoEstaAptoParaCadastroValidation();
            ResultadoValidacao = fiscal.Validar(this);
        }

        public Guid CursoId { get; protected set; }
        public string Nome { get; protected set; }
        public bool Ativo { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public DateTime DataAtualizacao { get; protected set; }
        public ValidationResult ResultadoValidacao { get; private set; }
        public virtual TipoCurso TipoCurso { get; set; }

        public bool IsValid
        {
            get { return ResultadoValidacao.IsValid; }
        }

        public void AtualizarCurso(string nome, bool ativo, TipoCurso tipoCurso)
        {
            Nome = nome;
            Ativo = ativo;
            TipoCurso = tipoCurso;
            DataAtualizacao = DateTime.Now;

            var fiscal = new CursoEstaAptoParaAtualizacaoValidation();
            ResultadoValidacao = fiscal.Validar(this);
        }

    }
}
