using ECommerceAPI.Data;
using ECommerceAPI.Models;

namespace ECommerceAPI.Services
{
    public class NotificationService
    {

        public List<Notification> GetAllNotifications()
        {
            return NotificationData.notifications;
        }
    }
}
