using Microsoft.EntityFrameworkCore;
using SahamProject.Web.DataAccess;
using SahamProject.Web.DataAccess.IRepository;
using System.ComponentModel.DataAnnotations;

namespace SahamProject.Web.Extensions
{
    public class OrderNumberExistAttribute : ValidationAttribute
    {
        private readonly string _errorMesage;
        public OrderNumberExistAttribute(string ERRORMESAGE = "ERROR")
        {
            _errorMesage= ERRORMESAGE;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) 
                return new ValidationResult(_errorMesage);
            var _unit = (IUnitOfWork)validationContext
            .GetService(typeof(IUnitOfWork))!;

            var result = _unit.shipments.GetFirstOrDeafult(x =>
                x.OrderNumber.ToLower() == value.ToString()!.ToLower(),
                null, false);
            if (result != null)
                return new ValidationResult(_errorMesage);

            return ValidationResult.Success;

        }
    }
}
