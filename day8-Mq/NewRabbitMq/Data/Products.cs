using NewRabbitMq.Models;

namespace NewRabbitMq.Data
{
    public class Products
    {
        public static List<Product> products { get; set; } = new List<Product>()
        {
            new Product(){Id = 101, Name = "Chair", Price = 499},
            new Product(){Id = 102, Name = "Table", Price = 899},
            new Product(){Id = 103, Name = "Basket", Price = 299},
            new Product(){Id = 104, Name = "Curtains", Price = 1199}

        };
    }
}
