using System.Threading.Tasks;

namespace QuanLyKho.Service
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}