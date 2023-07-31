using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.ViewModels.OrderViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public bool IsDelivered { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
    }
}
