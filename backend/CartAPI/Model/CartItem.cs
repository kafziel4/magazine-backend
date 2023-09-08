namespace CartAPI.Model
{
    public class CartItem
    {
        public int ProductId { get; private set; }
        public string Name { get; private set; }
        public string Size { get; private set; }
        public decimal Price { get; private set; }
        public string Image { get; private set; }
        public int Quantity { get; private set; }

        public CartItem(int productId, string name, string size, decimal price, string image, int quantity)
        {
            ProductId = productId;
            Name = name;
            Size = size;
            Price = price;
            Image = image;
            Quantity = quantity;
        }
    }
}
