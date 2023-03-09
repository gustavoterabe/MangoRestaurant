using Mango.Services.ProductAPI.ViewModels;

namespace Mango.Services.ProductAPI.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<ProductViewModel>> GetProducts();
    Task<ProductViewModel> GetProductById(int productId);
    Task<ProductViewModel> CreateUpdateProduct(ProductViewModel productViewModel);
    Task<bool> DeleteProduct(int productId);
}