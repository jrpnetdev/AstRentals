using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AstRentals.Data.Entities;

namespace AstRentals.Web.ViewModels
{
    public class MyAccountIndexViewModel
    {
        public List<Car> FavouriteCars { get; set; }
        public List<Car> OrderCars { get; set; }
        public List<Order> Orders { get; set; }
    }
}