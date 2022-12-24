using SahamProject.Web.DataAccess.IRepository;
using SahamProject.Web.DataAccess.Repository;
using SahamProject.Web.Models;

namespace SahamProject.Web.DataAccess
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        public StatusRepository(SahamProjectContext db) : base(db)
        {
        }
    }
}
