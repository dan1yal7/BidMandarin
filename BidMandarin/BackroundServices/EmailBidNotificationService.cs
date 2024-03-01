using BidMandarin.Methods;
using BidMandarin.Models;

namespace BidMandarin.BackroundServices
{
    public interface IBidNotificationService
    {
        void SendOutbidNotification(User user);
        void SendAuctionWinNotification(User user);
    }
    public class EmailBidNotificationService : IBidNotificationService
    { 

        private readonly IEmailSender _emailSender;

        public EmailBidNotificationService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void SendAuctionWinNotification( User user)
        {
            string subject = "Ваша ставка была перебита";
            string message = $"Уважаемый {user.UserName}, ваша ставка была перебита. Пожалуйста, участвуйте в аукционе снова!";
            _emailSender.SendEmail(user.Email, subject, message);
        }

        public void SendOutbidNotification(User user)
        {
            string subject = "Поздравляем с победой в аукционе";
            string message = $"Уважаемый {user.UserName}, поздравляем с победой в аукционе!";

            _emailSender.SendEmail(user.Email, subject, message);
        }
    }
}
