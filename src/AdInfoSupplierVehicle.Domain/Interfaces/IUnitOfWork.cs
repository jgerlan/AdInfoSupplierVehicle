using System.Threading.Tasks;

namespace AdInfoSupplierVehicle.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
