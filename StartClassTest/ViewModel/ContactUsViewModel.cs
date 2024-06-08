using System.ComponentModel.DataAnnotations;

namespace StartClassTest.ViewModel
{
    public class ContactUsViewModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Message { get; set; }
    }
}
