using DN.ControleUniversidade.Domain.ValueObjects;

namespace DN.ControleUniversidade.Domain.Contracts.Validation
{
    public interface IFiscal<in TEntity>
    {
        ValidationResult Validar(TEntity entity);
    }
}
