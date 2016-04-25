using DN.ControleUniversidade.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DN.ControleUniversidade.Infra.Data.EntityConfig
{
    public class AlunoHistoricoConfiguration : EntityTypeConfiguration<AlunoHistorico>
    {
        public AlunoHistoricoConfiguration()
        {
            ToTable("AlunoHistorico");
            HasKey(x => x.AlunoHistoricoId);

            HasRequired(x => x.Aluno)
                .WithMany(x => x.Historico)
                .Map(m => m.MapKey("AlunoId"));

            Property(x => x.SituacaoAluno)
                .IsRequired();

            Property(x => x.DataCadastro)
                .IsRequired();

        }
    }
}
