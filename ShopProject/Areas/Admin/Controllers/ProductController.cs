using Microsoft.AspNetCore.Mvc;
using myShop.Infurastructure.IRepository;
using myShop.Infurastructure.IRepository.ServicesRepository;
using myShop.Infurastructure.ViewModel;
using myShop.Entites.Models;

namespace ShopProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitofwork;

        public ProductController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public IActionResult Products()
        {
            var products = new ProductsViewModel()
            {
                Products = _unitofwork.Product.GetAll(x => x.CurrentStatue != (int)Helper.eCurrentStatue.Deleted).ToList(),
                NewProduct = new NewProducts()
            };

            return View("Products", products);
        }
        public IActionResult Add()
        {
            ViewBag.Categories = _unitofwork.Category.GetAll(x => x.CurrentStatue != (int)Helper.eCurrentStatue.Deleted).ToList();
            return View("Add");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAdd(ProductsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var file = HttpContext.Request.Form.Files;
                if (file.Count > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                    var fileStream = new FileStream(Path.Combine(@"wwwroot/", Helper.ImagePath, ImageName), FileMode.Create);
                    file[0].CopyTo(fileStream);
                    model.NewProduct.Image = ImageName;
                }
                else
                {
                    model.NewProduct.Image = model.NewProduct.Image;
                }
                var newProducts = new Products()
                {
                    Id = Guid.NewGuid(),
                    Name = model.NewProduct.Name,
                    Description = model.NewProduct.Description,
                    Price = model.NewProduct.Price,
                    Image = model.NewProduct.Image,
                    CategoryId = model.NewProduct.CategoryId,
                    CurrentStatue = (int)Helper.eCurrentStatue.Active
                };
                    _unitofwork.Product.Add(newProducts);
                
                _unitofwork.Complete();
                TempData["Create"]= "Products Created Successfully";
                return RedirectToAction("Categories");
            }
            return RedirectToAction("Add",model);
        }
        public IActionResult Edit(string Id)
        {
            if(Id == null)
            {
                NotFound();
                return RedirectToAction("Categories");
            }
            var reData = _unitofwork.Product.GetBy(x => x.Id == Guid.Parse(Id));
            ProductsViewModel model = new ProductsViewModel()
            {
                NewProduct = new NewProducts()
                {
                    Id = reData.Id.ToString(),
                    Name = reData.Name,
                    Description = reData.Description
                }
            };
            return View("Edit",model);
        }
        public IActionResult SaveEdit(ProductsViewModel model)
        {
             if(ModelState.IsValid)
            {
                var file = HttpContext.Request.Form.Files;
                if (file.Count > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                    var fileStream = new FileStream(Path.Combine(@"wwwroot/", Helper.ImagePath, ImageName), FileMode.Create);
                    file[0].CopyTo(fileStream);
                    model.NewProduct.Image = ImageName;
                }
                else
                {
                    model.NewProduct.Image = model.NewProduct.Image;
                }
                var updateProducts = new Products()
                {
                    Id = Guid.Parse(model.NewProduct.Id),
                    Name = model.NewProduct.Name,
                    Description = model.NewProduct.Description,
                    CurrentStatue = (int)Helper.eCurrentStatue.Active
                };
                _unitofwork.Product.Update(updateProducts);
                _unitofwork.Complete();
                TempData["Edit"] = "Products Updated Successfully";
                return RedirectToAction("Categories");
            }
             return RedirectToAction("Edit",model.NewProduct);
        }
        public IActionResult Delete(Guid Id)
        {
            _unitofwork.Product.Delete(Id);
            _unitofwork.Complete();
            TempData["Delete"] = "Products Deleted Successfully";
            return RedirectToAction("Categories");
        }
    }
}
