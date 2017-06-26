using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class addCategoryViewModel
    {
        [Required(ErrorMessage = "You must have a catagory name!")]
        [Display(Name = "Catagory Name")]
        public string catagory { get; set; }

        
    }
}
