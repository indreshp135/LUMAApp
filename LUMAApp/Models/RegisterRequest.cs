using System.ComponentModel.DataAnnotations;

namespace LUMAApp.Models
{
    public class RegisterRequest
    {
        [Required]
        public string? Name;

        [Required]
        public string? Email;

        [Required]
        public string? Password;
    }
}
