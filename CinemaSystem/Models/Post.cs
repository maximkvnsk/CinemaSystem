using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace CinemaSystem.Models
{
    public partial class Post
    {
        public Post()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }
        public string PostName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
