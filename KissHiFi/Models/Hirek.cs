using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KissHiFi.Models
{
    public class Hirek
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cím")]
        public string Cim { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy. MMMM dd. (dddd)}")]
        public DateTime Datum { get; set; }

        [AllowHtml]
        [Required]
        [Display(Name = "Hír")]
        public string Tartalom { get; set; }
    }
}