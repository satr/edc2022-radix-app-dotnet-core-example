using System;
using System.Diagnostics;
using System.Linq;
using app.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using app.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.Controllers
{
    public class HomeController : Controller
    {
        private readonly CatalogContext _dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(CatalogContext dbContext, ILogger<HomeController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Items()
        {
            var items = _dbContext.CatalogItems
                .Where(b => b.Enabled)
                .OrderBy(b => b.Name)
                .Select(b => new SelectListItem {
                    Value = b.Id.ToString(), Text = b.Name })
                .ToList();
            return View(items);
        }

        public IActionResult Create()
        {
            var item = new CatalogItem() { Name = $"Item {DateTime.Now.ToLongTimeString()}" };
            _dbContext.Add(item);
            _dbContext.SaveChangesAsync();
            return View(item);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
