using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DN.ControleUniversidade.Infra.Data.Context
{
    public class UniversidadeContext: DbContext
    {
        public UniversidadeContext()
            : base("UniversidadeContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<TipoCurso> TiposCurso { get; set; }
        public IDbSet<Curso> Cursos { get; set; }
        public IDbSet<Usuario> Usuarios { get; set; }
        public IDbSet<Aluno> Alunos { get; set; }
        public IDbSet<AlunoHistorico> HistoricoAluno { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new TipoCursoConfiguration());
            modelBuilder.Configurations.Add(new CursoConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new AlunoConfiguration());
            modelBuilder.Configurations.Add(new AlunoHistoricoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
