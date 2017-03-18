using System.ComponentModel.DataAnnotations;

namespace QuanLyKho.WebCMS.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}