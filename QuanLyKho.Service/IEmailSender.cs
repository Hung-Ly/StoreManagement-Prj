using System.Threading.Tasks;

namespace QuanLyKho.Service
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}