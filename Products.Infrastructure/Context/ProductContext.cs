using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using products_api.Products.API.Interfaces;

namespace products_api.Products.Infrastructure.Context
{
    public class ProductContext : IProductContext
    {
        private readonly IMongoDatabase _database = null;
        private readonly string _connectionString = "<insert connection string here>";
        private readonly string _dbName = "ProductDb";
        private readonly string _localDbName = "ProductsDb";
        private readonly MongoClient _client;
        private readonly string _localConnectionString = "mongodb://localhost:27017";
        public ProductContext(IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Local client
                _client = new MongoClient(_localConnectionString);
                _database = _client.GetDatabase(_localDbName);
            }
            else
            {
                // Web client
                _client = new MongoClient(_connectionString);
                _database = _client.GetDatabase(_dbName);
            }

        }

        public IMongoCollection<DbKit> Kits 
        { 
            get { return _database.GetCollection<DbKit>("Kits"); }
        }
        public IMongoCollection<DbComponent> Components 
        { 
            get { return _database.GetCollection<DbComponent>("Components"); }
        }
    }
}