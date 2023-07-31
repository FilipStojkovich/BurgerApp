using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Domain.Models
{
    public class Location
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string OpensAt { get; set; }
        public string ClosesAt { get; set; }
    }
}
