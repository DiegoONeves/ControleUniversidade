using DN.ControleUniversidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            ToTable("Usuario");
            HasKey(x => x.UsuarioId);
            Property(x => x.Email)
                .HasMaxLength(100)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_USUARIO_EMAIL")
                {
                    IsUnique = true
                }))
                .IsRequired();
            Property(x => x.Senha)
                .IsRequired()
                .HasMaxLength(32)
                .IsFixedLength();
            Property(x => x.TipoUsuario)
                .IsRequired();
            Ignore(x => x.SenhaCriptografada);
        }
    }
}
