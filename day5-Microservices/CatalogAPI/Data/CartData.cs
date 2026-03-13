using EcommerceAPI.Models;

namespace EcommerceAPI.Data
{
    public class CartData
    {
        public static List<Cart> carts { get; set; } = new List<Cart>()
        {
            new Cart(){CartId = 101, Price = 4500, products = new List<string>(){"Chair", "Table" } },
            new Cart(){CartId = 103, Price = 500, products = new List<string>(){"Glue", "Keyboard" } },
            new Cart(){CartId = 106, Price = 4582, products = new List<string>(){"Mouse", "Hammer" } },
        };
    }
}
