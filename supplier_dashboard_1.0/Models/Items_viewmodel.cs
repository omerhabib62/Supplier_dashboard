    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace supplier_dashboard_1._0.Models
{
    public class Items_viewmodel
    {
        public IEnumerable<item> Items{get; set;}
        public IEnumerable<item_brand> Item_brand { get; set; }
        public IEnumerable<item_category> Item_category { get; set; }

    }
}