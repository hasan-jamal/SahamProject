using SahamProject.Web.Models;

namespace SahamProject.Web.DataAccess.IRepository
{
    public interface IShipmentsProductRepository : IRepository<ShipmentsProduct>
    {
        void Update(ShipmentsProduct shipmentsProduct);
    }
}
