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
    
    public partial class general_sales_Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public general_sales_Invoice()
        {
            this.general_sales_items = new HashSet<general_sales_items>();
        }
    
        public int Invoice_ID { get; set; }
        public Nullable<int> supplier_userID { get; set; }
        public Nullable<int> PO_code { get; set; }
        public Nullable<int> quotation_code { get; set; }
        public Nullable<System.DateTime> invoice_date { get; set; }
        public Nullable<decimal> total { get; set; }
    
        public virtual db_User db_User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<general_sales_items> general_sales_items { get; set; }
        public virtual PO PO { get; set; }
        public virtual quotation quotation { get; set; }
    }
}
