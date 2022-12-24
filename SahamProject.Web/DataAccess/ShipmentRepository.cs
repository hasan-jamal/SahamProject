using SahamProject.Web.DataAccess.IRepository;
using SahamProject.Web.Models;

namespace SahamProject.Web.DataAccess.Repository
{
    public class ShipmentRepository : Repository<Shipment> , IShipmentRepository
    {
        private readonly SahamProjectContext _db;

        public ShipmentRepository(SahamProjectContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Shipment shiptment)
        {
            _db.Shipments.Update(shiptment);
        }
    }
}
