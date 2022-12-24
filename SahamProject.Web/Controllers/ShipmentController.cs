using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SahamProject.Web.DataAccess.IRepository;
using SahamProject.Web.Models;
using System.Security.Claims;

namespace SahamProject.Web.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly UserManager<ApplicationUser> _userManager;
        public ShipmentController(IUnitOfWork unit, UserManager<ApplicationUser> userManager)
        {
            _unit = unit;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
         => View(_unit.shipments.GetAll(null, "Customer,Merchan,Status,ShipmentsProducts"));

        [HttpGet]
        public IActionResult Update(int id)
            => View(_unit.shipments.GetFirstOrDeafult(a=> a.Id == id, "Customer,Merchan,Status,ShipmentsProducts", false));

        [HttpPost]
        public IActionResult Update(Shipment shipment) 
        {
            
            
            if (!ModelState.IsValid || shipment.MerchanId != User.FindFirstValue(ClaimTypes.NameIdentifier))
                return View(shipment);
            _unit.shipments.Update(shipment);
            _unit.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
         => View(new Shipment());

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
