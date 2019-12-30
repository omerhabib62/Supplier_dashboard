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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class customers_requisation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customers_requisation()
        {
            this.requisation_items = new HashSet<requisation_items>();
        }

        [DisplayName("Customer ID ")]
        public Nullable<int> customer_user_ID { get; set; }

        [DisplayName("Posted On: ")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Date_of_requistion { get; set; }

        [DisplayName("Deadline: ")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> quotation_deadline { get; set; }

        [DisplayName("Order No: ")]
        public int requisation_no { get; set; }

        [DisplayName("Opened  / Closed Requisation:  ")]
        public bool iscompleted { get; set; }

        [DisplayName("Active / In Active")]
        public bool inprogress { get; set; }

        [DisplayName("Description:  ")]
        public string requisation_description { get; set; }
    
        public virtual db_User db_User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<requisation_items> requisation_items { get; set; }
    }
}