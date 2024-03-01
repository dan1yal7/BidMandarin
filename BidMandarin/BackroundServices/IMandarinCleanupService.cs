using BidMandarin.Models;

namespace BidMandarin.Methods
{
    public interface IMandarinCleanupService
    {
        Task CleanupAsync();
    }

    public class MandarinCleanupService : IMandarinCleanupService
    {
        private readonly ApplicationDbContext _dbContext;

        public MandarinCleanupService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CleanupAsync()
        {
          
            var expiredMandarins = _dbContext.Mandarins.Where(m => m.EndTime < DateTime.Today);
            _dbContext.Mandarins.RemoveRange(expiredMandarins);
            await _dbContext.SaveChangesAsync();
        }
    }
}
