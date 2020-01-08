using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace supplier_dashboard_1._0.Models
{
    public class Profile_VIewModel
    {
        public int id { get; set; }
        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        
        [DisplayName("First Name")]
        [Required(ErrorMessage = "Enter Your First Name"), MinLength(3, ErrorMessage = "At Least 3 characters !"), MaxLength(50, ErrorMessage = "Max 50 characters !")]
        public string firstname { get; set; }

        
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Enter Your Last Name"), MinLength(3, ErrorMessage = "At Least 3 characters !"), MaxLength(50, ErrorMessage = "Max 50 characters !")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "Enter Company Name"), MinLength(3, ErrorMessage = "At Least 3 characters !"), MaxLength(30, ErrorMessage = "Max 30 characters !")]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [DisplayFormat()]
        [Required(ErrorMessage = "Enter Your STN Registration of Your Company")]
        [RegularExpression(@"^\d{10}|\d{3}-\d{3}-\d{3}-\d{1}$", ErrorMessage = "Invalid STN Number(10 digit STN Number )")]
        [DisplayName("Sales Tax Registration Number")]
        public string Stn_reg_num { get; set; }

        [Required(ErrorMessage = "Enter Office Address !"), MinLength(20, ErrorMessage = "Enter proper Office Address!"), MaxLength(500, ErrorMessage = "Max 500 characters !")]
        [DisplayName("Office Address")]
        public string OfficeAddress { get; set; }

        [Required(ErrorMessage = "Enter Your City"), MinLength(3), MaxLength(30)]
        [DisplayName("City")]
        public string City { get; set; }

        
        [Required(ErrorMessage = "Please select Country")]
        [DisplayName("Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Enter Personal Contact Number"), MinLength(8), MaxLength(500)]
        [RegularExpression(@"^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$", ErrorMessage = " Not a valid phone number")]
        [DisplayName("Personal Contact")]
        public string personalphone { get; set; }

        [RegularExpression(@"^https(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$", ErrorMessage = "Please enter a valid website")]
        [DisplayName("Company Website")]
        public string WebSite { get; set; }

        [Required]
        [DisplayName("Fax Number")]
        public string Fax { get; set; }

        
        [Required(ErrorMessage = "Enter Office Number"), MinLength(8), MaxLength(500)]
        [RegularExpression(@"^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$", ErrorMessage = " Not a valid phone number")]
        [DisplayName("Office Number")]
        public string OfficeNumber { get; set; }

        [DisplayName("Postal Code")]
        public string Postal { get; set; }
             
        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Enter Company's/Your Personal email Address")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email Address not valid !")]
        public string email { get; set; }

    }
}