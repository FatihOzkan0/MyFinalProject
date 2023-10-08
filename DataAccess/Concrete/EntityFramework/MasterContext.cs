using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje classlarını bağladığımız yer.
    public class MasterContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  //Bu method projem hangi veri tabanı ile ilişkili onu belirttiğim yer.
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;DataBase=master;Trusted_Connection=true");  //Veri tabanı yolumuz.
        }

        public DbSet<Product> Products { get; set; }         //Hangi veri tabanı nesnem hangi veri tabanına bağlanıcak onu belirtiyoruz.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


        

    }
}
