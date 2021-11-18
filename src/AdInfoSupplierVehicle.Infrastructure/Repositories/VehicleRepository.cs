using System.Collections.Generic;
using System.Linq;
using AdInfoSupplierVehicle.Domain.Models;
using AdInfoSupplierVehicle.Infrastructure.Context;


namespace AdInfoSupplierVehicle.Infrastructure.Repositories
{
    public class VehicleRepository : Repository<Vehicle>
    {
        public VehicleRepository(AppDbContext context) : base(context){}

        public override Vehicle GetById(int id)
        {
            var query = _context.Set<Vehicle>().Where(e => e.Id == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Vehicle> GetAll()
        {
            var query = _context.Set<Vehicle>();

            return query.Any() ? query.ToList() : new List<Vehicle>();
        }

    }
}
