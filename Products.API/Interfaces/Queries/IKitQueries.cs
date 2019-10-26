using System.Collections.Generic;
using System.Threading.Tasks;
using products_api.Products.API.ViewModel;

namespace products_api.Products.API.Interfaces.Queries
{
    public interface IKitQueries
    {
         Task<List<KitViewModel>> GetAllKitsView();
    }
}