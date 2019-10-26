using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using products_api.Products.API.Interfaces;
using products_api.Products.API.Interfaces.Queries;
using products_api.Products.Domain.Interfaces;
using products_api.Products.Infrastructure.Context;

namespace products_api.Products.Infrastructure.Repositories
{
    public class ComponentsRepository : IComponentsRepository, IComponentQueries
    {
        private readonly IProductContext _context;
        private readonly IMapper _mapper;

        public ComponentsRepository(IProductContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));;
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
    }
}