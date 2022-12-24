using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SahamProject.Web.DataAccess.IRepository;
using SahamProject.Web.Models;
using SahamProject.Web.Utlity;

namespace SahamProject.Web.Controllers
{
    public class ShipmentsProductController : Controller
    {
        private readonly IUnitOfWork _unit;
        public ShipmentsProductController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        public IActionResult Index()
         => View(_unit.shipmentsProducts.GetAll(null, "Shipment"));

        [HttpGet]
        [Authorize(Roles = SD.Role_Merchant)]
        public IActionResult Update(int id)
            => View(_unit.shipmentsProducts.GetFirstOrDeafult(a => a.Id == id, "Shipment", false));

        [HttpPost]
        [Authorize(Roles = SD.Role_Merchant)]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ShipmentsProduct shipmentsProduct)
        {
            if (!ModelState.IsValid) return View(shipmentsProduct);
            _unit.shipmentsProducts.Update(shipmentsProduct);
            _unit.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = SD.Role_Merchant)]
        public IActionResult Create()
         => View(new ShipmentsProduct());

        [HttpPost]
        [Authorize(Roles = SD.Role_Merchant)]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ShipmentsProduct shipmentsProduct)
        {
            if (!ModelState.IsValid) return View(shipmentsProduct);
            _unit.shipmentsProducts.Add(shipmentsProduct);
            _unit.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
