using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerInfo.Models
{
    public class ContatctInfoModel
    {
        [Key]
        public int Id { get; set; }

        [Phone]
        public int Number { get; set; }
        public int Cus_Id { get; set; }
        public CustomerModel CustomerModel { get; set; }
    }
}