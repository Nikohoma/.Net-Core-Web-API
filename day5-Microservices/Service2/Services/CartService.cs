using Service2.Data;
using Service2.Models;

namespace Service2.Services
{
    public class CartService
    {
        public List<Cart> GetAllCarts()
        {
            var carts = CartData.carts;
            return carts;
        }

    }
}
