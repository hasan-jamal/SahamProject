using Microsoft.AspNetCore.Mvc;
using SahamProject.Web.DataAccess.IRepository;
using SahamProject.Web.ViewModels;

namespace SahamProject.Web.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServiceController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Upsert(int? id)
        {
            ServicesVM serviceVM = new()
            {
                Service = new()
            };
            if (id == 0 || id == null)
            {
                return View(serviceVM);

            }
            else
            {
                //Update Product
                serviceVM.Service = _unitOfWork.services.GetFirstOrDeafult(u => u.Id == id);
                return View(serviceVM);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ServicesVM serviceVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Images\Services");
                    var extension = Path.GetExtension(file.FileName);
                    if (serviceVM.Service.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, serviceVM.Service.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    serviceVM.Service.ImageUrl = @"\Images\Services\" + fileName + extension;
                }
                if (serviceVM.Service.Id == 0)
                {
                    _unitOfWork.services.Add(serviceVM.Service);
                    TempData["success"] = " Create Service is successfully";
                }
                else
                {
                    _unitOfWork.services.Update(serviceVM.Service);
                    TempData["success"] = " Update Category is successfully";
                }
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View(serviceVM);
        }




        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allCategories = _unitOfWork.services.GetAll();
            return Json(new { data = allCategories });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var category = _unitOfWork.services.GetFirstOrDeafult(u => u.Id == id);
            // var coverType = _db.CoverType.FirstOrDefault(c => c.Id == id);
            //var coverType = _db.CoverType.SingleOrDefault(c => c.Id == id);
            if (category == null)
            {
                return Json(new { success = false, message = "Error While deleting" });
            }
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, category.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.services.Remove(category);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful !" });
        }
        #endregion
    }
}