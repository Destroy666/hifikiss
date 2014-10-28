using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KissHiFi.Models
{
    public class TermekKategoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Termék kategória")]
        public string Nev { get; set; }

        [Required]
        public string RouteNev { get; set; }

        [Required]
        [Display(Name = "Kategóriát jellemző kép")]
        public string Kep { get; set; }

        public ICollection<TermekAdatlap> TermekAdatlaps { get; set; }
    }
}