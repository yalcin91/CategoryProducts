using System.Threading.Tasks;

using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithCategoryById(int id);
    }
}
