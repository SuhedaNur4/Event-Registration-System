using System;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationSystem.Models
{
    public class Registration
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Etkinlik seçimi zorunludur.")]
        [Display(Name = "Etkinlik")]
        public int EventId { get; set; }

        public Event? Event { get; set; }

        [Required(ErrorMessage = "Katılımcı seçimi zorunludur.")]
        [Display(Name = "Katılımcı")]
        public int ParticipantId { get; set; }

        public Participant? Participant { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
