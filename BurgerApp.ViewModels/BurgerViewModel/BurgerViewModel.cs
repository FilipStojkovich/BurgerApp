using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.ViewModels.BurgerViewModel
{
    public class BurgerViewModel
    {
        public int Id { get; set; }

        [Display(Name="Burger name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name="Burger promotion")]
        public bool IsOnPromotion { get; set; }

        [Display(Name="Burger price")]
        public int Price { get; set; }

        [Display(Name="Burger image")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
