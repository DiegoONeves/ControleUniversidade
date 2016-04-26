using DN.ControleUniversidade.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DN.ControleUniversidade.Infra.Data.EntityConfig
{
    public class CursoConfiguration : EntityTypeConfiguration<Curso>
    {
        public CursoConfiguration()
        {
            ToTable("Curso");
            HasKey(x => x.CursoId);

            Property(x => x.Nome)
              .IsRequired()
              .HasMaxLength(100);

            Property(x => x.DataCadastro)
                .IsRequired();

            Property(x => x.DataAtualizacao)
                .IsOptional();

            HasRequired(x => x.TipoCurso)
             .WithMany(x => x.CursoLista)
              .Map(m => m.MapKey("TipoCursoId"));

            Ignore(x => x.ResultadoValidacao);

            ToTable("Curso");
        }
    }
}
