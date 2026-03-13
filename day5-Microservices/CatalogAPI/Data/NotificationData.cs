using ECommerceAPI.Models;

namespace ECommerceAPI.Data
{
    public class NotificationData
    {
        public static List<Notification> notifications { get; set; } = new List<Notification>()
        {
            new Notification(){NotificationId = "N-123", Message = "Test Notification", Time = DateTime.ParseExact("21/05/2026 02:05:21","dd/MM/yyyy HH:mm:ss",null)},
            new Notification(){NotificationId = "N-124", Message = "Notification - 1", Time = DateTime.Parse("09/01/2026 02:17:58")},
            new Notification(){NotificationId = "N-125", Message = "Notification - 2", Time = DateTime.Parse("12/03/2026 12:25:21")},
        };
    }
}
