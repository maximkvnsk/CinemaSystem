using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaSystem.Models
{

 
    public partial class Employee
    {
        public Employee()
        {
            Reservations = new HashSet<Reservation>();
        }

       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public int? PostId { get; set; }

        public virtual Post Post { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
