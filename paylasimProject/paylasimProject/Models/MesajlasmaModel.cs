using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace paylasimProject.Models
{
    public class MesajlasmaModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Mesaj Icerigi")]
        public string Icerik { get; set; }
    }
}