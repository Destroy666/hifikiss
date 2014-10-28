using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KissHiFi.Models
{
    public class Elerhetoseg
    {
        [Key]
        public int Id { get; set; }

        [AllowHtml]
        [Required]
        [Display(Name = "Elérhetőség")]
        public string Tartalom { get; set; }
    }
}