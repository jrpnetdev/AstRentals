using AstRentals.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AstRentals.Web.ViewModels
{
    public class PreCheckoutModel
    {
        public int CarId { get; set; }
        public string Colour { get; set; }
        public string Features { get; set; }
        public string Cover { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}