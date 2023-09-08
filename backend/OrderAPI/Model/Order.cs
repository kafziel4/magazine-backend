namespace OrderAPI.Model
{
    public class Order
    {
        private List<OrderItem> _items = new();

        public Guid Id { get; private set; }
        public string CustomerId { get; private set; }
        public DateTime Date { get; private set; }
        public decimal TotalPrice { get; private set; }
        public ICollection<OrderItem> Items
        {
            get => _items;
            private set => _items = value.ToList();
        }

        public Order(string customerId, decimal totalPrice)
        {
            CustomerId = customerId;
            Date = DateTime.UtcNow;
            TotalPrice = totalPrice;
        }

        public void AddItems(ICollection<OrderItem> items)
        {
            Items = items;
        }
    }
}
