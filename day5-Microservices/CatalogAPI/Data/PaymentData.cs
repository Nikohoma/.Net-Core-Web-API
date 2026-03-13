using EcommerceAPI.Models;

namespace EcommerceAPI.Data
{
    public class PaymentData
    {
        public static List<Payment> payments = new List<Payment>()
        {
            new Payment(){PaymentId = "P-312",Amount = 300},
            new Payment(){PaymentId = "P-572",Amount = 850},
            new Payment(){PaymentId = "P-596",Amount = 659}
        };
    }
}
