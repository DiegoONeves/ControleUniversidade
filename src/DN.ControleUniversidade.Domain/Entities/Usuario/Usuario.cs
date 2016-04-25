using DN.ControleUniversidade.Domain.Interfaces.Validation;
using DN.ControleUniversidade.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Entities
{
    public class Usuario
    {
        protected Usuario() { }
        public Usuario(string email, string senha, string senhaCriptografada, TipoUsuario tipoUsuario)
        {
            UsuarioId = Guid.NewGuid();
            Email = email;
            Senha = senha;
            SenhaCriptografada = senhaCriptografada;
            TipoUsuario = tipoUsuario;
            DataCadastro = DateTime.Now;
        }
        public Guid UsuarioId { get; protected set; }
        public string Email { get; protected set; }
        public string Senha { get; protected set; }
        public string SenhaCriptografada { get; protected set; }
        public bool Ativo { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public TipoUsuario TipoUsuario { get; protected set; }
        public ICollection<Aluno> UsuariosAlunos { get; protected set; }

        public override string ToString()
        {
            return Email;
        }
    }
}
