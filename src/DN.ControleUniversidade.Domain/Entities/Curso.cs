using DN.ControleUniversidade.Domain.Contracts.Validation;
using DN.ControleUniversidade.Domain.Validation.CursoValidations;
using DN.ControleUniversidade.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace DN.ControleUniversidade.Domain.Entities
{
    public class Curso : ISelfValidator
    {
        protected Curso() { }

        public Curso(string descricao, bool ativo, TipoCurso tipoCurso)
        {
            CursoId = Guid.NewGuid();
            Descricao = descricao;
            TipoCurso = tipoCurso;
            Ativo = ativo;
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;


            var fiscal = new CursoEstaAptoParaCadastro();
            ResultadoValidacao = fiscal.Validar(this);
        }

        public Curso(Guid id, string descricao, bool ativo, TipoCurso tipoCurso)
        {
            CursoId = id;
            Descricao = descricao;
            TipoCurso = tipoCurso;
            Ativo = ativo;
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;


            var fiscal = new CursoEstaAptoParaCadastro();
            ResultadoValidacao = fiscal.Validar(this);
        }

        public Guid CursoId { get; protected set; }
        public string Descricao { get; protected set; }
        public bool Ativo { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public DateTime DataAtualizacao { get; protected set; }
        public ValidationResult ResultadoValidacao { get; private set; }
        public virtual TipoCurso TipoCurso { get; set; }

        public bool IsValid
        {
            get { return ResultadoValidacao.IsValid; }
        }

        public void AtualizarCurso(string descricao, bool ativo, TipoCurso tipoCurso)
        {
            Descricao = descricao;
            Ativo = ativo;
            TipoCurso = tipoCurso;
            DataAtualizacao = DateTime.Now;

            var fiscal = new CursoEstaAptoParaAtualizacao();
            ResultadoValidacao = fiscal.Validar(this);
        }

    }
}
