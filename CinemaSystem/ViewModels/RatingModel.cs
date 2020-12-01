using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaSystem.ViewModels
{
    public class RatingModel
    {
        public int RatingId { get; set; }
        public string  RatingValue { get; set; }
        public List<SelectListItem> MovieRatings { set; get; }
    }
}