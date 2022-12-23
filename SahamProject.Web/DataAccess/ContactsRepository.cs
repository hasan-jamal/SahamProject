using SahamProject.Web.DataAccess.IRepository;
using SahamProject.Web.Models;

namespace SahamProject.Web.DataAccess.Repository
{
    public class ContactsRepository : Repository<Contact> , IContactRepository
    {
        private readonly SahamProjectContext _db;

        public ContactsRepository(SahamProjectContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Contact coverType)
        {
            _db.Contacts.Update(coverType);
        }
    }
}
