using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using products_api.Products.API.Interfaces;
using products_api.Products.Domain.Interfaces;
using products_api.Products.Infrastructure.Context;

namespace products_api.Products.Domain.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IComponentsRepository _componentsRepository;
        private readonly ILogger<ComponentService> _logger;

        public ComponentService(IComponentsRepository componentsRepository, ILogger<ComponentService> logger)
        {
            _componentsRepository = componentsRepository;
            _logger = logger;
        }

        public async Task<List<DbComponent>> GetAll()
        {
            return await _componentsRepository.GetAllComponents();
        }
    }
}