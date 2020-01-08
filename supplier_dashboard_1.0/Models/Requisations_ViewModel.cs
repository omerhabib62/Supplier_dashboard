using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace supplier_dashboard_1._0.Models
{
    public class Requisations_ViewModel
    {
        [DisplayName("S.No")]
        public int customer_user_ID { get; set; }

        [DisplayName("Created On")]
        public System.DateTime Date_of_requistion { get; set; }

        [DisplayName("Submission Deadline")]
        public System.DateTime quotation_deadline { get; set; }

        [DisplayName("Requisation Number")]
        public int requisation_no { get; set; }

        public bool iscompleted { get; set; }
        public bool inprogress { get; set; }
        [DisplayName("Description")]
        public string requisation_description { get; set; }
    }
}