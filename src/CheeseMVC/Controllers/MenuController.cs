using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using System.Collections.Generic;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class MenuController : Controller
    {
        private CheeseDbContext context;

        public MenuController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Menu> menuList = context.Menu.ToList();
            ViewBag.menuList = menuList;
            return View();
        }

        public IActionResult Add()
        {
            AddMenuViewModel addMenuViewModel = new AddMenuViewModel();
            return View(addMenuViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddMenuViewModel addMenuViewModel)
        {
            if (ModelState.IsValid)
            {
                Menu newMenu = new Menu
                {
                    Name = addMenuViewModel.Name
                };
                context.Menu.Add(newMenu);
                context.SaveChanges();
                return Redirect("/Menu/ViewMenu/" + newMenu.ID);
            }
            return View();
        }

        [HttpGet]
        [Route("/Menu/ViewMenu/{id}")]
        public IActionResult ViewMenu(int id)
        {
            List<CheeseMenu> items = context
                    .CheeseMenus
                    .Include(item => item.Cheese)
                    .Where(cm => cm.MenuID == id)
                    .ToList();

            Menu menu = context.Menu.Single(m => m.ID == id);

            ViewMenuViewModel viewMenuViewModel = new ViewMenuViewModel(menu, items);

            return View(viewMenuViewModel);
        }

        [HttpGet]
        [Route("/Menu/AddItem/{id}")]
        public IActionResult AddItem(int id)
        {
            
            Menu menu = context.Menu.Single(m => m.ID == id);

            List<Cheese> items = context.Cheeses.ToList();

            AddMenuItemViewModel addMenuItemViewModel = new AddMenuItemViewModel(menu, items);

            return View(addMenuItemViewModel);
        }

        [HttpPost]
        public IActionResult AddItem(AddMenuItemViewModel addMenuItemViewModel)
        {
            if (ModelState.IsValid)
            {
                IList<CheeseMenu> existingItems = context.CheeseMenus
                            .Where(cm => cm.CheeseID == addMenuItemViewModel.CheeseID)
                            .Where(cm => cm.MenuID == addMenuItemViewModel.MenuID).ToList();
                if (existingItems.Count == 0)
                {
                    CheeseMenu cheeseMenu = new CheeseMenu
                    {
                        Cheese = context.Cheeses.Single(c => c.ID == addMenuItemViewModel.CheeseID),
                        Menu = context.Menu.Single(m => m.ID == addMenuItemViewModel.MenuID)
                    };
                    context.CheeseMenus.Add(cheeseMenu);
                    context.SaveChanges();
                    return Redirect("/Menu/ViewMenu/" + addMenuItemViewModel.MenuID);
                }
                return Redirect("/Menu/AddItem/" + addMenuItemViewModel.MenuID);
            }
            return Redirect("/Menu/AddItem/" + addMenuItemViewModel.MenuID);
        }
    }

}


