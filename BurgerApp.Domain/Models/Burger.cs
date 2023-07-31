using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Domain.Models
{
    public class Burger : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsOnPromotion { get; set; }
        public bool IsVegeterian { get; set; }
        public bool IsVegan { get; set; }
        public bool HasFries { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public List<BurgerOrder> BurgerOrders { get; set; } = new List<BurgerOrder>();
    }
}
