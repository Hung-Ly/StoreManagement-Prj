using QuanLyKho.Data.Infrastructure;
using QuanLyKho.Model.Entities;

namespace QuanLyKho.Data.Repositories
{
    public interface IContactDetailRepository : IRepository<ContactDetail>
    {
    }

    public class ContactDetailRepository : RepositoryBase<ContactDetail>, IContactDetailRepository
    {
        public ContactDetailRepository(AppsDbContext context) : base(context)
        {
        }
    }
}