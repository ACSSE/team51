﻿using System.Web.Mvc;

namespace Bursify.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}