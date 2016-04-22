﻿
namespace DN.ControleUniversidade.Domain.Interfaces.Specification
{
    public interface ISpecification<in TEntity>
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}
