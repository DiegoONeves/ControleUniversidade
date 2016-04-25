using DN.ControleUniversidade.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DN.ControleUniversidade.Infra.Data.EntityConfig
{
    public class AlunoConfiguration : EntityTypeConfiguration<Aluno>
    {
        public AlunoConfiguration()
        {
            ToTable("Aluno");
            HasKey(x => x.AlunoId);

            Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.CPF)
             .HasMaxLength(30)
             .IsRequired();

            HasRequired(x => x.Usuario)
                .WithMany(x => x.UsuariosAlunos)
                .Map(m => m.MapKey("UsuarioId"));

            Property(x => x.DataCadastro)
               .IsRequired();

            Property(x => x.DataNascimento)
                .IsRequired();

            Property(x => x.DataAtualizacao)
                .IsOptional();
        }
    }
}
