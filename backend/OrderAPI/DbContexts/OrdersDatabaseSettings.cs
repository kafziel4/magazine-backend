namespace OrderAPI.DbContexts
{
    public class OrdersDatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string OrdersCollectionName { get; set; } = string.Empty;
    }
}
