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
    
    public partial class quotation_items
    {
        public int quotation_items_code { get; set; }
        public Nullable<int> quotation_code { get; set; }
        public Nullable<int> item_code { get; set; }
        public Nullable<int> quantity { get; set; }
        public string desc_ { get; set; }
        public Nullable<decimal> value_of_good { get; set; }
    
        public virtual item item { get; set; }
        public virtual quotation quotation { get; set; }
    }
}
