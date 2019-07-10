using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EthioNews.Models;
using Microsoft.AspNetCore.Mvc;

namespace EthioNews.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var news = new News()
            {
                Id = 1,
                Category = 2,
                DetailInformation = "bhbsjbj"
            };
            return View(news);
        }
    }
}