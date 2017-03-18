using QuanLyKho.Data.Infrastructure;
using QuanLyKho.Data.Repositories;
using QuanLyKho.Model.Entities;

namespace QuanLyKho.Service
{
    public interface IPageService
    {
        Page GetByAlias(string alias);
    }

    public class PageService : IPageService
    {
        private IPageRepository _pageRepository;
        private IUnitOfWork _unitOfWork;

        public PageService(IPageRepository pageRepository, IUnitOfWork unitOfWork)
        {
            this._pageRepository = pageRepository;
            this._unitOfWork = unitOfWork;
        }

        public Page GetByAlias(string alias)
        {
            return _pageRepository.GetSingle(x => x.Alias == alias);
        }
    }
}