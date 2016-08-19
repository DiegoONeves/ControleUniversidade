using DN.ControleUniversidade.Application;
using DN.ControleUniversidade.Application.Interfaces;
using DN.ControleUniversidade.Domain.Interfaces.Repositories;
using DN.ControleUniversidade.Domain.Interfaces.Services;
using DN.ControleUniversidade.Domain.Services;
using DN.ControleUniversidade.Infra.Data.Context;
using DN.ControleUniversidade.Infra.Data.Interfaces;
using DN.ControleUniversidade.Infra.Data.Repositories;
using DN.ControleUniversidade.Infra.Data.UnitOfWork;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<ITipoCursoAppService, TipoCursoAppService>(Lifestyle.Scoped);
            container.Register<ICursoAppService, CursoAppService>(Lifestyle.Scoped);
            container.Register<IAlunoAppService, AlunoAppService>(Lifestyle.Scoped);

            container.Register<ITipoCursoService, TipoCursoService>(Lifestyle.Scoped);
            container.Register<ICursoService, CursoService>(Lifestyle.Scoped);
            container.Register<IAlunoService, AlunoService>(Lifestyle.Scoped);

            container.Register<UniversidadeContext>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, EFUnitOfWork>(Lifestyle.Scoped);


            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);

            container.Register<ICursoRepository, CursoRepository>(Lifestyle.Scoped);
            container.Register<ITipoCursoRepository, TipoCursoRepository>(Lifestyle.Scoped);
            container.Register<IAlunoRepository, AlunoRepository>(Lifestyle.Scoped);

        }
    }
}
