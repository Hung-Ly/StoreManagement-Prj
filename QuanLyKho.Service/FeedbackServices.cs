using QuanLyKho.Data.Infrastructure;
using QuanLyKho.Data.Repositories;
using QuanLyKho.Model.Entities;

namespace QuanLyKho.Service
{
    public interface IFeedbackService
    {
        void Create(Feedback feedback);

        void Save();
    }

    public class FeedbackService : IFeedbackService
    {
        private IFeedbackRepository _feedbackRepository;
        private IUnitOfWork _unitOfWork;

        public FeedbackService(IFeedbackRepository feedbackRepository, IUnitOfWork unitOfWork)
        {
            _feedbackRepository = feedbackRepository;
            _unitOfWork = unitOfWork;
        }

        public void Create(Feedback feedback)
        {
            _feedbackRepository.Add(feedback);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}