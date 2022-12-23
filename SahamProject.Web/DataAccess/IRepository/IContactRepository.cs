using SahamProject.Web.DataAccess.IRepository;
using SahamProject.Web.Models;

namespace SahamProject.Web.DataAccess.IRepository
{
    public interface IContactRepository :IRepository<Contact>
    {
        void Update(Contact contact);
    }
}
