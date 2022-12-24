using SahamProject.Web.DataAccess.IRepository;
using SahamProject.Web.DataAccess.Repository;
using SahamProject.Web.Models;

namespace SahamProject.Web.DataAccess
{
    public class ShipmentsProductRepository : Repository<ShipmentsProduct>, IShipmentsProductRepository
    {
        private readonly SahamProjectContext _db;
        public ShipmentsProductRepository(SahamProjectContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ShipmentsProduct shipmentsProduct)
        {
            _db.ShipmentsProducts.Update(shipmentsProduct);
        }
    }
}
