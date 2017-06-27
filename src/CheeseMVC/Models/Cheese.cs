using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }

        public CheeseCategory Category { get; set; }
        public int CategoryID { get; set; }

        public IList<CheeseMenu> CheeseMenus { get; set; }
    }
}
