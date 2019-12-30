using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using supplier_dashboard_1._0.Models;
using System.Globalization;

namespace supplier_dashboard_1._0.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(db_User db_User)
        {
            try
            {
                using (db_vendor db = new db_vendor())
                {
                    var userDetails = db.db_User.Where(x => x.user_loginID == db_User.user_loginID && x.user_password == db_User.user_password).FirstOrDefault();
                    if (userDetails == null)
                    {
                        db_User.LoginErrorMessage = " !! Wrong username or password.";
                        return View("Index", db_User);
                    }
                    else
                    {
                        TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                        Session["userID"] = userDetails.user_desc.company;
                        Session["UI"] = cultInfo.ToTitleCase(Session["userID"].ToString());                              
                        Session["userName"] = userDetails.user_password;
                        Session["userdesc"] = userDetails.user_desc_id;
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
            }
            catch (Exception ex)
            {
               string exa = ex.ToString();
               return RedirectToAction("Index");
            }
        }
        public ActionResult forgotpassword()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult register()
        {
            db_vendor db = new db_vendor();
            List<string> CountryList = new List<string>();
            CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo CInfo in CInfoList)
            {
                RegionInfo R = new RegionInfo(CInfo.LCID);
                if (!(CountryList.Contains(R.EnglishName)))
                {
                    CountryList.Add(R.EnglishName);
                }
            }

            CountryList.Sort();
            ViewBag.CountryList = CountryList;
            return View();
            
        }
    
        [HttpPost]
        public JsonResult remote_Password_validate(string user_password)
        {
            return Json(IsPasswordAvailable(user_password));
        }
        public bool IsPasswordAvailable(string _password)
        {
            bool status=false;
            db_vendor db = new db_vendor();
            var query = db.db_User.Any(name => name.user_password.Equals(_password));
            if (query != false)
            {   
                status = false; //Already registered  
            }
            else
            {  
                status = true;   //Available to use  
            }
            return status;
        }
        [HttpPost]
        public JsonResult IsAlreadySigned(string user_loginID)
        {
            return Json(IsUserAvailable(user_loginID));
        }
        public bool IsUserAvailable(string user_id)
        {
            bool status=false;
            db_vendor db = new db_vendor();
            var query = db.db_User.Any(name => name.user_loginID.Equals(user_id));
            if (query != false)
            {   
                status = false; //Already registered  
            }
            else
            {   
                status = true;  //Available to use  
            }
            return status;
        }   

       [HttpPost]
        public ActionResult register([Bind(Include = "firstname,lastname,user_loginID,user_password,company,email_address,company_website,office_address,city,country,personal_phone,business_phone,postal_code,Employment_title,fax_number,STN_reg_no")]  Registration_View_Model user)
        {

                db_vendor db = new db_vendor();
                user_desc fesc = new user_desc();

                fesc.firstname = user.firstname;
                fesc.lastname = user.lastname;
                fesc.fullname = user.firstname +" "+ user.lastname;
                fesc.company = user.company;
                fesc.country = user.country;
                fesc.city = user.city;
                fesc.STN_reg_no = user.STN_reg_no;
                fesc.office_address = user.office_address;
                fesc.postal_code = user.postal_code;
                fesc.Employment_title = user.Employment_title;
                fesc.contact_type = "business";
                fesc.business_phone = user.business_phone;
                fesc.personal_phone = user.personal_phone;
                fesc.email_address = user.email_address;
                fesc.fax_number = user.fax_number;
                fesc.company_website = user.company_website;
                db.user_desc.Add(fesc);
                db.SaveChanges();

                int dbuser_desc_ID = fesc.user_descId;

                db_User usewr = new db_User();
                usewr.user_desc_id = dbuser_desc_ID;
                usewr.user_loginID = user.user_loginID;
                usewr.user_password = user.user_password;
                usewr.is_admin = false;
                usewr.is_customer = false;
                usewr.is_supplier = true;
                db.db_User.Add(usewr);
                db.SaveChanges();
                ViewBag.Message = "Congrats ! You have been added in Vendor Assistance. Enter your Supplier UserID and password to access Vendor Assistance Supplier Portal";
                return RedirectToAction("Index", "Home");
            
        }

     
        public ActionResult LogOut()
        {
            string userId = (string)Session["UI"];
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        } 
    }
}
