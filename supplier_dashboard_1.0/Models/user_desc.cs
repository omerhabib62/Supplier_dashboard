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
    
    public partial class user_desc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user_desc()
        {
            this.db_User = new HashSet<db_User>();
        }
    
        public int user_descId { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string fullname { get; set; }
        public string company { get; set; }
        public string STN_reg_no { get; set; }
        public string office_address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string Employment_title { get; set; }
        public string contact_type { get; set; }
        public string email_address { get; set; }
        public string company_website { get; set; }
        public string fax_number { get; set; }
        public string personal_phone { get; set; }
        public string business_phone { get; set; }
        public string postal_code { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<db_User> db_User { get; set; }
    }
}