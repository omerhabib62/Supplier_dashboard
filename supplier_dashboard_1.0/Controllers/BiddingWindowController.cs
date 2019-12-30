using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using supplier_dashboard_1._0.Models;

namespace supplier_dashboard_1._0.Controllers

{
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
            IEnumerable<Bidding_Window_ViewModel> bidding_view = from requisation in db.requisation_items join requisations_items in db.items on requisation.requisation_item_code equals requisations_items.item_code where requisation.requisation_no == requisation_no select new Bidding_Window_ViewModel {
                requisation_item_code = requisation.requisation_item_code,
                item_name = requisations_items.item_name,
                item_brand_name = requisations_items.item_brand.item_brand_name,
                measured_in = requisations_items.measured_in,
                item_desc = requisations_items.item_desc,
                item_category_name = requisations_items.item_category.item_category_name,
                size = requisations_items.size,
                price_suggester = requisation.price_suggester,
                quantity = requisation.quantity
            };

            return View(bidding_view);
        }
        
        public JsonResult quotation_submit(List<Bidding_Window_ViewModel> bidding)
        {
            using (db_vendor entities = new db_vendor())
            {
                //Truncate Table to delete all old records.
                entities.Database.ExecuteSqlCommand("TRUNCATE TABLE [Customers]");

                //Check for NULL.
                if (bidding == null)
                {
                    bidding = new List<Bidding_Window_ViewModel>();
                }

                //Loop and insert records.
                foreach (Bidding_Window_ViewModel bid in bidding)
                {
                    //entities.bidding.Add(bid);
                }
                int insertedRecords = entities.SaveChanges();
                return Json(insertedRecords);
            }
        }
        //public JsonResult Add_item(Bidding_Window_ViewModel mv)
        //{
        //    Bidding_Window_ViewModel model_sent = new Bidding_Window_ViewModel();

        //    model_sent.item_name = mv.item_name;
        //    model_sent.item_desc = mv.item_desc;
        //    model_sent.measured_in = mv.measured_in;
        //    model_sent.size = mv.size;
        //    model_sent.unit_price = mv.unit_price;
        //    model_sent.item_category_name = mv.item_category_name;
        //    model_sent.item_brand_name = mv.item_brand_name;
        //    model_sent.quantity = mv.quantity;
        //    return Json(mv);

        //}
        //[HttpGet]
        //public ActionResult Add_new_item()
        //{
        //    return PartialView();
        //}
        //[HttpPost]
        //public ActionResult Add_new_item(Bidding_Window_ViewModel vm)
        //{
        //    return PartialView();
        //}
        //[HttpPost]
        //public ActionResult Requisation(Bidding_Window_ViewModel mv)
        //{
        //    try
        //    {
        //        db_vendor db = new db_vendor();

        //        if (mv.item_code>0)
        //        {
        //            requisation_items req = db.requisation_items.SingleOrDefault(x => x.item.item_code == mv.item_code);
        //            req.item.item_name=mv.item_name;
        //            req.item.item_desc=mv.item_desc;
        //            req.item.item_category.item_category_name=mv.item_category_name;
        //            req.item.item_brand.item_brand_name = mv.item_brand_name;
        //            req.item.measured_in = mv.measured_in;
        //            req.item.size = mv.size;
        //            req.item.unit_price = mv.unit_price;
        //            req.quantity = mv.quantity;                    
        //        }
        //        else
        //        {
        //            item i = new item();
        //            i.item_name = mv.item_name;
        //            i.item_desc = mv.item_desc;
        //            db.items.Add(i);
        //            db.SaveChanges();
        //        }
        //        return View(mv);
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}       

        //public ActionResult edit_item(int? item_code)
        //{
        //    db_vendor vendor = new db_vendor();
        //    Bidding_Window_ViewModel item_present = new Bidding_Window_ViewModel();
        //    List<Bidding_Window_ViewModel> list = new List<Bidding_Window_ViewModel>();
        //    if (item_code >0)
        //    {

        //        item req = vendor.items.Where(x => x.item_code == item_code).FirstOrDefault();
        //        item_present.item_code = req.item_code;
        //        item_present.item_name = req.item_name;
        //        item_present.item_desc = req.item_desc;
        //        list.Add(item_present);
        //    }
        //    return PartialView("edit_item", list);
        //}
        //[HttpPost]
        //public JsonResult edit_item(Bidding_Window_ViewModel present)
        //{
        //    db_vendor vendor = new db_vendor();
        //    item reqi = vendor.items.Where(x => x.item_code == present.item_code).FirstOrDefault();
        //    item reqis = new item();
        //    reqis.item_code = present.item_code;
        //    reqis.item_name = present.item_name;
        //    reqis.item_desc = present.item_desc;
        //    vendor.SaveChanges();
        //    return Json(reqi,JsonRequestBehavior.AllowGet);
        //}

    }
}

        

