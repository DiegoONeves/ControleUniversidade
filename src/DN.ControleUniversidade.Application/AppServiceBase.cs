using DN.ControleUniversidade.Application.Interfaces;
using DN.ControleUniversidade.Application.Validation;
using DN.ControleUniversidade.Domain.ValueObjects;
using DN.ControleUniversidade.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Application
{
    public class AppServiceBase : IAppServiceBase
    {
        private IUnitOfWork _uow;
        public AppServiceBase(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.SaveChanges();
        }

        protected ValidationAppResult DomainToApplicationResult(ValidationResult result)
        {
            var validationAppResult = new ValidationAppResult();

            foreach (var validationError in result.Erros)
            {
                validationAppResult.Erros.Add(new ValidationAppError(validationError.Message));
            }
            validationAppResult.IsValid = result.IsValid;

            return validationAppResult;
        }
    }
}
