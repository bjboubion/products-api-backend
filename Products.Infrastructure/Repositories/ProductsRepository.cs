using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using products_api.Products.API.Interfaces;
using products_api.Products.API.ViewModel;
using products_api.Products.Domain.Interfaces;
using products_api.Products.Infrastructure.Context;

namespace products_api.Products.Infrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IProductContext _context;
        private readonly IMapper _mapper;

        public ProductsRepository(IProductContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));;
        }

        public async Task<List<DbKit>> GetAllKits()
        {
            var databaseModels = await _context.Kits.Find(kit => true).ToListAsync();

            return databaseModels;
        }

        public async Task<List<DbComponent>> GetAllComponents()
        {
            var databaseModels = await _context.Components.Find(component => true).ToListAsync();

            return databaseModels;
        }

        public async Task<DbComponent> GetByComponent(string sku)
        {
            FilterDefinition<DbComponent> filter = Builders<DbComponent>.Filter.Eq(m => m.Id, sku.ToUpper());

            var databaseModel = await _context.Components.Find(filter).FirstOrDefaultAsync();

            return databaseModel;
        }

        public async Task<DbKit> GetByKit(string kitSku)
        {
            FilterDefinition<DbKit> filter = Builders<DbKit>.Filter.Eq(m => m.Id, kitSku.ToUpper());

            var kitModel = await _context.Kits.Find(filter).FirstOrDefaultAsync();

            return kitModel;
        }

        public async Task<string> InsertKit(KitAddRequest product)
        {
            DbKit kit = new DbKit
            {
                Id = product.Sku,
                Name = product.Name,
                Sku = product.Sku,
                Price = product.Price,
                ZREPrice = product.ZREPrice,
                ShopifyID = product.ShopifyID,
                ZREShopifyID = product.ZREShopifyID,
                Option = product.Option,
                WebActive = product.WebActive,
                ImageUrl = product.ImageUrl,
                HighlightA = product.HighlightA,
                HighlightB = product.HighlightB,
                HighlightC = product.HighlightC,
                Description = product.Description,
                ShortDescription = product.ShortDescription,
                ProductType = ProductType.kit,
                ManufacturingOptions = new DbManufacturingOptions(),
                ShippingOptions = new DbShippingOptions(),
                Documents = new DbProductDocuments(),
                ModifiedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                Components = product.Components
            };

            await _context.Kits.InsertOneAsync(kit);

            return kit.Id;
        }
    }
}