using Microsoft.AspNetCore.Mvc;
using myShop.Infurastructure.IRepository;
using myShop.Infurastructure.IRepository.ServicesRepository;
using myShop.Infurastructure.ViewModel;
using myShop.Entites.Models;

namespace ShopProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitofwork;

        public CategoryController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public IActionResult Categories()
        {
            var categories = new CategoryViewModel()
            {
                Categories = _unitofwork.Category.GetAll(x => x.CurrentStatue != (int)Helper.eCurrentStatue.Deleted).ToList(),
                NewCategory = new NewCategory()
            };

            return View("Categories",categories);
        }
        public IActionResult Add()
        {
            return View("Add");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAdd(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newCategory = new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = model.NewCategory.Name,
                    Description = model.NewCategory.Description,
                    CurrentStatue = (int)Helper.eCurrentStatue.Active
                };
                    _unitofwork.Category.Add(newCategory);
                
                _unitofwork.Complete();
                TempData["Create"]= "Category Created Successfully";
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
            var reData = _unitofwork.Category.GetBy(x => x.Id == Guid.Parse(Id));
            CategoryViewModel model = new CategoryViewModel()
            {
                NewCategory = new NewCategory()
                {
                    Id = reData.Id.ToString(),
                    Name = reData.Name,
                    Description = reData.Description
                }
            };
            return View("Edit",model);
        }
        public IActionResult SaveEdit(CategoryViewModel model)
        {
             if(ModelState.IsValid)
            {
                var updateCategory = new Category()
                {
                    Id = Guid.Parse(model.NewCategory.Id),
                    Name = model.NewCategory.Name,
                    Description = model.NewCategory.Description,
                    CurrentStatue = (int)Helper.eCurrentStatue.Active
                };
                _unitofwork.Category.Update(updateCategory);
                _unitofwork.Complete();
                TempData["Edit"] = "Category Updated Successfully";
                return RedirectToAction("Categories");
            }
             return RedirectToAction("Edit",model.NewCategory);
        }
        public IActionResult Delete(Guid Id)
        {
            _unitofwork.Category.Delete(Id);
            _unitofwork.Complete();
            TempData["Delete"] = "Category Deleted Successfully";
            return RedirectToAction("Categories");
        }
    }
}
