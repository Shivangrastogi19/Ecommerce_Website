using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interface;

namespace Ecommerce.Web.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryServices _categoryServices;

		public CategoryController(ICategoryServices categoryServices)
		{
			_categoryServices = categoryServices;
		}

		public IActionResult AddCategory()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddCategory(Category model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					//await _categoryServices.AddCategory(model);
					return RedirectToAction("GetCategories");
				}
				else
				{
					TempData["errorMessage"] = "Field is Empty";
					return View();
				}
			}
			catch (Exception ex)
			{
				TempData["errorMessage"] = ex.Message;
				return View();
			}
		}
	}
}
