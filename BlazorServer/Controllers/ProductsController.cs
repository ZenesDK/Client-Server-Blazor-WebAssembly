#nullable enable
using BlazorServer.Data;
using CorpProductSystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await db.Products.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        db.Products.Add(product);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Product product)
    {
        var existing = await db.Products.FindAsync(id);
        if (existing is null) return NotFound();
        existing.Name = product.Name;
        existing.Price = product.Price;
        existing.Description = product.Description;
        await db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await db.Products.FindAsync(id);
        if (product is null) return NotFound();
        db.Products.Remove(product);
        await db.SaveChangesAsync();
        return NoContent();
    }
}