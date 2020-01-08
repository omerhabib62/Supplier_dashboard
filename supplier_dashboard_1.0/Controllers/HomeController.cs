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
using System.Text;
using System.Net.Mail;
using System.Net;

namespace supplier_dashboard_1._0.Controllers
{
    public class HomeController : Controller
    {
        db_vendor db = new db_vendor();
        [HttpGet]
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["User"];
            if(cookie != null)
            {
                ViewBag.username = cookie["userID"].ToString();
                string Encrypted = cookie["password"].ToString();
                byte[] b = Convert.FromBase64String(Encrypted);                
                ViewBag.password = ASCIIEncoding.ASCII.GetString(b);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(db_User db_User)
        {
            HttpCookie cookie = new HttpCookie("User");
            try
            {
                    if (db_User.RememberMe == true)
                    {
                        cookie["userID"] = db_User.user_loginID;
                        byte[] b = ASCIIEncoding.ASCII.GetBytes(db_User.user_password);
                        cookie["password"] = Convert.ToBase64String(b);
                        cookie.Expires = DateTime.Now.AddDays(4);
                        HttpContext.Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        cookie.Expires = DateTime.Now.AddDays(-1);//destroy cookie
                        HttpContext.Response.Cookies.Add(cookie);

                    }

                    var userDetails = db.db_User.Where(x => x.user_loginID == db_User.user_loginID && x.user_password == db_User.user_password).SingleOrDefault();

                if (userDetails == null)

                {
                    db_User.LoginErrorMessage = " Enter Correct UserID / password.";
                    TempData["Message"] = "<script>alert('Unsuccessful Attempt !')</script>";
                    return View("Index", db_User);
                }
                else
                {
                    TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                    Session["user"] = userDetails.user_desc_id;
                    int usersd = Convert.ToInt32(Session["user"].ToString());
                    TempData["userdesc_ID"] = usersd;
                    Session["userdesc_ID"] = usersd;
                    TempData["Message"] = "<script>alert('Login Successful! Welcome Aboard')</script>";
                    return RedirectToAction("Index", "Dashboard");
                }
                
            }
            catch (Exception ex)
            {
               string exa = ex.ToString();
               return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult forgotpassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult forgotpassword(string vendor_ID)
        {
            //Verify Email ID
            //Generate Reset password link 
            //Send Email 
            string message = "";
            bool status = false;
            int se = Convert.ToInt32(TempData["userdesc_ID"]);

            using (db_vendor dc = new db_vendor())
            {
                var account = dc.user_desc.Where(a => a.user_descId == se).FirstOrDefault();
                if (account != null)
                {
                    //Send email for reset password
                    string resetCode = Guid.NewGuid().ToString();
                    SendVerificationLinkEmail(account.email_address, resetCode, "ResetPassword");
                    account.ResetPasswordCode = resetCode;
                    //This line I have added here to avoid confirm password not match issue , as we had added a confirm password property 
                    //in our model class in part 1
                    dc.Configuration.ValidateOnSaveEnabled = false;
                    dc.SaveChanges();
                    message = "Reset password link has been sent to your email id.";
                }
                else
                {
                    message = "Sorry ! Account not found. Enter Correct Email Address";
                }
            }
            ViewBag.Message = message;
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
        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode, string emailFor = "VerifyAccount")
        {
            var verifyUrl = "/User/" + emailFor + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("dotnetawesome@gmail.com", "Dotnet Awesome");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "******"; // Replace with actual password

            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount")
            {
                subject = "Your account is successfully created!";
                body = "<br/><br/>We are excited to tell you that your Dotnet Awesome account is" +
                    " successfully created. Please click on the below link to verify your account" +
                    " <br/><br/><a href='" + link + "'>" + link + "</a> ";
            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "Hi,<br/>br/>We got request for reset your account password. Please click on the below link to reset your password" +
                    "<br/><br/><a href=" + link + ">Reset Password link</a>";
            }


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }
        public ActionResult LogOut()
        {
            string userId = Session["user"].ToString();
            Session.Abandon();            
            return RedirectToAction("Index", "Home");
        } 
    }
}
