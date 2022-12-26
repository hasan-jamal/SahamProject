using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using SahamProject.Web.Extensions;
using SahamProject.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace SahamProject.Web.ViewModels
{
    public class ShipmentVM
    {
        public int? Id { get; set; }
        [Range(1,1000, ErrorMessage = " السعر بين 1 إلى 1000")]
        public double? Price { get; set; }
        public string? MerchanId { get; set; }
        [OrderNumberExist(ErrorMessage = "Already Exist")]
        public string OrderNumber { get; set; }
        public string ShipmentTypeId { get; set; } = string.Empty;
        public IEnumerable<SelectListItem>? Customers { get; set; }
        public string? CustomersId { get; set; }
        public IEnumerable<SelectListItem>? Status { get; set; }
        public int StatusId { get; set; }
    }
}
