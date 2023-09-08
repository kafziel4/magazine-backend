using MongoDB.Driver;
using OrderAPI.Model;

namespace OrderAPI.DbContexts
{
    public interface IAppDbContext
    {
        IMongoCollection<Order> Orders { get; }
    }
}
