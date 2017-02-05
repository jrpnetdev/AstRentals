using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AstRentals.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int AddressId { get; set; }

        //[ForeignKey("AddressId")]
        //public virtual Address Address { get; set; }

        private ICollection<Vehicle> _vehicles;

        public virtual ICollection<Vehicle> Vehicles
        {
            get { return _vehicles ?? (_vehicles = new Collection<Vehicle>()); }
            set { _vehicles = value; }
        }
    }
}