using HomeWork_24_ASP_Net_core_MVC.Data;
using HomeWork_24_ASP_Net_core_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace HomeWork_24_ASP_Net_core_MVC.Controllers
{
    public class NotesController : Controller
    {
     

        private readonly ILogger<NotesController> _logger;
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context, ILogger<NotesController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var notes = _context.Notes.ToList(); // отримуємо всі замітки з БД
            return View(notes); // передаємо список у View
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
