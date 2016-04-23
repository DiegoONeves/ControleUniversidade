using DN.ControleUniversidade.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DN.ControleUniversidade.Infra.Data.EntityConfig
{
    public class CursoConfiguration : EntityTypeConfiguration<Curso>
    {
        public CursoConfiguration()
        {
            HasKey(x => x.CursoId);

            Property(x => x.Nome)
              .IsRequired()
              .HasMaxLength(100);

            Property(x => x.DataCadastro)
                .IsRequired();

            HasRequired(x => x.TipoCurso)
             .WithMany(x => x.CursoLista)
              .Map(m => m.MapKey("TipoCursoId"));

            Ignore(x => x.ResultadoValidacao);

            ToTable("Curso");
        }
    }
}
