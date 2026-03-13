namespace EcommerceAPI.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public List<string> products { get; set; }
        public decimal Price { get; set; }
    }
}
