using AutoMapper;
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
    [Authorize(Roles = $"{SD.Role_Merchant},{SD.Role_Admin}")]
    public class ShipmentsProductController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly SahamProjectContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public ShipmentsProductController(IUnitOfWork unit, UserManager<ApplicationUser> userManager, SahamProjectContext context, IMapper mapper )
        {
            _unit = unit;
            _userManager = userManager;
            _context = context;
            _mapper = mapper;   
        } 

        [HttpGet]
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
            var shpmentProductVM = _mapper.Map<ShpmentProductVM>(shipmentProducts);
            shpmentProductVM.Shipments = new SelectList(result, "Id", "OrderNumber",
                                             shpmentProductVM.ShipmentId);

            return View(shpmentProductVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ShpmentProductVM shpmentProductVM)
        {
            var shipmentProduct = _mapper.Map<ShipmentsProduct>(shpmentProductVM);

            if (!ModelState.IsValid)
                return View(shpmentProductVM);
            
            _unit.shipmentsProducts.Update(shipmentProduct);
            _unit.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
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
            var shpmentProductVM = _mapper.Map<ShpmentProductVM>(new ShipmentsProduct());
            shpmentProductVM.Shipments = new SelectList(result, "Id", "OrderNumber");

            return View(shpmentProductVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShpmentProductVM shpmentProductVM)
        {
            var shipmentProduct = _mapper.Map<ShipmentsProduct>(shpmentProductVM);

            if (!ModelState.IsValid)
            {
                var result = new List<Shipment>();
                var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var currentUser = await _userManager.
                                    FindByEmailAsync(User.
                                        FindFirstValue(ClaimTypes.Email));
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
                shpmentProductVM.Shipments = new SelectList(result, "Id", "OrderNumber");
                return View(shpmentProductVM);
            }

            _unit.shipmentsProducts.Add(shipmentProduct);
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
            var shipmentProductsId = _unit.shipmentsProducts.
                                  GetFirstOrDeafult(u => u.Id == id);
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
