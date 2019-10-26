using System.Collections.Generic;
using System.Threading.Tasks;
using products_api.Products.Infrastructure.Context;

namespace products_api.Products.Domain.Interfaces
{
    public interface IComponentsRepository
    {
        Task<List<DbComponent>> GetAllComponents();
        Task<DbComponent> GetByComponent(string sku);
    }
}