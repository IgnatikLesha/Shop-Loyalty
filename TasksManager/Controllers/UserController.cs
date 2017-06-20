using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using ORM;

namespace TasksManager.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            ViewBag.Users = service.GetAllEntities();
            ViewBag.User = service.GetByPredicate(u => u.Name == User.Identity.Name);
            return PartialView("UserView");
        }
    }
}