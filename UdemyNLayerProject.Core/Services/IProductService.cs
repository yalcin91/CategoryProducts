using System.Threading.Tasks;

using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<Product> GetWithCategoryById(int id);
        // bool ControlInnerBarcoce(Product product);
    }
}
