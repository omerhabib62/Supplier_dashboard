//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace supplier_dashboard_1._0.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DC_invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DC_invoice()
        {
            this.DC_items = new HashSet<DC_items>();
        }
    
        public int DC_invoice_ID { get; set; }
        public Nullable<int> PO_Code { get; set; }
        public Nullable<System.DateTime> invoice_date { get; set; }
        public Nullable<int> supplier_userID { get; set; }
        public Nullable<decimal> total { get; set; }
    
        public virtual db_User db_User { get; set; }
        public virtual PO PO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_items> DC_items { get; set; }
    }
}
