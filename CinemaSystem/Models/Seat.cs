using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace CinemaSystem.Models
{
    public partial class Seat
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatId { get; set; }
        public int? Row { get; set; }
        public int? Number { get; set; }
        public int? AudithoriumId { get; set; }

        public virtual Audithorium Audithorium { get; set; }
    }
}
