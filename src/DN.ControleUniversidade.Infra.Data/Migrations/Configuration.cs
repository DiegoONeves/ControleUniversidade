namespace DN.ControleUniversidade.Infra.Data.Migrations
{
    using DN.ControleUniversidade.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DN.ControleUniversidade.Infra.Data.Context.UniversidadeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DN.ControleUniversidade.Infra.Data.Context.UniversidadeContext context)
        {
            if (!context.TiposCurso.Any(x => x.Descricao == "Bacharelado"))
            {
                context.TiposCurso.Add(new TipoCurso("Bacharelado", true));
                context.TiposCurso.Add(new TipoCurso("Tecnólogo", true));
                context.TiposCurso.Add(new TipoCurso("Técnico", true));
                context.SaveChanges();
            }
        }
    }
}
