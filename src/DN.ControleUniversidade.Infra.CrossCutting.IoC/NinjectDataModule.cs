using DN.ControleUniversidade.Infra.Data.Context;
using DN.ControleUniversidade.Infra.Data.Interfaces;
using DN.ControleUniversidade.Infra.Data.UnitOfWork;
using Ninject.Modules;

namespace DN.ControleUniversidade.Infra.CrossCutting.IoC
{
    public class NinjectDataModule: NinjectRepositoryModule
    {
        public override void Load()
        {
            Bind(typeof(IContextManager<>)).To(typeof(ContextManager<>));
            Bind<IDbContext>().To<UniversidadeContext>();
            Bind(typeof(IUnitOfWork<>)).To(typeof(UnitOfWork<>));
        }
    }
}
