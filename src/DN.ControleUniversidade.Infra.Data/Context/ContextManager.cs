using DN.ControleUniversidade.Infra.Data.Interfaces;
using System.Web;

namespace DN.ControleUniversidade.Infra.Data.Context
{
    public class ContextManager<TContext> : IContextManager<TContext> where TContext : IDbContext, new()
    {
        private const string CONTEXT_KEY = "ContextManager.Context";
        public IDbContext GetContext()
        {
            if (HttpContext.Current.Items[CONTEXT_KEY] == null)
            {
                HttpContext.Current.Items[CONTEXT_KEY] = new TContext();
            }

            return (IDbContext)HttpContext.Current.Items[CONTEXT_KEY];
        }
    }
}
