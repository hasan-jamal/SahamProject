using Microsoft.AspNetCore.Mvc;
using SahamProject.Web.DataAccess.IRepository;
using SahamProject.Web.Models;

namespace SahamProject.Web.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly IUnitOfWork _unit;
        public ShipmentController(IUnitOfWork unit)
        {
            _unit = unit;
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
            if(!ModelState.IsValid) return View(shipment);
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
            if (!ModelState.IsValid) return View(shipment);
            _unit.shipments.Add(shipment);
            _unit.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
