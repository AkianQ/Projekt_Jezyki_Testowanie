using System.ComponentModel.DataAnnotations;

namespace ContactFormProject.Models
{
    public class ContactModel
    {
        [Required]
        public string Imie { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(254, ErrorMessage = "Email nie mo�e przekracza� 254 znak�w.")]
        public string Email { get; set; }

        [Required]
        public string Wiadomosc { get; set; }
    }
}
