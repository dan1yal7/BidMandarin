using BidMandarin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BidMandarin.Controllers
{
    public class MandarinController : Controller
    {

        private readonly ApplicationDbContext _context; 

        public MandarinController (ApplicationDbContext context)
        {
            _context = context; 
        }

        // Отображение списка всех мандаринок 
        public IActionResult Index()
        {
            // Получаем список всех мандаринок из базы данных
            var mandarins = _context.Mandarins.ToList(); 
            return View(mandarins); // Передаем список мандаринок в представление для отображения
        }


        // Действие для отображения деталей конкретной мандаринки по её Id
        public IActionResult Details (int id)
        {
            var mandarin = _context.Mandarins.FirstOrDefault(m => m.MandarinId == id); 
            if(mandarin == null)
            {
                return NotFound();
            } 
            return View(mandarin);
        }

        // Действие для создания новой мандаринки
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Create(Mandarin mandarin)
        {
            if(ModelState.IsValid)
            {
                _context.Mandarins.Add(mandarin);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(mandarin);
        }

    }
}
