using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;
using CheeseMVC.Data;
using CheeseMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<CheeseCategory> cataList = context.Categories.ToList();
            ViewBag.cataList = cataList;
            return View();
        }

        [HttpPost]
        public IActionResult Add(addCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var newCata = addCategoryViewModel.catagory;
                context.Categories.Add(newCata);
                context.SaveChanges();

                return Redirect("/Category");
            }
            return View(addCategoryViewModel);
        }
    }
}
