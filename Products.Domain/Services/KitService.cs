using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using products_api.Products.API.Interfaces;
using products_api.Products.API.ViewModel;
using products_api.Products.Domain.Interfaces;
using products_api.Products.Infrastructure.Context;

namespace products_api.Products.Domain.Services
{
    public class KitService : IKitService
    {
        // private readonly IProductsRepository _repository;
        private readonly IComponentsRepository _componentsRepository;
        private readonly IKitsRepository _kitsRepository;
        private readonly ILogger<KitService> _logger;
        private readonly IMapper _mapper;
        public KitService(IComponentsRepository componentsRepository, IKitsRepository kitsRepository, ILogger<KitService> logger, IMapper mapper)
        {
            _componentsRepository = componentsRepository;
            _kitsRepository = kitsRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<KitViewModel>> GetAll()
        {
            var viewList = new List<KitViewModel>();

            var kitList = await _kitsRepository.GetAllKits();
            _logger.LogInformation("Successfully received list of kits");

            viewList = _mapper.Map<List<KitViewModel>>(kitList);
            return viewList;
        }

        public async Task<KitViewModel> GetBySku(string sku)
        {
            var view = new KitViewModel();

            var kit = new DbKit();

            kit = await _kitsRepository.GetByKit(sku);

            _logger.LogInformation("Successfully received kit by sku id");

            view = _mapper.Map<KitViewModel>(kit);
            return view;
        }

        public async Task<List<DbComponent>> GetKitComponents(string kitSku)
        {
            var kit = await _kitsRepository.GetByKit(kitSku);

            _logger.LogInformation("Received list of kits");

            var componentsList = new List<DbComponent>();

            foreach (var sku in kit.Components)
            {
                var component = await _componentsRepository.GetByComponent(sku);

                componentsList.Add(component);
            }

            return componentsList;
        }

        public async Task<string> InsertKit(KitAddRequest kitIn)
        {
            var response = await _kitsRepository.InsertKit(kitIn);
            return response;
        }
    }
}