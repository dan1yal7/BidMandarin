namespace BidMandarin.Models
{
    public class User
    { 
       public int UserId { get; set; } 
        public string UserName { get; set; }
        public string Email { get; set; } 
        public string HashedPassword { get; set; }  
        public bool isAdming { get; set; } 

    }
}
