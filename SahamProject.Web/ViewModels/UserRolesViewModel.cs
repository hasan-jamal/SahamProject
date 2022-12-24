using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using SahamProject.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace SahamProject.Web.ViewModels
{
    public class UserRolesViewModel
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public IEnumerable<SelectListItem> Roles { get; set; }
        public List<string>? UserRoles { get; set; }
    }
}
