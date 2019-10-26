using System.Collections.Generic;
using System.Threading.Tasks;
using products_api.Products.API.ViewModel;
using products_api.Products.Infrastructure.Context;

namespace products_api.Products.Domain.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<DbKit>> GetAllKits();
        Task<List<DbComponent>> GetAllComponents();
        Task<DbComponent> GetByComponent(string sku);
        Task<DbKit> GetByKit(string kitSku);
        Task<string> InsertKit(KitAddRequest product);
    }
}