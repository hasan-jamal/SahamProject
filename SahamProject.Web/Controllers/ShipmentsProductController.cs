using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SahamProject.Web.DataAccess.IRepository;
using SahamProject.Web.Models;
using SahamProject.Web.Utlity;
using SahamProject.Web.ViewModels;
using System.Security.Claims;

namespace SahamProject.Web.Controllers
{
    public class ShipmentsProductController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly SahamProjectContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ShipmentsProductController(IUnitOfWork unit, UserManager<ApplicationUser> userManager, SahamProjectContext context)
        {
            _unit = unit;
            _userManager = userManager;
            _context = context;
        } 

        [HttpGet]
        public IActionResult Index()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_unit.shipmentsProducts.GetAll(a => a.Shipment.MerchanId == user, "Shipment"));
        }
        [HttpGet]
        [Authorize(Roles = SD.Role_Merchant)]
        public IActionResult Update(int id)
        {
            var shipmentProducts = _unit.shipmentsProducts.
                GetFirstOrDeafult(a => a.Id == id, "Shipment", false);
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
            var shpmentProductVM = new ShpmentProductVM()
            {
                ShipmentsProducts = shipmentProducts,
                Shipments = new SelectList(_unit.shipments.GetAll(), "Id", "OrderNumber", shipmentProducts.ShipmentId)
            };

            return View(shipmentProducts);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ShpmentProductVM shpmentProductVM)
        {
            var shipmentProduct = new ShipmentsProduct();
            shipmentProduct = shpmentProductVM.ShipmentsProducts;
            shipmentProduct.ShipmentId = shpmentProductVM.ShipmentId;

            if (shipmentProduct == null || shpmentProductVM == null || shpmentProductVM.ShipmentsProducts.Shipment.MerchanId != User.FindFirstValue(ClaimTypes.NameIdentifier))
                return View(shpmentProductVM);
            _unit.shipmentsProducts.Update(shipmentProduct);
            _unit.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            var customerRole = _context.Roles.FirstOrDefault(a => a.Name == SD.Role_Customer);
            var userRoles = _context.UserRoles.Where(x => x.RoleId == customerRole.Id).ToList();
            var users = new List<ApplicationUser>();
            foreach (var item in userRoles)
            {
                users.Add(
                    _context.Users.Where(a => a.Id == item.UserId).First()
                    );
            }
            var shpmentProductVM = new ShpmentProductVM()
            {
                ShipmentsProducts =new ShipmentsProduct(),
                Shipments = new SelectList(_unit.shipments.GetAll(), "Id", "OrderNumber")
            };

            return View(shpmentProductVM);
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Merchant)]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ShpmentProductVM shpmentProductVM)
        {
            var shipmentProducts = new ShipmentsProduct();
            shipmentProducts = shpmentProductVM.ShipmentsProducts;
            shipmentProducts.Shipment.MerchanId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            shipmentProducts.ShipmentId = shpmentProductVM.ShipmentId;
            if (shipmentProducts == null || shpmentProductVM == null) return View(shipmentProducts);
            _unit.shipmentsProducts.Add(shipmentProducts);
            _unit.Save();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var shipmentProductsId = _unit.shipmentsProducts.GetFirstOrDeafult(u => u.Id == id);
            if (shipmentProductsId == null)
            {
                return NotFound();
            }
            return View(shipmentProductsId);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var shipmentProduct = _unit.shipmentsProducts.GetFirstOrDeafult(u => u.Id == id);
            if (shipmentProduct == null)
            {
                return NotFound();
            }
            _unit.shipmentsProducts.Remove(shipmentProduct);
            _unit.Save();
            TempData["success"] = "Delete shipment Product is successfully";
            return RedirectToAction("Index");
        }
    }
}
