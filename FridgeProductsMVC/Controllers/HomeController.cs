using FridgeProductsМVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FridgeProductsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string baseUrl = "https://localhost:44340/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Fridges()
        {
            List<Fridge> fridges = new List<Fridge>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/fridges");

                if (res.IsSuccessStatusCode)
                {
                    var fridgeResponse = res.Content.ReadAsStringAsync().Result;
                    fridges = JsonConvert.DeserializeObject<List<Fridge>>(fridgeResponse);
                }
                return View(fridges);
            }
        }

        public async Task<IActionResult> ShowProducts(string id)
        {
            if(id != null)
            {
                List<FridgeProduct> products = new List<FridgeProduct>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage res = await client.GetAsync($"api/fridges/{id}/products");
                    ViewBag.Fridge = new Fridge { Id = new Guid(id) };
                    if (res.IsSuccessStatusCode)
                    {
                        var prodResponse = res.Content.ReadAsStringAsync().Result;
                        products = JsonConvert.DeserializeObject<List<FridgeProduct>>(prodResponse);
                    }
                    return View(products);
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> AddProducts()
        {
            List<Product> products = new List<Product>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("/api/products");

                if (res.IsSuccessStatusCode)
                {
                    var prodResponse = res.Content.ReadAsStringAsync().Result;
                    products = JsonConvert.DeserializeObject<List<Product>>(prodResponse);
                }
            }
            ViewBag.Products = new SelectList(products, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProducts(string id, FridgeProduct product)
        {
            if(product != null)
            {
                return View();
            }
            return NotFound();
            
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
