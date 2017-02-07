using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AstRentals.Data.Entities;

namespace AstRentals.Api.Models
{
    public class CarListViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public int TotalCars { get; set; }
        public int NumberOfPages { get; set; }
        public int CurrentPage { get; set; }
    }
}