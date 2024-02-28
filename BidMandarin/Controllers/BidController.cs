using BidMandarin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BidMandarin.Controllers
{
    public class BidController : Controller
    { 
       private readonly ApplicationDbContext _context;
        private readonly int mandarinId;

        public BidController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PlaceBid(Bid bid)
        {

            if (ModelState.IsValid)
            {

                _context.Bids.Add(bid);
                _context.SaveChanges();

                // Перенаправление пользователя на другую страницу или представление
                return RedirectToAction("Index", "Mandarin");
            }
            return View(bid);

        }
        public IActionResult ViewBids(int mandarinId)
        {
            var bids = _context.Bids.Where(b => b.MandarinId == mandarinId).ToList();
            return View(bids);
        }
    }
}
