using System;
using System.Collections.Generic;

namespace SahamProject.Web.Models
{
    public partial class Service
    {
        public string Id { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
