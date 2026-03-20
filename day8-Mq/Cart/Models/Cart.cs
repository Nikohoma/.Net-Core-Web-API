using NewRabbitMq.Models;

namespace Cart.Models
{
    public class CartStructure
    {
        public List<Product> products { get; set; }

        public decimal totalPrice { get; set; }
    }
}
