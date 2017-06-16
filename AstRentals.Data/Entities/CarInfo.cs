using System.ComponentModel.DataAnnotations.Schema;

namespace AstRentals.Data.Entities
{
    [Table("CarInfo")]
    public class CarInfo
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Info { get; set; }
    }
}
