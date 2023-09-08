namespace OrderAPI.Model
{
    public class Cart
    {
        public string CustomerId { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
