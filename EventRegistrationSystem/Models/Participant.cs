using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationSystem.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "E-posta zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Display(Name = "Bölüm")]
        public string Department { get; set; }

        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
