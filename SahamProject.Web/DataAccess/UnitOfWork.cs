using SahamProject.Web.DataAccess.IRepository;
using SahamProject.Web.DataAccess.Repository;
using SahamProject.Web.Models;

namespace SahamProject.Web.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SahamProjectContext _db;
        public UnitOfWork(SahamProjectContext db)
        {
            _db = db;
            contacts = new ContactsRepository(_db);
            services = new ServiceRepository(_db);
            shipments = new ShipmentRepository(_db);
        }

        public IContactRepository contacts { get; private set; }
        public IServiceRepository services { get; private set; }
        public IShipmentRepository shipments { get; private set; }
        public void Save()
        {
          _db.SaveChanges();
        }
    }
}
