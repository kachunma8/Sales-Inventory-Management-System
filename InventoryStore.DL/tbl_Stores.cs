//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryStore.DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Stores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Stores()
        {
            this.tbl_Products = new HashSet<tbl_Products>();
        }
    
        public int Store_Id { get; set; }
        public string Store_Name { get; set; }
        public bool Store_Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Products> tbl_Products { get; set; }
    }
}
