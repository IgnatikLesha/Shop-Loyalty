using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class LoyaltyModel : DbContext
    {

        static LoyaltyModel()
        {
            Database.SetInitializer(new DBInitializer());
        }

        public LoyaltyModel()
            : base("name=LoyaltyModel")
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Bonus> Bonus { get; set; }

        public virtual DbSet<CreditCard> CreditCards { get; set; }
    }
}
