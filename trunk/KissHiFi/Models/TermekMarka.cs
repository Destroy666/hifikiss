using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KissHiFi.Models
{
    public class TermekMarka
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Márka")]
        public string Nev { get; set; }

        [Required]
        public string RouteNev { get; set; }

        [Required]
        [Display(Name = "Márkajelzés (kép)")]
        public string Kep { get; set; }

        public ICollection<TermekAdatlap> TermekAdatlaps { get; set; }
    }
}