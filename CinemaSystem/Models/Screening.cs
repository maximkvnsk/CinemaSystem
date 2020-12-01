using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace CinemaSystem.Models
{
    public partial class Screening
    {
        public Screening()
        {
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScreeningId { get; set; }
        public int? MovieId { get; set; }
        public int? AudithoriumId { get; set; }
        public TimeSpan? ScreeningStart { get; set; }
        public int? Cost { get; set; }

        public virtual Audithorium Audithorium { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
