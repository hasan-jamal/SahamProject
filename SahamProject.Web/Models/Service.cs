using System;
using System.Collections.Generic;

namespace SahamProject.Web.Models
{
    public partial class Service
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
