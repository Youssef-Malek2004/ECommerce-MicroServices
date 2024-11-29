using Abstractions.ResultsPattern;
using Products.Domain.DTOs;
using Products.Domain.Entities;

namespace Products.Application.Services;

public interface IProductsRepository
{
    Task<Result<IEnumerable<Product>>> GetProducts(); 
    Task<Result<Product>> CreateProduct(CreateProductDto product); 
    Task<Result<Product>> GetProductById(string id); 
    Task<Result<Product>> UpdateProduct(string id, UpdateProductDto product); 
    Task<Result> DeleteProduct(string id); 
    Task<Result<IEnumerable<Product>>> GetProductsByCategory(string categoryId);
    Task<Result<IEnumerable<Product>>> SearchProducts(string searchTerm); 
}