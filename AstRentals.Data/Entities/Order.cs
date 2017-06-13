using System;

namespace AstRentals.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int CarId { get; set; }
        public string Colour { get; set; }
        public string Features { get; set; }
        public string Cover { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
