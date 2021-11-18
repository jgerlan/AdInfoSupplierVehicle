using System;
using System.Collections.Generic;
using System.Text;

namespace AdInfoSupplierVehicle.Domain.Models
{
    public abstract class BaseEntity
    {
        public int? Id { get; private set; }
    }
}
