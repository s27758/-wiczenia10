using Ćwiczenia10.DTO;
using Ćwiczenia10.Models;

namespace Ćwiczenia10.Services;

public interface IProductService
{
    Task<Product> AddProductAsync(ProductDto productDto);
    Task<Product> GetProductByIdAsync(int id);
}
