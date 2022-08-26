using System;
using System.Diagnostics;
using System.Linq;
using app.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using app.Models;

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
                .OrderBy(b => b.Name)
                .ToList();
            return View(items);
        }

        public IActionResult Create()
        {
            var timeNow = DateTime.Now.ToLongTimeString();
            var item = new CatalogItem()
            {
                Name = $"Item {timeNow}",
                Description = $"Description: {timeNow}"
            };
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
