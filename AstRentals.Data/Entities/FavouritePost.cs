using System.ComponentModel.DataAnnotations;

namespace AstRentals.Data.Entities
{
    public class FavouritePost
    {
        public string Email { get; set; }

        public int CarId { get; set; }
    }
}