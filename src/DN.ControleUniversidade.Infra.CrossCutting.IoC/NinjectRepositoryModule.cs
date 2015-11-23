using DN.ControleUniversidade.Application;
using DN.ControleUniversidade.Application.Interfaces;
using DN.ControleUniversidade.Domain.Contracts.Repositories;
using DN.ControleUniversidade.Domain.Contracts.Services;
using DN.ControleUniversidade.Domain.Services;
using DN.ControleUniversidade.Infra.Data.Context;
using DN.ControleUniversidade.Infra.Data.Interfaces;
using DN.ControleUniversidade.Infra.Data.Repositories;
using DN.ControleUniversidade.Infra.Data.UnitOfWork;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Infra.CrossCutting.IoC
{
    public class NinjectRepositoryModule: NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<,>));
            Bind<ICursoRepository>().To<CursoRepository>();
        }
    }
}
