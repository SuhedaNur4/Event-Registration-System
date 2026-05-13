using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationSystem.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Etkinlik Adı zorunludur.")]
        [Display(Name = "Etkinlik Adı")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Konum zorunludur.")]
        [Display(Name = "Konum")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Tarih zorunludur.")]
        [Display(Name = "Tarih")]
        [DataType(DataType.DateTime)]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Kapasite zorunludur.")]
        [Display(Name = "Kapasite")]
        [Range(1, int.MaxValue, ErrorMessage = "Kapasite 1'den büyük olmalıdır.")]
        public int Capacity { get; set; }

        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
