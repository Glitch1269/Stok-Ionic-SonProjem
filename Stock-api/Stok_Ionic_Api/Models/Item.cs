//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stok_Ionic_Api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.Kayit = new HashSet<Kayit>();
        }
    
        public string itemId { get; set; }
        public string itemKatTur { get; set; }
        public string itemAdi { get; set; }
        public int itemMiktar { get; set; }
        public string itemKayitTarih { get; set; }
        public string itemDuzenlenmeTarih { get; set; }
        public string itemResim { get; set; }
        public byte[] itemPng { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kayit> Kayit { get; set; }
    }
}