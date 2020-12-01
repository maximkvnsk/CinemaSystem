using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace CinemaSystem.Models
{
    public partial class MovieRating
    {
        public MovieRating()
        {
            Movies = new HashSet<Movie>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }
        public string RatingValue { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
