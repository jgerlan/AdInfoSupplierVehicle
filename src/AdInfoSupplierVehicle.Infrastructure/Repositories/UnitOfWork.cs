using System.Threading.Tasks;
using AdInfoSupplierVehicle.Domain.Interfaces;
using AdInfoSupplierVehicle.Infrastructure.Context;

namespace AdInfoSupplierVehicle.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
