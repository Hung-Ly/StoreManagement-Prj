using QuanLyKho.Data.Infrastructure;
using QuanLyKho.Model.Entities;

namespace QuanLyKho.Data.Repositories
{
    public interface IProductTagRepository : IRepository<ProductTag>
    {
    }

    public class ProductTagRepository : RepositoryBase<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(AppsDbContext context) : base(context)
        {
        }
    }
}