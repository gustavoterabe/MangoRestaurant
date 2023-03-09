using AutoMapper;
using Mango.Services.ProductAPI.DbContext;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;
    private IMapper _mapper;

    public ProductRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductViewModel>> GetProducts()
    {
        List<Product> products = await _db.Products.ToListAsync();
        return _mapper.Map<List<ProductViewModel>>(products);
    }

    public async Task<ProductViewModel> GetProductById(int productId)
    {
        Product product = await _db.Products
            .Where(p => p.ProductId == productId)
            .FirstOrDefaultAsync();
        
        return _mapper.Map<ProductViewModel>(product);
    }

    public async Task<ProductViewModel> CreateUpdateProduct(ProductViewModel productViewModel)
    {
        Product product = _mapper.Map<ProductViewModel, Product>(productViewModel);

        if (product.ProductId > 0)
        {
            _db.Products.Update(product);
        }
        else
        {
            _db.Products.Add(product);
        }

        await _db.SaveChangesAsync();

        return _mapper.Map<Product, ProductViewModel>(product);
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        try
        {
            Product product = await _db.Products
                .FirstOrDefaultAsync(p => p.ProductId == productId);

            if (product == null) return false;

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}