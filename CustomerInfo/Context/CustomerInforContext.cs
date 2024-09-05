using CustomerInfo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomerInfo.Context
{
    public class CustomerInforContext : DbContext
    {
        public DbSet<CustomerModel> customerModels { get; set; }
        public DbSet<ContatctInfoModel> contatctInfoModels { get; set; }
        public DbSet<User> Users { get; set; }
    }
}