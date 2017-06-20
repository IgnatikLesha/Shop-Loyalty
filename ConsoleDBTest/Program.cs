using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ORM;
using System.Web.Helpers;

namespace ConsoleDBTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new LoyaltyModel())
            {
                //Role user = new Role { Name = "User" };
                //Role admin = new Role { Name = "Admin" };
                //db.Roles.Add(user);
                //db.Roles.Add(admin);
                //db.SaveChanges();
                //User administrator = new User
                //{
                //    Name = "Admin",
                //    Email = "ignatiklesha@gmail.com",
                //    Roles = { user, admin },
                //    //Password = Crypto.HashPassword("qwerty")
                //    Password = "qwerty"
                //};
                //db.Users.Add(administrator);
                //db.SaveChanges();

                //Sale first = new Sale()
                //{
                //    Name = "Hard",
                //    Checked = false,
                //    ShopId = 2,
                //    BuyerId = 3,
                //    SaleDate = DateTime.Now,
                //    Id = 1,
                //    Description = "Very hard task"
                //};
                //db.Sales.Add(first);
                //db.SaveChanges();

                //Sale first = new Sale()
                //{
                //    Name = "Hard",
                //    Checked = false,
                //    ShopId = 2,
                //    BuyerId = 3,
                //    SaleDate = DateTime.Now,
                //    Id = 1,
                //    Description = "Very hard task"
                //};
                //db.Sales.Add(first);
                //db.SaveChanges();

                //User try1 = new User()
                //{
                //    Name = "qwertyzxc",
                //    Email = "qwertyzxc@gmail.com",
                //    Password = "qwerty",
                //    Sales = new List<Sale>()
                //};
                //db.Users.Add(try1);
                //db.SaveChanges();

                //User try2 = new User()
                //{
                //    Name = "bbbbbbb",
                //    Email = "bbbbbbb@gmail.com",
                //    Password = "qwerty",
                //    Sales = new List<Sale>(),
                //    Id = 0
                //};
                //db.Users.Add(try2);
                //db.SaveChanges();

                //User try4 = new User()
                //{
                //    Name = "aaaaaaa",
                //    Email = "aaaaaaa@gmail.com",
                //    Password = Crypto.HashPassword("qwerty"),
                //    Sales = new List<Sale>(),
                //    Id = 0
                //};
                //db.Users.Add(try4);
                //db.SaveChanges();

                foreach (var item in db.Roles)
                {

                    Console.WriteLine(item.Name);
                    Console.WriteLine("---------------------");

                }

                foreach (var item in db.Users)
                {       
                        Console.WriteLine(item.Id);
                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Email);
                        Console.WriteLine("------------");

                }

                foreach (var item in db.Sales)
                {

                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Description);
                    Console.WriteLine("------------");
                }
                Console.ReadLine();
            }
        }
    }
}
