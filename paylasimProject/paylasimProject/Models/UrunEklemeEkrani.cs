using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace paylasimProject.Models
{
    public class UrunEklemeEkrani
    {
        [Required]
       // [Required(ErrorMessage = "Urun Adi bos gecilemez")]
        [DataType(DataType.Text)]
        [Display(Name = "Urun Adi")]
        public string UrunAdi { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Urun Resmi")]
        public HttpPostedFileBase UrunResmi { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Urun Durumu")]
        public string UrunDurumu { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Urun Bilgisi")]
        public string UrunBilgisi { get; set; }

        //[Required]
        [DataType(DataType.Duration)]
        [Display(Name = "User Id")]
        public int UserId { get; set; }




    }
}