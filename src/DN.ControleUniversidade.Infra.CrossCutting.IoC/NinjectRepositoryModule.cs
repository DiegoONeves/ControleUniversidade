using DN.ControleUniversidade.Domain.Contracts.Repositories;
using DN.ControleUniversidade.Infra.Data.Repositories;
using Ninject.Modules;

namespace DN.ControleUniversidade.Infra.CrossCutting.IoC
{
    public class NinjectRepositoryModule: NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<,>));
            Bind<ICursoRepository>().To<CursoRepository>();
            Bind<ITipoCursoRepository>().To<TipoCursoRepository>();
        }
    }
}
