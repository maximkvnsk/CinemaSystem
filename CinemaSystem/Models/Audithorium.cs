using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace CinemaSystem.Models
{
    public partial class Audithorium
    {
        public Audithorium()
        {
            Screenings = new HashSet<Screening>();
            Seats = new HashSet<Seat>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AudithoriumId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Screening> Screenings { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
