using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SahamProject.Web.DataAccess.IRepository;
using SahamProject.Web.Models;
using SahamProject.Web.Utlity;
using SahamProject.Web.ViewModels;

namespace SahamProject.Web.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContactsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Contact> objectcontactsList = _unitOfWork.contacts.GetAll();
            return View(objectcontactsList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.contacts.Add(contact);
                _unitOfWork.Save();
                TempData["success"] = "Add Information Contact is successfully";
                return RedirectToAction("Index");
            }
            return View(contact);
        }
   
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var contactsId = _unitOfWork.contacts.GetFirstOrDeafult(u => u.Id == id);
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
            var contacts = _unitOfWork.contacts.GetFirstOrDeafult(u => u.Id == id);
            // var contacts = _db.contacts.FirstOrDefault(c => c.Id == id);
            //var contacts = _db.contacts.SingleOrDefault(c => c.Id == id);
            if (contacts == null)
            {
                return NotFound();
            }
            _unitOfWork.contacts.Remove(contacts);
            _unitOfWork.Save();
            TempData["success"] = "Delete contacts is successfully";
            return RedirectToAction("Index");
        }
    }
}
