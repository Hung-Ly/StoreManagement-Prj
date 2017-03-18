using QuanLyKho.Data.Infrastructure;
using QuanLyKho.Model.Entities;

namespace QuanLyKho.Data.Repositories
{
    public interface IVisitorStatisticRepository : IRepository<VisitorStatistic>
    {
    }

    public class VisitorStatisticRepository : RepositoryBase<VisitorStatistic>, IVisitorStatisticRepository
    {
        public VisitorStatisticRepository(AppsDbContext context) : base(context)
        {
        }
    }
}