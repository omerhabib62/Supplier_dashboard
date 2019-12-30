using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace supplier_dashboard_1._0.Models
{
    public class Bidding_Window_ViewModel
    {
        //item table
        [DisplayName("Item Code")]
        public int item_code { get; set; }

        [DisplayName("Description")]
        public string item_name { get; set; }
        
        public Nullable<int> item_category_code { get; set; }
        
        public Nullable<int> item_brand_code { get; set; }

        [DisplayName("Description")]
        public string item_desc { get; set; }

        [DisplayName("Rate")]
        public Nullable<decimal> unit_price { get; set; }

        [DisplayName("Unit")]
        public string measured_in { get; set; }

        [DisplayName("Size")]
        public string size { get; set; }

        //item_brand table
        [DisplayName("Brand")]
        public string item_brand_name { get; set; }

        //item_category table
        [DisplayName("Category")]
        public string item_category_name { get; set; }

        //quotation table       
        public Nullable<int> quotation_code { get; set; }
        public Nullable<int> vendor_user_id { get; set; }
        public Nullable<int> customer_user_id { get; set; }
        public Nullable<System.DateTime> submission_date { get; set; }
        public Nullable<System.DateTime> written_on { get; set; }
        public Nullable<int> order_code { get; set; }
        public Nullable<decimal> total_price { get; set; }

        //quotation_items table
        
        [DisplayName("Quantity")]
        public string quantity { get; set; }
        public string desc_ { get; set; }
        public Nullable<decimal> value_of_good { get; set; }

        //system_order table

        public Nullable<int> customer_user_ID { get; set; }
        public Nullable<int> supplier_user_ID { get; set; }
        //public string desc_ { get; set; }
        public Nullable<System.DateTime> start_order_date { get; set; }
        public Nullable<System.DateTime> end_order_date { get; set; }
        public string commpletion_percentage { get; set; }


        //customer_requistation table
        public Nullable<int> r_customer_user_ID { get; set; }
        public Nullable<System.DateTime> Date_of_requistion { get; set; }
        public Nullable<System.DateTime> quotation_deadline { get; set; }
        public Nullable<int> user_desc { get; set; }
        public int? requisation_no { get; set; }

        //requistation_items table
        public Nullable<int> itemtable_requisation_no { get; set; }
        [DisplayName("Item Code")]
        public Nullable<int> requisation_item_code { get; set; }
        public string requisation_desc { get; set; }
       

        [DisplayName("Rate")]
        public string price_suggester { get; set; }

        


    }
}