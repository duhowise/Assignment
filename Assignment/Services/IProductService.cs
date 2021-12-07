using Assignment.Models;

namespace Assignment.Services;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
}