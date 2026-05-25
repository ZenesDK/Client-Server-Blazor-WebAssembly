#nullable enable
using System.Net.Http.Json;
using CorpProductSystem.Shared.Models;

namespace BlazorClient.Services;

public class ProductService(HttpClient http) : IProductService
{
    public async Task<IEnumerable<Product>> GetAsync()
    {
        try
        {
            return await http.GetFromJsonAsync<IEnumerable<Product>>("api/products") ?? [];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка загрузки товаров: {ex.Message}");
            return [];
        }
    }

    public async Task AddAsync(Product p)
    {
        try
        {
            await http.PostAsJsonAsync("api/products", p);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка добавления товара: {ex.Message}");
            throw;
        }
    }

    public async Task UpdateAsync(Product p)
    {
        try
        {
            await http.PutAsJsonAsync($"api/products/{p.Id}", p);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка обновления товара: {ex.Message}");
            throw;
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            await http.DeleteAsync($"api/products/{id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка удаления товара: {ex.Message}");
            throw;
        }
    }
}