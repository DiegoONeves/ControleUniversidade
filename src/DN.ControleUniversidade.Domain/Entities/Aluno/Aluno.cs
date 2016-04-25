using DN.ControleUniversidade.Domain.Interfaces.Validation;
using DN.ControleUniversidade.Domain.Validation.AlunoValidation;
using DN.ControleUniversidade.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Entities
{
    public class Aluno : ISelfValidator
    {
        protected Aluno() { }
        public Aluno(string nome, string cpf, DateTime dataNascimento, bool ativo, Usuario usuario)
        {
            AlunoId = Guid.NewGuid();
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            DataCadastro = DateTime.Now;
            Historico = new List<AlunoHistorico>();
            Usuario = usuario;

            var fiscal = new AlunoEstaAptoParaCadastroValidation();
            ResultadoValidacao = fiscal.Validar(this);
        }
        public Guid AlunoId { get; protected set; }
        public string Nome { get; protected set; }
        public string CPF { get; protected set; }
        public virtual Usuario Usuario { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public DateTime DataAtualizacao { get; protected set; }
        public virtual ICollection<AlunoHistorico> Historico { get; protected set; }
        public ValidationResult ResultadoValidacao { get; private set; }

        public void AdicionarHistorico(AlunoHistorico alunoHistorico) => Historico.Add(alunoHistorico);


        public bool IsValid
        {
            get { return ResultadoValidacao.IsValid; }
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
