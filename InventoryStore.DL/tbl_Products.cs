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
    
    public partial class tbl_Products
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string SKU { get; set; }
        public int Supplier_Id { get; set; }
        public int Category_Id { get; set; }
        public int Brand_Id { get; set; }
        public int Store_Id { get; set; }
        public string Product_Description { get; set; }
        public int Product_Quantity { get; set; }
        public decimal Price { get; set; }
        public System.DateTime ExpiryDate { get; set; }
        public bool Availability { get; set; }
    
        public virtual tbl_Brands tbl_Brands { get; set; }
        public virtual tbl_Categories tbl_Categories { get; set; }
        public virtual tbl_Stores tbl_Stores { get; set; }
        public virtual tbl_Supplier tbl_Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Orders> tbl_Orders { get; set; }
    }
}
