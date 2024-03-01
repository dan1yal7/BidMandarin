namespace BidMandarin.Methods
{
    public class DailyCleanupService : IHostedService, IDisposable
    {
        private readonly IMandarinCleanupService _cleanupService;
        private Timer _timer;

        public DailyCleanupService(IMandarinCleanupService cleanupService)
        {
            _cleanupService = cleanupService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Запускаем очистку ежедневно в 3 часа ночи
            var now = DateTime.Now;
            var nextRunTime = new DateTime(now.Year, now.Month, now.Day, 3, 0, 0);
            if (now > nextRunTime)
            {
                nextRunTime = nextRunTime.AddDays(1);
            }
            var delay = nextRunTime - now;
            _timer = new Timer(DoCleanup, null, delay, TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        private void DoCleanup(object state)
        {
            _cleanupService.CleanupAsync().Wait();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
