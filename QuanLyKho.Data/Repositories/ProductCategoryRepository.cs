using QuanLyKho.Data.Infrastructure;

using QuanLyKho.Model.Entities;

namespace QuanLyKho.Data.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(AppsDbContext context) : base(context)
        {
        }
    }
}