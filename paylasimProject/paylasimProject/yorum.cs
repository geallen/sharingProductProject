//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace paylasimProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class yorum
    {
        public int yorumId { get; set; }
        public Nullable<System.DateTime> yorumTarihi { get; set; }
        public string yorumIcerik { get; set; }
        public int userId { get; set; }
        public int urunId { get; set; }
    
        public virtual urun urun { get; set; }
        public virtual user user { get; set; }
    }
}