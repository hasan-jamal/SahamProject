using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahamProject.Web.DataAccess.IRepository
{
    public interface IUnitOfWork
    {
        IContactRepository contacts { get; }
        IServiceRepository services { get; }
        IShipmentRepository shipments { get; }
        IShipmentsProductRepository shipmentsProducts { get; }
        IStatusRepository status { get; }
        void Save();
    }
}
