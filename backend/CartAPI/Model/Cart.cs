namespace CartAPI.Model
{
    public class Cart
    {
        private readonly List<CartItem> _items = new();

        public string CustomerId { get; private set; }
        public decimal TotalPrice { get; private set; }
        public ICollection<CartItem> Items => _items;

        public Cart(string customerId)
        {
            CustomerId = customerId;
        }

        public void AddItems(IEnumerable<CartItem> items)
        {
            _items.AddRange(items);
            CalculateTotalPrice();

        }

        private void CalculateTotalPrice() =>
            TotalPrice = _items.Sum(i => i.Price * i.Quantity);
    }
}
