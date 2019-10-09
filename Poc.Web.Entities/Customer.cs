using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Poc.Web.Entities
{
        [Table("Customer")]
        public class Customer
        {
            [Key]
            public int CustId { get; set; }

            [Display(Name = "Customer Name")]
            public string CustName { get; set; }

            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email")]
            public string CustEmail { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string CustPassword { get; set; }

            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Phone Number")]
            public string CustPhoneNo { get; set; }        
           public string Role { get; set; }
    }
 }
