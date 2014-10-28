using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KissHiFi.Models
{
    public class Szolgaltatas
    {
        [Key]
        public int Id { get; set; }

        [AllowHtml]
        [Required]
        [Display(Name = "Szolgáltatás")]
        public string Tevekenyseg { get; set; }

        [AllowHtml]
        [Required]
        [Display(Name = "Szervíz")]
        public string Szerviz { get; set; }

        [AllowHtml]
        [Required]
        [Display(Name = "Hangosítás")]
        public string Hangositas { get; set; }
    }
}