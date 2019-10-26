using System.Collections.Generic;
using System.Threading.Tasks;
using products_api.Products.API.ViewModel;
using products_api.Products.Infrastructure.Context;

namespace products_api.Products.API.Interfaces
{
    public interface IKitService
    {
        Task<List<KitViewModel>> GetAll();
        Task<List<DbComponent>> GetKitComponents(string kitSku);
        Task<KitViewModel> GetBySku(string sku);
        Task<string> InsertKit(KitAddRequest kitIn);
    }
}