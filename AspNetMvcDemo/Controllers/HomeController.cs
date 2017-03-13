using AspNetMvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ///Hardcoding some demo values for now
            List<Product> products = new List<Product>
            {
                new Product()
                {
                    ID = 1,
                    Category = "Vegetables",
                    Name = "Potatoes",
                    Price = 1.99M,
                    Description = "Price per kg",
                    Modified = DateTime.Now
                },
                new Product()
                {
                    ID = 2,
                    Category = "Vegetables",
                    Name = "Cucumbers",
                    Price = 2.99M,
                    Description = "Price per kg",
                    Modified = DateTime.Now
                },
                new Product()
                {
                    ID = 3,
                    Category = "Vegetables",
                    Name = "Carrots",
                    Price = 1.99M,
                    Description = "Price per kg",
                    Modified = DateTime.Now
                },
                new Product()
                {
                    ID = 4,
                    Category = "Fruit",
                    Name = "Apples",
                    Price = 2.50M,
                    Description = "Price per kg",
                    Modified = DateTime.Now
                },
                new Product()
                {
                    ID = 5,
                    Category = "Fruit",
                    Name = "Bananas",
                    Price = 1.99M,
                    Description = "Price per kg",
                    Modified = DateTime.Now
                }
            };
            return View(products);
        }

        ///POST action on Index takes form data, parses it to string and
        ///stores it in TempData collection and calls GET version of Index.
        ///Redirect is to avoid duplicating table population code;
        ///all these crazy workarounds are just to keep withing Task 1 parameters
        [HttpPost]
        public ActionResult Index(FormCollection input)
        {
            string output = "";
            foreach (var key in input.AllKeys)
            {
                output += input[key] + " ";
            }
            TempData["message"] = output;
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Placeholder 'About' page";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Placeholder 'Contact' page";

            return View();
        }
    }
}