using System.Collections.Generic;
using System.Threading.Tasks;
using products_api.Products.Infrastructure.Context;

namespace products_api.Products.API.Interfaces
{
    public interface IComponentService
    {
        Task<List<DbComponent>> GetAll();
    }
}