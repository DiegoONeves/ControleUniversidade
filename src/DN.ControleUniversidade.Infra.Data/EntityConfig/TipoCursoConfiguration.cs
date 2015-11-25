using DN.ControleUniversidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Infra.Data.EntityConfig
{
    public class TipoCursoConfiguration : EntityTypeConfiguration<TipoCurso>
    {
        public TipoCursoConfiguration()
        {
            HasKey(x => x.TipoCursoId);

            Property(x => x.Descricao)
              .IsRequired()
              .HasMaxLength(100);
        }
    }
}
