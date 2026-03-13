using EcommerceAPI.Models;
using EcommerceAPI.Data;

namespace EcommerceAPI.Services
{
    public class PaymentService
    {
        public List<Payment> GetAllPayments()
        {
            var payments = PaymentData.payments;
            return payments;
        }
    }
}
