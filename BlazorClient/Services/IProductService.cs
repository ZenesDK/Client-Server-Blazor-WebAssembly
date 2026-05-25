#nullable enable
using CorpProductSystem.Shared.Models;

namespace BlazorClient.Services;
public interface IProductService
{
    Task<IEnumerable<Product>> GetAsync();
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}