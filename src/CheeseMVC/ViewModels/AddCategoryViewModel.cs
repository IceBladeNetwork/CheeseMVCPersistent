using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddCategoryViewModel
    {
        [Required(ErrorMessage = "You must have a catagory name!")]
        [Display(Name = "Category Name")]
        public string Category { get; set; }

        public AddCategoryViewModel()
        {

        }
        
    }
}
