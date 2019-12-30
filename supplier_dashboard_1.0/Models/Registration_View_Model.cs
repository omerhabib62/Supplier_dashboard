using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace supplier_dashboard_1._0.Models
{
    public class Registration_View_Model
    {
        //User Desciption Table

        [Required(ErrorMessage = "Enter Your First Name"), MinLength(3, ErrorMessage = "At Least 3 characters !"), MaxLength(50, ErrorMessage = "Max 50 characters !")]
        [DisplayName("First Name")]
        public string firstname { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Enter Your Last Name"), MinLength(3, ErrorMessage = "At Least 3 characters !"), MaxLength(50, ErrorMessage = "Max 50 characters !")]
        public string lastname { get; set; }

        [DisplayName("Supplier's Company Name")]
        [Required(ErrorMessage = "Enter Company Name"), MinLength(3, ErrorMessage = "At Least 3 characters !"), MaxLength(30, ErrorMessage = "Max 30 characters !")]
        public string company { get; set; }

        [DisplayName("Supplier's Company STN Name(Use dash to seperate.).")]
        [DisplayFormat()]
        [Required(ErrorMessage = "Enter Your STN Registration of Your Company")]
        [RegularExpression(@"^\d{10}|\d{3}-\d{3}-\d{3}-\d{1}$", ErrorMessage = "Invalid STN Number(10 digit STN Number )")]
        public string STN_reg_no { get; set; }

        [DisplayName("Company's Office Address")]
        [Required(ErrorMessage = "Enter Office Address !"), MinLength(20, ErrorMessage = "Enter proper Office Address!"), MaxLength(500, ErrorMessage = "Max 500 characters !")]
        public string office_address { get; set; }

        [DisplayName("Company's City")]
        [Required(ErrorMessage = "Enter Your City"), MinLength(3), MaxLength(30)]
        public string city { get; set; }

        [DisplayName("Company's Country")]
        [Required(ErrorMessage = "Please select Country")]
        public string country { get; set; }

        [DisplayName("Company Postal Code")]
        [Required(ErrorMessage = "Enter Postal Code for Your Organization")]
        public string postal_code { get; set; }

        [DisplayName("Supplier's Employment Title")]
        [Required(ErrorMessage = "Enter your Employment Title in Company")]
        public string Employment_title { get; set; }

        [DisplayName("Supplier's Email Address")]
        [Required(ErrorMessage = "Enter Company's/Your Personal email Address")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email Address not valid !")]
        public string email_address { get; set; }

        // [Required(ErrorMessage = "Enter your company's Web Address Address")]
        [DisplayName("Supplier's Company Website Address")]
        [RegularExpression(@"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$", ErrorMessage = "Please enter a valid website")]
        public string company_website { get; set; }

        [DisplayName("Company's Fax Number")]
        public string fax_number { get; set; }

        [DisplayName("Company's / Supplier's Phone Number")]
        [Required(ErrorMessage = "Enter Personal Contact Number"), MinLength(8), MaxLength(500)]
        [RegularExpression(@"^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$", ErrorMessage = " Not a valid phone number")]
        public string personal_phone { get; set; }

        [DisplayName("Company's Number")]
        [Required(ErrorMessage = "Enter Office Number"), MinLength(8), MaxLength(500)]
        [RegularExpression(@"^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$", ErrorMessage = " Not a valid phone number")]
        public string business_phone { get; set; }


        //db_user Table
        [DisplayName("Supplier's Login ID")]
        [Remote("IsAlreadySigned", "Home", HttpMethod = "POST", ErrorMessage = "Supplier of this ID already exists in database.")]
        [MinLength(6, ErrorMessage = "Please enter ID of at least 6 valid characters"), MaxLength(16, ErrorMessage = "Kindly decrease length (below 16 valid characters)!")]
        [Required(ErrorMessage = "Enter Your Login User ID of Vendor Assistance (Minimum Length: 6)")]
        public string user_loginID { get; set; }

        [DisplayName("Supplier's Login Password")]
        [Required(ErrorMessage = "Enter Your Password for Login User ID of Vendor Assistance")]
        [MaxLength(12,ErrorMessage ="Please enter shorter password than this !")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,12}$", ErrorMessage ="Please enter password with at least 1 digit, 1 UpperCase letter and a special character of 8 length.")]
        [Remote("remote_Password_validate", "Home", HttpMethod = "POST", ErrorMessage = "Password already exists in database.")]
        public string user_password { get; set; }
        
    
    }
}