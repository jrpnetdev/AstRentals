using AstRentals.Data.Entities;
using System.Collections.Generic;

namespace AstRentals.Web.ViewModels
{
    public class MyAccountOrdersViewModel
    {
        public List<Car> Cars { get; set; }
        public List<Order> Orders { get; set; }
    }
}