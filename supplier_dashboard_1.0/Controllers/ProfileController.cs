using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using supplier_dashboard_1._0.Models;
namespace supplier_dashboard_1._0.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        private db_vendor db  = new db_vendor();
        

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["userdesc_ID"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int use_id= Convert.ToInt32(Session["userdesc_ID"]);
            user_desc Userdesc = db.user_desc.Where(x=>x.user_descId== use_id).SingleOrDefault() ;

            Profile_VIewModel obj = new Profile_VIewModel();

            obj.id = Userdesc.user_descId;
            obj.firstname = Userdesc.firstname;
            obj.lastname = Userdesc.lastname;
            obj.FullName = Userdesc.fullname;
            obj.City = Userdesc.city;
            obj.CompanyName = Userdesc.company;
            obj.Country = Userdesc.country;
            obj.Fax = Userdesc.fax_number;
            obj.personalphone = Userdesc.personal_phone;
            obj.OfficeAddress = Userdesc.office_address;
            obj.OfficeNumber = Userdesc.business_phone;
            obj.Postal = Userdesc.postal_code;
            obj.Stn_reg_num = Userdesc.STN_reg_no;
            obj.WebSite = Userdesc.company_website;
            obj.email = Userdesc.email_address;
            if (Userdesc == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Profile_VIewModel db_User)
        {          
            int s= Convert.ToInt32(Session["userdesc_ID"]);
            user_desc Userdesc = db.user_desc.FirstOrDefault(x => x.user_descId== s);
            //user_desc Userdesc = db.user_desc.Where(x=>x.user_descId== s).SingleOrDefault();

                Userdesc.fullname = db_User.FullName;
                Userdesc.lastname = db_User.lastname;
                Userdesc.company = db_User.CompanyName;
                Userdesc.company_website = db_User.WebSite;
                Userdesc.personal_phone = db_User.personalphone;
                Userdesc.office_address = db_User.OfficeAddress;
                Userdesc.firstname = db_User.firstname;
                Userdesc.country = db_User.Country;
                Userdesc.fax_number = db_User.Fax;
                Userdesc.city = db_User.City;
                Userdesc.STN_reg_no = db_User.Stn_reg_num;
                Userdesc.postal_code = db_User.Postal;

                Userdesc.business_phone = db_User.OfficeNumber;
                Userdesc.email_address = db_User.email;
            
                db.SaveChanges();
                TempData["Message"] = "<script>alert('Profile updated successfully')</script>";            
            
            return RedirectToAction("Index","Dashboard");
        }
       


    }
}