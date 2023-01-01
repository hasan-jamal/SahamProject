﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using SahamProject.Web.Extensions;
using System.ComponentModel.DataAnnotations;

namespace SahamProject.Web.ViewModels
{
    public class ShipmentUpdateVM
    {
        public int? Id { get; set; }
        [Range(1,1000, ErrorMessage = " السعر بين 1 إلى 1000")]
        [Required(ErrorMessage = "Price Is Required")]
        public double Price { get; set; }
        public string? MerchanId { get; set; }
        [Required(ErrorMessage = "OrderNumber Is Required")]
        public string OrderNumber { get; set; }
        [Required(ErrorMessage = "Shipment Type Is Required")]
        public string ShipmentTypeId { get; set; } = string.Empty;
        [ValidateNever]
        public IEnumerable<SelectListItem>? Customers { get; set; }
        [Required(ErrorMessage = "Customer Is Required")]
        [Display(Name = "Customer")]
        public string CustomersId { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? Status { get; set; }
        [Required(ErrorMessage = "Status Is Required")]
        [Display(Name = "Status")]
        public int StatusId { get; set; }
    }
}
