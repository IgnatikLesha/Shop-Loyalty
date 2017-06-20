using System;
using System.Data.Entity;

namespace ORM
{
    public class DBInitializer : CreateDatabaseIfNotExists<LoyaltyModel>
    {
        protected override void Seed(LoyaltyModel context)
        {
            Role user = new Role {Name = "User"};
            Role admin = new Role {Name = "Admin"};
            context.Roles.Add(user);
            context.Roles.Add(admin);

            User administrator = new User {Name = "Admin", Email = "ignatiklesha@gmail.com",
                Roles = {user, admin}, Password = "qwerty" /*Password = Crypto.HashPassword("qwerty")*/ };
            context.Users.Add(administrator);

            CreditCard shop = new CreditCard() {UserId = administrator.Id, Amount = 1000000000, Number = 1234567890};
            context.CreditCards.Add(shop);

            Sale firstSl = new Sale()
            {
                Name = "Product",
                ShopId = 2,
                BuyerId = 3,
                SaleDate = DateTime.Now,
                Id = 1,
                Description = "Description of the product",
                Price = 100,
                Discount = false
            };

            context.Sales.Add(firstSl);


            Product firstPr = new Product()
            {
                Id = 1,
                ShopId = 1,
                Name = "Product",
                Price = 100,
                Description = "Description of the product",
            };

            context.Products.Add(firstPr);

            context.SaveChanges();
        }
    }
}
