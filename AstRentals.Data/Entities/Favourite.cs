using System.ComponentModel.DataAnnotations;

namespace AstRentals.Data.Entities
{
    public class Favourite
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public int CarId { get; set; }
    }
}