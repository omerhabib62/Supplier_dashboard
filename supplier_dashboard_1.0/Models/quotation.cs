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
    
    public partial class quotation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public quotation()
        {
            this.general_sales_Invoice = new HashSet<general_sales_Invoice>();
            this.POes = new HashSet<PO>();
            this.quotation_items = new HashSet<quotation_items>();
            this.ST_invoice = new HashSet<ST_invoice>();
        }
    
        public int quotation_code { get; set; }
        public Nullable<int> vendor_user_id { get; set; }
        public Nullable<int> customer_user_id { get; set; }
        public Nullable<System.DateTime> submission_date { get; set; }
        public Nullable<System.DateTime> written_on { get; set; }
        public Nullable<int> order_code { get; set; }
        public Nullable<decimal> total_price { get; set; }
    
        public virtual db_User db_User { get; set; }
        public virtual db_User db_User1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<general_sales_Invoice> general_sales_Invoice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PO> POes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<quotation_items> quotation_items { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ST_invoice> ST_invoice { get; set; }
    }
}
