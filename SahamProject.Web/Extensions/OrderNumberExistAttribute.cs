using Microsoft.EntityFrameworkCore;
using SahamProject.Web.DataAccess;
using SahamProject.Web.DataAccess.IRepository;
using System.ComponentModel.DataAnnotations;

namespace SahamProject.Web.Extensions
{
    public class OrderNumberExistAttribute : ValidationAttribute
    {
        
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) 
                return new ValidationResult(ErrorMessage);
            var _unit = (IUnitOfWork)validationContext
            .GetService(typeof(IUnitOfWork))!;

            var result = _unit.shipments.GetFirstOrDeafult(x =>
                x.OrderNumber.ToLower() == value.ToString()!.ToLower(),
                null, false);
            if (result != null)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;

        }
    }
}
