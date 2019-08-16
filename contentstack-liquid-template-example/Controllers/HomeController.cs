using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Scriban;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using contentstack_liquid_template_example.Models;
using Contentstack.Core;
using Contentstack.Core.Models;
using System.IO;

namespace contentstack_liquid_template_example.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContentstackClient _stack;
        public HomeController(ContentstackClient stack) => _stack = stack;

        public async Task<IActionResult> Index()
        {
            string result = string.Empty;
            var query = _stack.ContentType("product").Query().IncludeReference("related_products");
            ContentstackCollection<ProductModel> products = await query.Find<ProductModel>();
            var fileString = System.IO.File.ReadAllText(Path.GetFullPath("Views/Home/home.liquid"));
            var template = Template.Parse(fileString);
            result = template.Render(new { Products = products.Items });
            return View("Index", result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
