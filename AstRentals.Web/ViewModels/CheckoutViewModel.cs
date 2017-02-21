using AstRentals.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AstRentals.Web.ViewModels
{
    public class CheckoutViewModel
    {
        public Car Car { get; set; }
        public int CarId { get; set; }
        public string Colour { get; set; }
        public string Features { get; set; }
        public string Cover { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}