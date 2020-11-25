using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class HomeController : Controller
    {
        //View Index
        public IActionResult Index()
        {
            return View();
        }

        //View About
        public IActionResult About()
        {
            ViewData["Message"] = "Sales control system Asp. Net Core MVC of the C # course at Udemy";
            ViewData["Aluno"] = "Cristiano Campos de Souza";

            return View();
        }

        //View Contact
        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact page.";

            return View();
        }

        //View Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        ////View Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
