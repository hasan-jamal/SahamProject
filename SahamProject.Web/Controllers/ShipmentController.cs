using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SahamProject.Web.DataAccess.IRepository;
using SahamProject.Web.Models;
using SahamProject.Web.Utlity;
using SahamProject.Web.ViewModels;
using System.Linq;
using System.Security.Claims;

namespace SahamProject.Web.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly SahamProjectContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ShipmentController(IUnitOfWork unit, UserManager<ApplicationUser> userManager, SahamProjectContext context)
        {
            _unit = unit;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
         => View(_unit.shipments.GetAll(null, "Customer,Merchan,Status,ShipmentsProducts"));

        [HttpGet]
        public IActionResult Update(int id)
        {
            var shipment = _unit.shipments.
                GetFirstOrDeafult(a => a.Id == id, "Customer,Merchan,Status,ShipmentsProducts", false);
            var customerRole = _context.Roles.
                FirstOrDefault(a => a.Name == SD.Role_Customer);
            var userRoles = _context.UserRoles.
                Where(x => x.RoleId == customerRole.Id).ToList();
            var users = new List<ApplicationUser>();
            foreach (var item in userRoles)
            {
                users.Add(
                    _context.Users.Where(a => a.Id == item.UserId).First()
                    );
            }
            var shipmentVM = new ShipmentVM()
            {
                Shipment = shipment,
                Customers = new SelectList(users.ToList(), "Id", "Name", shipment.CustomerId),
                Status = new SelectList(_unit.status.GetAll(), "Id", "Name", shipment.StatusId)
            };

            return View(shipmentVM);
        }
        [HttpPost]
        public IActionResult Update(ShipmentVM shipmentVM) 
        {
            if (!ModelState.IsValid || shipmentVM.Shipment.MerchanId != User.FindFirstValue(ClaimTypes.NameIdentifier))
                return View(shipmentVM);

            var shipment = shipmentVM.Shipment;
            shipment.CustomerId = shipmentVM.CustomersId;
            shipment.StatusId = shipmentVM.StatusId;
            _unit.shipments.Update(shipment);
            _unit.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            var customerRole = _context.Roles.FirstOrDefault(a=> a.Name == SD.Role_Customer);
            var userRoles = _context.UserRoles.Where(x => x.RoleId == customerRole.Id).ToList();
            var users = new List<ApplicationUser>();
            foreach (var item in userRoles)
            {
                users.Add(
                    _context.Users.Where(a => a.Id == item.UserId).First()
                    );
            }
            var shipmentVM = new ShipmentVM()
            {
                Shipment = new Shipment(),
                Customers = new SelectList(users.ToList(), "Id", "Name"),
                Status = new SelectList(_unit.status.GetAll(), "Id", "Name")
            };
            
         return View(shipmentVM);
        }
        [HttpPost]
        public IActionResult Create(Shipment shipment)
        {
            shipment.MerchanId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid) return View(shipment);
            _unit.shipments.Add(shipment);
            _unit.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
