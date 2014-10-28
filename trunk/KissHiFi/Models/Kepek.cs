using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KissHiFi.Models
{
    public class Kepek
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Fájl(ok)")]
        public string FajlNev { get; set; }
        
        [Display(Name = "A kép címe")]
        public string Cim { get; set; }
    }
}