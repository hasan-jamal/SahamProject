using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using SahamProject.Web.DataAccess.IRepository;
using SahamProject.Web.Models;
using SahamProject.Web.Utlity;
using SahamProject.Web.ViewModels;
using System.Linq;
using System.Security.Claims;

namespace SahamProject.Web.Controllers
{
    [Authorize(Roles = $"{SD.Role_Merchant},{SD.Role_Admin}")]
    public class ShipmentController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly SahamProjectContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public ShipmentController(IMapper mapper,IUnitOfWork unit, UserManager<ApplicationUser> userManager, SahamProjectContext context)
        {
            _unit = unit;
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Serach()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult SearchOrderNumber([FromBody] SearchModel searchModel)
        {
            var result = _unit.shipments.GetFirstOrDeafult(
                a => a.OrderNumber.ToLower() == searchModel.Search.ToLower(),
                "Customer,Merchan,Status,ShipmentsProducts", false);
            if(result == null) return Json("Not found");
            var shipmentSearchResultVM = new ShipmentSearchResultVM()
            {
                CustomerName = result.Customer?.Name!,
                MerchanName = result.Merchan?.Name!,
                Price = result.Price ?? 0.0,
                OrderNumber = result.OrderNumber,
                ShipmentTypeId= result.ShipmentTypeId,
                StatusName = result.Status?.Name!
            };
            foreach (var item in result.ShipmentsProducts)
            {
                shipmentSearchResultVM.shipmentsProducts.Add(
                    new ShipmentsProductSearchVM()
                    {
                        Description = item.Description,
                        Height = item.Height,
                        Weight = item.Weight,
                        SPLength = item.Length,
                        IsBreakable = item.IsBreakable,
                        Width = item.Width
                    }
                    );
            }
            return Json(shipmentSearchResultVM);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetShipmentByOrderNumber(string orderNumber)
          => View(_unit.shipments.GetFirstOrDeafult(a => a.OrderNumber.ToLower() == orderNumber.ToLower(), "Customer,Merchan,Status,ShipmentsProducts", false));


        [HttpGet]
        public IActionResult Index()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = new List<Shipment>();
            if (User.IsInRole(SD.Role_Admin))
            {
                result = _unit.shipments.
                         GetAll(null, "Customer,Merchan,Status,ShipmentsProducts").ToList();
            }
            else
            {
                result =
                        _unit.shipments.GetAll(a =>
                        a.MerchanId == user, "Customer,Merchan,Status,ShipmentsProducts").ToList();
            }
            return View(result);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var shipment = _unit.shipments.
                GetFirstOrDeafult(a => a.Id == id, "Customer,Merchan,Status,ShipmentsProducts", false);
            var customerRole = _context.Roles.
                FirstOrDefault(a => a.Name == SD.Role_Customer);
            var userRoles = _context.UserRoles.
                Where(x => x.RoleId == customerRole!.Id).ToList();
            var users = new List<ApplicationUser>();
            foreach (var item in userRoles)
            {
                users.Add(
                    _context.Users.Where(a => a.Id == item.UserId).First()
                    );
            }
            var shipmentVM = _mapper.Map<ShipmentVM>(shipment);
            shipmentVM.Id = shipment.Id;
            shipmentVM.Customers = new SelectList(users.ToList(), "Id", "Name", shipmentVM.CustomersId);
            shipmentVM.Status = new SelectList(_unit.status.GetAll(), "Id", "Name", shipment.StatusId);

            return View(shipmentVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.Role_Merchant)]
        public IActionResult Update(ShipmentVM shipmentVM)
        {

            var shipment = _mapper.Map<Shipment>(shipmentVM);
            if (!ModelState.IsValid || shipmentVM.MerchanId != User.FindFirstValue(ClaimTypes.NameIdentifier))
                return View(shipmentVM);
            _unit.shipments.Update(shipment);
            _unit.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = SD.Role_Merchant)]
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
            var shipmentVM = _mapper.Map<ShipmentVM>(new Shipment());
            shipmentVM.Customers = new SelectList(users.ToList(), "Id", "Name");
            shipmentVM.Status = new SelectList(_unit.status.GetAll(), "Id", "Name");

            return View(shipmentVM);
        }
        [HttpPost]
        [Authorize(Roles = SD.Role_Merchant)]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ShipmentVM shipmentVM)
        {
            var shipment = _mapper.Map<Shipment>(shipmentVM);
            shipment.MerchanId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (!ModelState.IsValid)
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
                shipmentVM.Customers = new SelectList(users.ToList(), "Id", "Name");
                shipmentVM.Status = new SelectList(_unit.status.GetAll(), "Id", "Name");

                return View(shipmentVM);
            }
            _unit.shipments.Add(shipment);
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
            var contactsId = _unit.shipments.GetFirstOrDeafult(u => u.Id == id);
            if (contactsId == null)
            {
                return NotFound();
            }
            return View(contactsId);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var shipment = _unit.shipments.GetFirstOrDeafult(u => u.Id == id);
            if (shipment == null)
            {
                return NotFound();
            }
            _unit.shipments.Remove(shipment);
            _unit.Save();
            TempData["success"] = "Delete contacts is successfully";
            return RedirectToAction("Index");
        }
    }
}
