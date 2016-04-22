using DN.ControleUniversidade.Domain.ValueObjects;

namespace DN.ControleUniversidade.Domain.Interfaces.Validation
{
    public interface ISelfValidator
    {
        ValidationResult ResultadoValidacao { get; }
        bool IsValid { get; }
    }
}