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
    
    public partial class supplier_items
    {
        public int supplier_item_id { get; set; }
        public Nullable<int> item_code { get; set; }
        public Nullable<int> userID { get; set; }
    
        public virtual db_User db_User { get; set; }
        public virtual item item { get; set; }
    }
}
