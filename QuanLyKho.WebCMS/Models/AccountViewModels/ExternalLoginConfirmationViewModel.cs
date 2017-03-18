using System.ComponentModel.DataAnnotations;

namespace QuanLyKho.WebCMS.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}