using Microsoft.AspNetCore.Mvc;
using Librarycreation.Data;
using Librarycreation.Models;
using System.Collections.Generic;
using System.Linq;

namespace Librarycreation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        // Constructor should properly assign _db
        public CategoryController(ApplicationDbContext db)
        {
            _db = db; // Initialize _db here
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Catogories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "the display oder cannot match the name");
            }
            if (obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value");
            }
            if (ModelState.IsValid)
            {
                _db.Catogories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

    }
}