using DN.ControleUniversidade.Infra.Data.Interfaces;

namespace DN.ControleUniversidade.Application.Interfaces
{
    public interface IAppServiceBase<TContext> where TContext : IDbContext
    {
        void BeginTransaction();
        void Commit();
    }
}
