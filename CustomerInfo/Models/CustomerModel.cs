using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerInfo.Models
{
    public class CustomerModel
    {
        [Key]
        public int Cus_Id { get; set; }
        [Required(ErrorMessage ="First Name Required.")]
        [System.ComponentModel.DisplayName("First Name")]
        public string Cus_FirstName { get; set; }
        [System.ComponentModel.DisplayName("Last Name")]
        public string Cus_LastName { get; set; }
        [System.ComponentModel.DisplayName("Date of Birth")]
        public DateTime Cus_DOB { get; set; }

        [System.ComponentModel.DisplayName("Gender")]
        public Gender Gender { get; set; }

    }

    public enum Gender {
        Male,
        Female,
        Other

    }
}