namespace BidMandarin.Models
{
    public class Bid
    { 
       public int BidId { get; set; }
        public int MandarinId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; } 
        public DateTime BidTime { get; set; } 


    }
}
