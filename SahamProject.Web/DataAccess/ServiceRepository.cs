using SahamProject.Web.DataAccess.IRepository;
using SahamProject.Web.DataAccess.Repository;
using SahamProject.Web.Models;

namespace SahamProject.Web.DataAccess
{
    public class ServiceRepository :Repository<Service> , IServiceRepository
    {
        private readonly SahamProjectContext _db;
       
        public ServiceRepository(SahamProjectContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Service obj)
        {
            var serviceId = _db.Services.FirstOrDefault(u => u.Id == obj.Id);
            if (serviceId != null)
            {
                serviceId.Id = obj.Id;
                serviceId.Name = obj.Name;
                serviceId.Description = obj.Description;

                if (obj.ImageUrl != null)
                {
                    serviceId.ImageUrl = obj.ImageUrl;
                }
            }
        }
        
    }
}
