//Order Started
//Completion Percentage table.(Tasks:1.DC submitted/not?(by supplier to customer). 2. Invoice submitted/not? (by supplier to customer)
//3. PO submitted/not? (by supplier to customer). 4. Sales tax invoice submitted/not? (by supplier to customer). 5. Mailed to customer(DCinvoice) 6. Malied to supplier() 7. Best offer selected ? 10 


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using supplier_dashboard_1._0.ActionFilters;
using supplier_dashboard_1._0.Models;

namespace supplier_dashboard_1._0.Controllers

{
    [SessionTimeout]
    public class BiddingWindowController : Controller
    {
        
        public ActionResult Index()
        {
            db_vendor entities = new db_vendor();
            var model = from customer in entities.customers_requisation where customer.iscompleted == false select customer;
            var list = model.AsEnumerable();
            return View(list);
        }       

        public ActionResult Requisation(int? requisation_no)
        {
            ViewBag.requisation_no = requisation_no;
            db_vendor db = new db_vendor();
            requisation_items requisation_code = new requisation_items();

            customers_requisation model = db.customers_requisation.Where(x => x.requisation_no == requisation_no).SingleOrDefault();
            int cid = Convert.ToInt32(model.customer_user_ID);
            Session["customer"] = cid;

            
            customers_requisation quotations = db.customers_requisation.Where(x => x.requisation_no == requisation_no).SingleOrDefault();
            DateTime quote_dead = Convert.ToDateTime(quotations.quotation_deadline); 
            Session["quotation_deadline"] = quote_dead;

            IEnumerable<Bidding_Window_ViewModel> bidding_view = from requisation in db.requisation_items join requisations_items in db.items on requisation.requisation_item_code equals requisations_items.item_code where requisation.requisation_no == requisation_no select new Bidding_Window_ViewModel {
                
                item_brand_name = requisations_items.item_brand.item_brand_name,
                measured_in = requisations_items.measured_in,
                item_desc = requisations_items.item_desc,                
                size = requisations_items.size,
                price_suggester = requisation.price_suggester,
                quantity = requisation.quantity
            };

            return View(bidding_view);
        }
        
        [HttpPost]
        public ActionResult quotation_submit(IEnumerable<Bidding_Window_ViewModel> ob)
        {
            db_vendor vendor = new db_vendor();            
            quotation_items quote_items = new quotation_items();
            item item_quote = new item();
            quotation quote = new quotation();
            List<int> br_code = new List<int>();
            var desc_ID = Convert.ToInt32(Session["userdesc_ID"]);
            var customer_ID = Convert.ToInt32(Session["customer"]);
            db_User user_ = vendor.db_User.Where(x => x.user_desc_id == desc_ID).SingleOrDefault();
            int User_ID = Convert.ToInt32(user_.userID);
            Session["user_ID"] = User_ID;           
            system_order order = vendor.system_order.Where(x=>x.customer_user_ID == customer_ID).SingleOrDefault();
            int order_code_ = Convert.ToInt32(order.order_code);
            Session["order_code"]= order_code_;

           
            quote.vendor_user_id = Convert.ToInt32(Session["user_ID"]);
            quote.customer_user_id = Convert.ToInt32(Session["customer"]);
            //var format = "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz '(GMT Daylight Time)'";
            var date = Session["quotation_deadline"].ToString();
            //var submit_date = DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
            quote.submission_date =DateTime.Parse(date); 
            quote.written_on = DateTime.Now;
            quote.order_code = Convert.ToInt32(Session["order_code"]);
            quote.total_price = null;
            vendor.quotations.Add(quote);
            vendor.SaveChanges();
            int quote_ID=quote.quotation_code;
           
       
                
                    List<item_brand> o = new List<item_brand>();
                    List<decimal> ListPrice = new List<decimal>();
                    List<item> ListItem = new List<item>();
                    List<decimal> ListVOG = new List<decimal>();


                    //Enter the parameter object into database for each item in requisation
                    foreach (Bidding_Window_ViewModel brand in ob)
                    {
                    // New Item Brand in Database
                        item_brand branded = new item_brand();
                        branded.item_brand_name= brand.item_brand_name;
                        vendor.item_brand.Add(branded);
                        vendor.SaveChanges();
                        o.Add(branded);
                        br_code.Add(branded.item_brand_code);

                    //New Item in Database
                        item item_qoue = new item();
                        item_qoue.item_brand_code = branded.item_brand_code;
                        item_qoue.item_desc = brand.item_desc.ToString();
                        item_qoue.item_name = brand.item_desc.ToString();
                        item_qoue.unit_price = Convert.ToDecimal(brand.price_suggester);
                        ListPrice.Add(Convert.ToDecimal(brand.price_suggester));
                        item_qoue.size = brand.size;
                        item_qoue.measured_in = brand.measured_in;
                        item_qoue.item_category_code = null;
                        vendor.items.Add(item_qoue);
                        ListItem.Add(item_qoue);
                        vendor.SaveChanges();
                    
                    //New quotation items in database
                        quotation_items itemsa = new quotation_items();
                        itemsa.desc_ = brand.item_desc;
                        itemsa.item_code = item_qoue.item_code;
                        decimal pr = Convert.ToDecimal(item_qoue.unit_price);
                        decimal vog = pr * Convert.ToDecimal(brand.quantity);                        
                        itemsa.quotation_code = quote_ID;
                        itemsa.quantity = Convert.ToInt32(brand.quantity);
                        itemsa.value_of_good = vog;
                        vendor.quotation_items.Add(itemsa);
                        vendor.SaveChanges();
                        

                    }                         
                quotation price = vendor.quotations.FirstOrDefault(x=>x.quotation_code==quote_ID);
                price.total_price =ListVOG.Sum();
                vendor.SaveChanges();
                TempData["Message"] = "<script>alert('Quotation for Supplier submitted! You will be updated later on progress of order.')</script>";

             
            return Json(TempData["Message"]);
                // return View(mv);
        }           
    }
}

        

