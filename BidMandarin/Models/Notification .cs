using System.Globalization;

namespace BidMandarin.Models
{
    public class Notification
    { 
       public int NotificationId { get; set; } 
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTime NotificationTime { get; set; } 


    }
}
