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
    
    public partial class urun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public urun()
        {
            this.rezerv = new HashSet<rezerv>();
            this.yorum = new HashSet<yorum>();
        }
    
        public int urunId { get; set; }
        public string urunAdi { get; set; }
        public string urunResmi { get; set; }
        public string urunDurumu { get; set; }
        public string urunBilgisi { get; set; }
        public string urunPath { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rezerv> rezerv { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yorum> yorum { get; set; }
    }
}