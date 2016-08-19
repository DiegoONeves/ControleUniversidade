using DN.ControleUniversidade.Infra.Data.Interfaces;

namespace DN.ControleUniversidade.Application.Interfaces
{
    public interface IAppServiceBase
    {
        void BeginTransaction();
        void Commit();
    }
}
