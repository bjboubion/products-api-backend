using MongoDB.Driver;
using products_api.Products.Infrastructure.Context;

namespace products_api.Products.API.Interfaces
{
    public interface IProductContext
    {
        IMongoCollection<DbKit> Kits { get; }
        IMongoCollection<DbComponent> Components { get; }

    }
}