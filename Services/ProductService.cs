using Ćwiczenia10.Data;
using Ćwiczenia10.DTO;
using Ćwiczenia10.Models;
using Microsoft.EntityFrameworkCore;

namespace Ćwiczenia10.Services;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> AddProductAsync(ProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.ProductName,
            Weight = productDto.ProductWeight,
            Width = productDto.ProductWidth,
            Height = productDto.ProductHeight,
            Depth = productDto.ProductDepth
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        foreach (var categoryId in productDto.ProductCategories)
        {
            var productCategory = new ProductsCategories
            {
                ProductId = product.ProductId,
                CategoryId = categoryId
            };

            _context.ProductsCategories.Add(productCategory);
        }

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.ProductsCategories)
            .ThenInclude(pc => pc.Category)
            .FirstOrDefaultAsync(p => p.ProductId == id);
    }
}