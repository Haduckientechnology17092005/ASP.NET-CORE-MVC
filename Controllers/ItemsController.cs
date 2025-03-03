using Microsoft.AspNetCore.Mvc;
using MyApp.Data;

namespace WebApplicationMVC.Controllers
{
    public class ItemsController : Controller
    {
        private readonly MyAppContext _context;
        public ItemsController(MyAppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.Items.ToList();
            return View(items);
        }
    }
}
