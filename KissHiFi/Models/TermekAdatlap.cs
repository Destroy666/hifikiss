using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KissHiFi.Models
{
    public enum Allapot
    {
        Új, Használt
    }

    public class TermekAdatlap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "A termék típusa")]
        public string Tipus { get; set; }

        [Required]
        public string RouteNev { get; set; }

        [Display(Name = "A termék képe")]
        public string Kep { get; set; }
        
        [Display(Name = "A termék ára")]
        [DataType(DataType.Currency)]
        public decimal Ar { get; set; }

        [AllowHtml]
        [Display(Name = "Technika információk")]
        public string TechInfo { get; set; }

        [Required]
        [Display(Name = "A termék állapota")]
        public Allapot? Allapot { get; set; }

        [Required]
        [Display(Name = "Márka")]
        [ForeignKey("TermekMarka")]
        public int TermekMarkaId { get; set; }

        [Required]
        [Display(Name = "Kategória")]
        [ForeignKey("TermekKategoria")]
        public int TermekKategoriaId { get; set; }

        public virtual TermekMarka TermekMarka { get; set; }
        public virtual TermekKategoria TermekKategoria { get; set; }
    }
}