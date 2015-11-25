using DN.ControleUniversidade.Application;
using DN.ControleUniversidade.Application.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Infra.CrossCutting.IoC
{
    public class NinjectAppModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITipoCursoAppService>().To<TipoCursoAppService>();
            Bind<ICursoAppService>().To<CursoAppService>();
        }
    }
}
