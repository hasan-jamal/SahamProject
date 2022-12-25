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
        [Authorize(Roles = $"{SD.Role_Merchant},{SD.Role_Admin}")]
        public async Task<IActionResult> Index()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _userManager.
                                FindByEmailAsync(User.
                                                    FindFirstValue(ClaimTypes.Email));
            var result = new List<ShipmentsProduct>();
            if (await _userManager.IsInRoleAsync(currentUser, SD.Role_Admin))
            {
                result = _unit.shipmentsProducts.
                         GetAll(null, "Shipment").ToList();
            }
            else
            {
                result =
                        _unit.shipmentsProducts.GetAll(a =>
                        a.Shipment.MerchanId == user,
                        "Shipment").ToList();
            }
            
            return View(result);
        }
        [HttpGet]
        [Authorize(Roles = $"{SD.Role_Merchant},{SD.Role_Admin}")]
        public async Task<IActionResult> Update(int id)
        {
            var shipmentProducts = _unit.shipmentsProducts.
                GetFirstOrDeafult(a => a.Id == id, "Shipment", false);
            var merchantId = User.
                FindFirstValue(ClaimTypes.NameIdentifier);
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _userManager.
                                FindByEmailAsync(User.
                                    FindFirstValue(ClaimTypes.Email));
            var result = new List<Shipment>();
            if (await _userManager.IsInRoleAsync(currentUser, 
                SD.Role_Admin))
            {
                result = _unit.shipments.
                         GetAll().ToList();
            }
            else
            {
                result =
                        _unit.shipments.GetAll(a =>
                        a.MerchanId == user).ToList();
            }
            var shpmentProductVM = new ShpmentProductVM()
            {
                ShipmentId = shipmentProducts.ShipmentId,
                ShipmentsProducts = shipmentProducts,
                Shipments = new SelectList(result, "Id", "OrderNumber", 
                shipmentProducts.ShipmentId)
            };

            return View(shpmentProductVM);
        }
        [HttpPost]
        [Authorize(Roles = $"{SD.Role_Merchant},{SD.Role_Admin}")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ShpmentProductVM shpmentProductVM)
        {
            var shipmentProduct = new ShipmentsProduct();
            shipmentProduct = shpmentProductVM.ShipmentsProducts;
            shipmentProduct.ShipmentId = shpmentProductVM.ShipmentId;

            if (shipmentProduct == null || shpmentProductVM == null)
                return View(shpmentProductVM);
            _unit.shipmentsProducts.Update(shipmentProduct);
            _unit.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = $"{SD.Role_Merchant},{SD.Role_Admin}")]
        public async Task<IActionResult> Create()
        {
            var merchantId = User.
                FindFirstValue(ClaimTypes.NameIdentifier);
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _userManager.
                                FindByEmailAsync(User.
                                    FindFirstValue(ClaimTypes.Email));
            var result = new List<Shipment>();
            if (await _userManager.IsInRoleAsync(currentUser,
                SD.Role_Admin))
            {
                result = _unit.shipments.
                         GetAll().ToList();
            }
            else
            {
                result =
                        _unit.shipments.GetAll(a =>
                        a.MerchanId == user).ToList();
            }
            var shpmentProductVM = new ShpmentProductVM()
            {
                ShipmentsProducts =new ShipmentsProduct(),
                Shipments = new SelectList(result, "Id", "OrderNumber")
            };

            return View(shpmentProductVM);
        }

        [HttpPost]
        [Authorize(Roles = $"{SD.Role_Merchant},{SD.Role_Admin}")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ShpmentProductVM shpmentProductVM)
        {
            var shipmentProducts = new ShipmentsProduct();
            shipmentProducts = shpmentProductVM.ShipmentsProducts;
            shipmentProducts.ShipmentId = shpmentProductVM.ShipmentId;
            if (shipmentProducts == null || shpmentProductVM == null) return View(shipmentProducts);
            _unit.shipmentsProducts.Add(shipmentProducts);
            _unit.Save();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        [Authorize(Roles = $"{SD.Role_Merchant},{SD.Role_Admin}")]
        public IActionResult Delete(int? id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var shipmentProductsId = _unit.shipmentsProducts.
                                  GetFirstOrDeafult(u => u.Id == id);
            if (shipmentProductsId == null)
            {
                return NotFound();
            }
            return View(shipmentProductsId);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = $"{SD.Role_Merchant},{SD.Role_Admin}")]
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
