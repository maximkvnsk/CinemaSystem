using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace CinemaSystem.Models { 
    public partial class Movie
    {
        public Movie()
        {
            Screenings = new HashSet<Screening>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Description { get; set; }
        public int? Duration { get; set; }
        public int? MovieRating { get; set; }

        public virtual MovieRating MovieRatingNavigation { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
