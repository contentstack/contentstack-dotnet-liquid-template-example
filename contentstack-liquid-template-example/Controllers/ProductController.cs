using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Contentstack.Core;
using Scriban;
using Microsoft.AspNetCore.Mvc;
using contentstack_liquid_template_example.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace contentstack_liquid_template_example.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly ContentstackClient _stack;
        public ProductController(ContentstackClient stack) => _stack = stack;

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(string id)
        {
            string result = string.Empty;
            var entry = _stack.ContentType("product").Entry(id).IncludeReference("related_products");
            ProductModel product = await entry.Fetch<ProductModel>();
            var fileString = System.IO.File.ReadAllText(Path.GetFullPath("Views/Product/product.liquid"));
            var template = Template.Parse(fileString);
            result = template.Render(new { Product = product });
            return View("Index", result);
        }
    }
}


