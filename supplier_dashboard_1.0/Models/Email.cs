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
    
    public partial class Email
    {
        public int email_id { get; set; }
        public Nullable<int> email_user_ID { get; set; }
        public string email_subject { get; set; }
        public string email_from { get; set; }
        public string email_to { get; set; }
        public string email_body { get; set; }
        public string email_cc { get; set; }
        public string email_bcc { get; set; }
        public Nullable<bool> is_received_from_vendor { get; set; }
        public Nullable<bool> is_received_from_customer { get; set; }
        public Nullable<bool> is_mail_safe { get; set; }
    
        public virtual db_User db_User { get; set; }
    }
}
