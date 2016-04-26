using DN.ControleUniversidade.Domain.Interfaces.Services;
using DN.ControleUniversidade.Domain.Services;
using Ninject.Modules;

namespace DN.ControleUniversidade.Infra.CrossCutting.IoC
{
    public class NinjectServiceModule: NinjectModule
    {
        public override void Load()
        {
            Bind<ITipoCursoService>().To<TipoCursoService>();
            Bind<ICursoService>().To<CursoService>();
            Bind<IAlunoService>().To<AlunoService>();
        }
    }
}
