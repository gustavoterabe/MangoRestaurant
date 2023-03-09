using Mango.Services.ProductAPI.Repositories;
using Mango.Services.ProductAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers;

[ApiController]
[Route("api/products")]
public class Product : ControllerBase
{
    protected ResponseViewModel _response;
    private readonly IProductRepository _productRepository;

    public Product(IProductRepository productRepository)
    {
        _productRepository = productRepository;
        _response = new ResponseViewModel();
    }

    [HttpGet]
    public async Task<object> Get()
    {
        try
        {
            IEnumerable<ProductViewModel> productViewModels = await _productRepository.GetProducts();
            _response.Result = productViewModels;
        }
        catch (Exception e)
        {
            _response.isSuccess = false;
            _response.ErrorMessages = new List<string>
            {
                e.ToString()
            };
        }

        return _response;
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<object> Get(int id)
    {
        try
        {
            ProductViewModel productViewModel = await _productRepository.GetProductById(id);
            _response.Result = productViewModel;
        }
        catch (Exception e)
        {
            _response.isSuccess = false;
            _response.ErrorMessages = new List<string>
            {
                e.ToString()
            };
        }

        return _response;
    }

}