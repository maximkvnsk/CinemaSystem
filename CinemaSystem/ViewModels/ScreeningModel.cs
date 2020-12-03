using  System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaSystem.ViewModels
{
    public class ScreeningModel
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public List<SelectListItem> Movies { set; get; }

        public int AudithoriumId { get; set; }
        public string AudithoriumName { get; set; }
        public List<SelectListItem> Audithoriums { set; get; }
    }
}