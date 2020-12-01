using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace CinemaSystem.Models
{
    public partial class Reservation
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId { get; set; }
        public int? ScreeningId { get; set; }
        public int? EmployeeId { get; set; }
        public bool? Reserved { get; set; }
        public bool? Paid { get; set; }
        public bool Active { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Screening Screening { get; set; }
    }
}
