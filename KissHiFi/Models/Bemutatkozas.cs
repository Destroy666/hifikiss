using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KissHiFi.Models
{
    public class Bemutatkozas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [AllowHtml]
        [Required]
        [Display(Name = "Bemutatkozás")]
        public string Tartalom { get; set; }
    }
}