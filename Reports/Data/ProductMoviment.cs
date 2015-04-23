//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Reports.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductMoviment
    {
        public int ID { get; set; }
        public decimal Quantity { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public bool Deleted { get; set; }
        public Nullable<int> Product_ID { get; set; }
        public Nullable<int> Entry_ID { get; set; }
        public Nullable<int> PurchaseOrder_ID { get; set; }
    
        public virtual Entry Entry { get; set; }
        public virtual Product Product { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}