using System.Collections.Generic;
using System.Threading.Tasks;
using products_api.Products.API.ViewModel;
using products_api.Products.Infrastructure.Context;

namespace products_api.Products.Domain.Interfaces
{
    public interface IKitsRepository
    {
        Task<List<DbKit>> GetAllKits();
        Task<DbKit> GetByKit(string kitSku);
        Task<string> InsertKit(KitAddRequest product);
    }
}