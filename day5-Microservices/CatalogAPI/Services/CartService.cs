using EcommerceAPI.Data;
using EcommerceAPI.Models;

namespace EcommerceAPI.Services
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
