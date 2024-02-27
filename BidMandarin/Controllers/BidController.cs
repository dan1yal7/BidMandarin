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

        public IActionResult PlaceBid(  int bidId, int mandarinId,int userId, decimal amount, DateTime bidTime)
        {
            var bid = new Bid
            {   
                BidId = bidId,
                MandarinId = mandarinId,
                UserId = userId,
                Amount = amount,  
                BidTime = bidTime


            };

            _context.Bids.Add(bid);
            _context.SaveChanges();

            // Перенаправление пользователя на другую страницу или представление
            return RedirectToAction("Index", "Mandarin");

        }
        public IActionResult ViewBids()
        {
            var bids = _context.Bids.Where(b => b.MandarinId == mandarinId).ToList();
            return View(bids);
        }
    }
}
