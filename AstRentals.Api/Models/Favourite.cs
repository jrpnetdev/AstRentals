using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using AstRentals.Data.Entities;

namespace AstRentals.Api.Models
{
    public class Favourite
    {
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }
    }
}