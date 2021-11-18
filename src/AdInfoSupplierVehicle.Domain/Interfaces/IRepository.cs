using System;
using System.Collections.Generic;
using System.Text;

namespace AdInfoSupplierVehicle.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
