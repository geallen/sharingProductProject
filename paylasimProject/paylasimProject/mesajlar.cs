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
    
    public partial class mesajlar
    {
        public int mesajId { get; set; }
        public int gonderenId { get; set; }
        public int gonderilenId { get; set; }
        public string mesajIcerik { get; set; }
        public string mesajKonusu { get; set; }
        public Nullable<System.DateTime> gonderilmeTarihi { get; set; }
    
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
    }
}