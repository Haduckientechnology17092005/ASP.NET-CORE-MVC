using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Data;
using WebApplicationMVC.Models;


namespace WebApplicationMVC.Controllers
{
    public class ItemsController : Controller
    {
        private readonly MyAppContext _context;
        public ItemsController(MyAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _context.Items.ToListAsync();
            return View(items);
        }
        public IActionResult Overview()
        {
            return View();
        }
        public async Task<IActionResult> Submit(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name, Price")] Item item){
            if(ModelState.IsValid){
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }
    }
}
