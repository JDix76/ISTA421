--AUTHOR: JAMES DIX
--DATE: 27 SEPT 2018
--SUBJECT:ASPMVCNETLAB04

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace LanguageFeature1.Models
{
    public class Product
    {
        public Product(bool stock = true)
        {
            InStock = stock;
        }
        public string Name { get; set; }
        public string Category { get; set; } = "Watersports";
        public decimal? Price { get; set; }
        public Product Related { get; set; }
        public bool InStock { get; } = true;

        public static Product[] GetProducts()
        {
            Product kayak = new Product
            {
                Name = "Kayak",
                Category = "Water Craft",
                Price = 275M
            };
            //Product lifejacket = new Product
            Product lifejacket = new Product(false)
            {
                Name = "Lifejacket",
                Price = 48.95M
            };
            kayak.Related = lifejacket;
            return new Product[]
            {
                kayak, lifejacket, null
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguageFeature1.Models;

namespace LanguageFeature1.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            {
                ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
                //Product[] productArray =
                    var products = new[]
                {
                  new Product {Name = "Kayak", Price = 275M },
                  new Product {Name = "Lifejacket", Price = 48.95M },
                  new Product { Name = "Soccer ball", Price = 19.50M },
                  new Product { Name = "Corner flag", Price = 34.95M }
                };
                //return View(products.Select(p => p.Name));
                
                 return View(products.Select(p => $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}" ));
/*
                decimal priceFilterTotal = productArray.Filter(p => 
                (p?.Price ?? 0) >= 20).TotalPrices();
                decimal nameFilterTotal = productArray.Filter(p => p?.Name?[0] == 'S').
                    TotalPrices();
                decimal cartTotal = cart.TotalPrices();
                decimal arrayTotal = productArray.TotalPrices();
                decimal priceTotal = productArray.FilterByPrice(20).TotalPrices();
                decimal nameFilter = productArray.FilterByName('S').TotalPrices();
                return View("Index", new string[] { $"Array Total: {priceTotal:C2}",
               // $"Array Total: {arrayTotal:C2}, priceTotal {priceTotal: C2}"});
                $"Name Total: {nameFilter:C2}" });


            return View("Index", new string[] 
                {$"Cart Total: {cartTotal:C2}", });

                /*
                ShoppingCart cart = new ShoppingCart
                {
                    Products = Product.GetProducts()
                }; decimal cartTotal = cart.TotalPrices(); return View("Index", new string[] { $"Total: {cartTotal:C2}" });*/
            }
            /*
            Dictionary<string, Product> products = new Dictionary<string, Product>
            {
               ["Kayak"] = new Product { Name = "Kayak", Price = 275M },
               ["Lifejacket"] = new Product { Name = "Lifejacket", Price = 48.95M }
            };
            return View("Index", products.Keys);*/
            /*
            List<string> results = new List<string>();
            { 
                foreach (Product p in Product.GetProducts())
                {
                    string name = p?.Name ?? "<No Name>"; 
                    decimal? price = p?.Price ?? 0;
                    string relatedName = p?.Related?.Name ?? "<None>";
                    string category = p?.Category ?? "<No Category>"; 
                    results.Add(string.Format($"Name:{name}, Price:{price}, Related: {relatedName}, Category: {category}"));
                }  
            }
            return View(results);*/
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
namespace LanguageFeature1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvcWithDefaultRoute();
            /*
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });*/
        }
    }
}

@model IEnumerable<string>
 @{
     Layout = null; 
     }
<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Language Features</title>
</head>
<body>
    <h1>Language Features</h1>
    <ul>
        @foreach (string s in Model)
        {
            <li>@s</li>}
    </ul>
</body>
</html>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace LanguageFeature1.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product> products)
        {
            decimal total = 0; foreach (Product prod in products)
            {
                total += prod?.Price ?? 0;
            }
            return total;
        }
        public static IEnumerable<Product>
        FilterByPrice(this IEnumerable<Product> productEnum, decimal minimumPrice)
        {
            foreach (Product prod in productEnum)
            {
                if ((prod?.Price ?? 0) >= minimumPrice)
                {
                    yield return prod;
                }
            }
        }
        public static IEnumerable<Product> FilterByName(this IEnumerable<Product> productEnum,
          char firstLetter)
        {
            foreach (Product prod in productEnum)
            {
                if ((prod?.Name?[0]) == firstLetter)
                {
                    yield return prod;
                }
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace LanguageFeature1.Models
{
    public class ShoppingCart : IEnumerable<Product>
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerator<Product> GetEnumerator()
        {
            return Products.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace LanguageFeature1.Models
{
    public class ShoppingCart : IEnumerable<Product>
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerator<Product> GetEnumerator()
        {
            return Products.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
