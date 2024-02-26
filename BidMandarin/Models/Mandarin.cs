using System.ComponentModel.DataAnnotations;

namespace BidMandarin.Models
{
    public class Mandarin
    {

        [Key]
        public int MandarinId { get; set; }  
        public string MandarinName { get; set; }
        public string ImageURL { get; set; } 
        public decimal StartingPrice { get; set; }
        public DateTime EndTime { get; set; }
        public bool isSold { get; set; }
        public int BuyerId { get; set; } 



    }
}
