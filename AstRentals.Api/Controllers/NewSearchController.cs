using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using AstRentals.Data.Entities;
using AstRentals.Data.Infrastructure;


namespace AstRentals.Api.Controllers
{
    public class NewSearchController : ApiController
    {
        private readonly AstRentalsContext _ctx;

        public NewSearchController(AstRentalsContext ctx)
        {
            _ctx = ctx;
        }

        public List<Car> Get(string term)
        {
            var result = new List<Car>();

            using (var context = _ctx)
            {
                var clientIdParameter = new SqlParameter("@term", term);

                result = context.Database
                    .SqlQuery<Car>("dbo.SearchCars @term", clientIdParameter)
                    .ToList();
            }

            return result;
        }
    }
}
