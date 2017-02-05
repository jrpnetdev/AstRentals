namespace AstRentals.Data.Entities
{
    public class Address
    {
        public int Id { get; set; }

        public string HouseNumber { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string County { get; set; }

        public string PostCode { get; set; }
    }
}