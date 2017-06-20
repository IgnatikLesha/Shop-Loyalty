using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Entities;
using BLL.Interfaces;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using BLL.Mappers;
using DAL.Concrete;
using PagedList;
using TasksManager.Models;

namespace TasksManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISaleService saleService;
        private readonly IUserService userService;
        private readonly IProductService productService;
        private readonly ICreditCardService creditCardService;
        private readonly IBonusService bonusService;


        public HomeController(ISaleService saleService, IUserService userService,
            ICreditCardService cardService, IProductService prodService, IBonusService bonService)
        {
            this.saleService = saleService;
            this.userService = userService;
            this.productService = prodService;
            this.creditCardService = cardService;
            this.bonusService = bonService;
        }

        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var sales = saleService.GetAllEntities().Select(t => t.GetSaleViewModel());
            return View(sales.ToPagedList(pageNumber, pageSize));
            //return View(saleService.GetAllEntities().Select(t=>t.GetSaleViewModel()));
        }

        public ActionResult ShowAllSales()
        {
            return View(saleService.GetAllEntities().Select(t => t.GetSaleViewModel()));
        }

        public ActionResult NotConfirmedSales()
        {

            return View(saleService.GetAllEntities().Where(t => t.IsConfirmed == false).Select(t => t.GetSaleViewModel()));
        }

        [HttpGet]
        public ActionResult CreateCreditCard()
        {
            return PartialView("CreateCreditCard");
        }




        [HttpPost]
        public ActionResult CreateCreditCard(CreditCardViewModel card)
        {
            var thisUser = userService.GetByPredicate(u=>u.Email == User.Identity.Name);


            creditCardService.Create(new CreditCardEntity()
            {
                Number = card.Number,
                Amount = card.Amount,
                UserId = thisUser.Id
            });
            return PartialView("Index");
        }


        [HttpPost]
        public ActionResult CreateProduct(ProductViewModel prod)
        {
            var thisUser = userService.GetByPredicate(u => u.Email == User.Identity.Name);

            productService.Create(new ProductEntity
            {
                Name = prod.Name,
                Description = prod.Description,
                ShopId = thisUser.Id,
                Price = prod.Price
            });
            return PartialView("Index");
        }


        public ActionResult ShowProducts()
        {
            var bonus = bonusService.GetByPredicate(b => b.UserName == User.Identity.Name);
            ViewBag.Discount = bonus.IsActive;
            var products = productService.GetAllEntities().Select(p => p.GetProductViewModel());
            return View(products);
        }


        public ActionResult CreateDiscountSale(string name, string description, string user, int shopId, double price, bool discount)
        {
            price = price*0.8;
            return CreateSale(name, description, user, shopId, price, discount);
        }

        public ActionResult CreateSale(string name, string description, string user, int shopId, double price, bool discount)
        {
            var thisUser = userService.GetByPredicate(u => u.Email == User.Identity.Name);
            saleService.Create(new SaleEntity()
            {
                BuyerId = thisUser.Id,
                ShopId = shopId,
                Name = name,
                Description = description,
                Price = price,
                IsConfirmed = false,
                Discount = discount
            });

            return RedirectToAction("ShowProducts");
        }



        public ActionResult ShowMySales()
        {
            var user = userService.GetByPredicate(u => u.Email == User.Identity.Name);
            var sales = saleService.GetAllByPredicate(t => t.BuyerId == user.Id).ToList();
            ViewBag.User = user;
            ViewBag.Sales = sales;
            return PartialView("ShowMySales");
        }



        public ActionResult About()
        {
            ViewBag.Message = "Sales Manager. Created by Lesha Ignatik. ";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "My contacts:.";

            return View();
        }


        public ActionResult SetConfirmed(int saleId, double price, int shopId, int buyerId, bool discount)
        {
            var bonus = bonusService.GetByPredicate(b => b.UserName == User.Identity.Name);
            var sale = saleService.GetById(saleId);
            saleService.ConfirmSale(sale);
            bonusService.UpdateBonus(bonus, price);
            if (discount)
            {
                bonusService.UseBonus(bonus);
            }

            var userCard = creditCardService.GetByPredicate(c => c.UserId == buyerId);
            var shopCard = creditCardService.GetByPredicate(c => c.UserId == shopId);

            creditCardService.AccrueAmount(shopCard, price);
            creditCardService.Withdraw(userCard, price);
            return RedirectToAction("NotConfirmedSales");
        }
    }
}