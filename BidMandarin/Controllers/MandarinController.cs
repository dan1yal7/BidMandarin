using BidMandarin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace BidMandarin.Controllers
{
    public class MandarinController : Controller
    {

        private readonly ApplicationDbContext _context;

        public MandarinController(ApplicationDbContext context)
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


        public IActionResult Edit (int id)
        {
            var mandarin = _context.Mandarins.FirstOrDefault(m=> m.MandarinId == id);
            if(mandarin == null)
            {
                return NotFound();
            } 
            return View(mandarin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Edit( int id,  Mandarin mandarin)
        {
            if ( id  != mandarin.MandarinId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(mandarin);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(mandarin);
        } 
         
        // Действие для отображения деталей конкретной мандаринки по её Id
        public IActionResult Details(int id)
        {
            var mandarin = _context.Mandarins.FirstOrDefault(m => m.MandarinId == id);
            if (mandarin == null)
            {
                return NotFound();
            }
            return View(mandarin);
        } 

     

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Mandarin mandarin)
        {
            if (ModelState.IsValid)
            {
                _context.Mandarins.Add(mandarin);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(mandarin);
        }

        public IActionResult Delete(int id)
        {
            var mandarin = _context.Mandarins.FirstOrDefault(m=>m.MandarinId == id);    
            if (mandarin == null)
            {
                return NotFound();

            }
            return View(mandarin);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(int id)
        {
            var mandarin = _context.Mandarins.FirstOrDefault(m=> m.MandarinId == id);   
            _context.Mandarins.Remove(mandarin);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

      
    }
}