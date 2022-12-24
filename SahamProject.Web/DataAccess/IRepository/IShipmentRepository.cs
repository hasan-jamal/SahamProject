using SahamProject.Web.DataAccess.IRepository;
using SahamProject.Web.Models;

namespace SahamProject.Web.DataAccess.IRepository
{
    public interface IShipmentRepository : IRepository<Shipment>
    {
        void Update(Shipment shipment);
    }
}
