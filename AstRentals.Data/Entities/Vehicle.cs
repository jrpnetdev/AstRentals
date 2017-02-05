namespace AstRentals.Data.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string Colour { get; set; }

        public string Registration { get; set; }

        public decimal Price { get; set; }

        public VehicleType Type { get; set; }

        public int CustomerId { get; set; }

        //[ForeignKey("CarId")]
        //public virtual Car CarType { get; set; }

        //[ForeignKey("CustomerId")]
        //public virtual Customer Customer { get; set; }
    } 
}