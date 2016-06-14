﻿using CsharpExample.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace CsharpExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navigate to URL to show an example";
        }

        public ViewResult AutoProperty()
        {
            Product myProduct = new Product();

            myProduct.Name = "Kayak";

            string productName = myProduct.Name;

            return View("Result", (object)String.Format("Product name: {0}", productName));
        }

        public ViewResult UseExtension()
        {
            // Init Instance
            ShoppingCart cart = new ShoppingCart
            {
                Products = new System.Collections.Generic.List<Product>
                {
                    new Product { Name="Kayak", Price = 275M },
                    new Product { Name="Lifejacket", Price = 48.95M },
                    new Product { Name="Soccer ball", Price = 19.5M },
                    new Product { Name="Corner flag", Price = 34.95M },
                }
            };

            // Calculate Sum
            decimal cartTotal = cart.TotalPrices();

            return View("Result", (object)string.Format("Total : {0:c}", cartTotal));
        }

        public ViewResult UseExtensionEnumerable()
        {
            // Init Instance
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product { Name="Kayak", Price = 275M },
                    new Product { Name="Lifejacket", Price = 48.95M },
                    new Product { Name="Soccer ball", Price = 19.5M },
                    new Product { Name="Corner flag", Price = 34.95M },
                }
            };

            Product[] productArray = {
                    new Product { Name="Kayak", Price = 275M },
                    new Product { Name="Lifejacket", Price = 48.95M },
                    new Product { Name="Soccer ball", Price = 19.5M },
                    new Product { Name="Corner flag", Price = 34.95M },
                };

            // Calculate Sum
            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = productArray.TotalPrices();

            return View("Result", (object)string.Format("Total : {0:c}, Array Total : {1:c}", cartTotal, arrayTotal));
        }

        public ViewResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product { Name="Kayak", Category = "Watersports", Price = 275M },
                    new Product { Name="Lifejacket", Category = "Watersports", Price = 48.95M },
                    new Product { Name="Soccer ball", Category = "Soccer", Price = 19.5M },
                    new Product { Name="Corner flag", Category = "Soccer", Price = 34.95M },
                }
            };

            // Not Lamda
            //Func<Product, bool> categoryFilter = delegate (Product prod)
            //{
            //    return prod.Category == "Soccer";
            //};

            // Lamda
            Func<Product, bool> categoryFilter = prod => prod.Category == "Soccer";

            decimal total = 0;
            //foreach (Product prod in products.Filter(categoryFilter))
            //{
            //    total += prod.Price;
            //}

            // more compress
            foreach (Product prod in products.Filter(prod => prod.Category == "Soccer" || prod.Price > 20))
            {
                total += prod.Price;
            }

            /* 
             * additional info for Lamda
             * 
             * 1. Replace to method
             * :: prod => EvaluateProduct(prod)
             * 
             * 2. More Parameters
             * :: (prod, count) => prod.Price > 20 && count > 0
             * 
             * 3. Complete Lamda
             * :: (prod, count) => {
             *      bla..bla...
             *      return result;
             * }
             */

            return View("Result", (object)string.Format("Total : {0:c}", total));
        }

        // Anonymous Type
        public ViewResult CreateAnonArray()
        {
            var oddsAndEnds = new[]
            {
                new { Name = "MVC", Category = "Pattern"},
                new { Name = "Hat", Category = "Clothing"},
                new { Name = "Apple", Category = "Fruit"},
            };

            StringBuilder result = new StringBuilder();
            foreach (var item in oddsAndEnds)
            {
                result.Append(item.Name).Append(" ");
            }

            return View("Result", (object)result.ToString());
        }
    }
}