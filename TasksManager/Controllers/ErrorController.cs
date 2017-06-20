using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TasksManager.Controllers
{
    public class ErrorController : Controller
    {

        public ViewResult Error404()
        {
            Response.StatusCode = 404;
            return View("Error404");
        }
    }
}