using Microsoft.EntityFrameworkCore;

namespace BidMandarin.Models
{
    public class ApplicationDbContext:DbContext
    { 
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } 

        public DbSet<User> Users { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Mandarin> Mandarins { get; set;}
        public DbSet<Notification> Notifications { get; set; }



    }
}
