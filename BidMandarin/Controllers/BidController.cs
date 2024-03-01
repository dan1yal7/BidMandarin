using BidMandarin.BackroundServices;
using BidMandarin.Methods;
using BidMandarin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace BidMandarin.Controllers
{

    [Authorize]
    public class BidController : Controller
    { 
       private readonly ApplicationDbContext _context;
        private readonly EmailBidNotificationService _emailNotificationService;
        private readonly int mandarinId;

        public BidController(ApplicationDbContext context, EmailBidNotificationService emailBidNotificationService)
        {
            _context = context; 
            _emailNotificationService = emailBidNotificationService;
            
        }

        [HttpPost]
        public IActionResult PlaceBid(Bid bid)
        {

            if (ModelState.IsValid)
            {

                _context.Bids.Add(bid);
                _context.SaveChanges();


                var existingbids = _context.Bids.Where(b => b.MandarinId == bid.MandarinId).ToList();
                if (existingbids.Any())
                {
                    var maxBidAmount = existingbids.Max(b => b.Amount);

                    //if (bid.Amount > maxBidAmount)
                    //{
                    //    _emailNotificationService.SendAuctionWinNotification(, "Ваша ставка была перебита!");
                    //}

                }
            
                
                // Перенаправление пользователя на страницу с мандаринками
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
