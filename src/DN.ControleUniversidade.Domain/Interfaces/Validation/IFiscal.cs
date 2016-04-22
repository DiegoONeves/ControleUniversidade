using DN.ControleUniversidade.Domain.ValueObjects;

namespace DN.ControleUniversidade.Domain.Interfaces.Validation
{
    public interface IFiscal<in TEntity>
    {
        ValidationResult Validar(TEntity entity);
    }
}
