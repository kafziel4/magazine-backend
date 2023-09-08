using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OrderAPI.Model;

namespace OrderAPI.DbContexts
{
    public class AppDbContext : IAppDbContext
    {
        public IMongoCollection<Order> Orders { get; }

        public AppDbContext(IOptions<OrdersDatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            Orders = database.GetCollection<Order>(settings.Value.OrdersCollectionName);
        }
    }
}
