using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

// No longer used due to Generic Repository pattern can be deleted
public class ProductRepository(StoreContext context) : IProductRepository
{
    public void AddProduct(Product product)
    {
        context.Products.Add(product);
    }

    public void DeleteProduct(Product product)
    {
        context.Products.Remove(product);
    }

    public async Task<IReadOnlyList<string>> GetProductBrandsAsync()
    {
        return await context.Products.Select(product => product.Brand).Distinct().ToListAsync();
    }

    public async Task<IReadOnlyList<string>> GetProductTypesAsync()
    {
        return await context.Products.Select(product => product.Type).Distinct().ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, string? type, string? sort)
    {
        var query = context.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(brand))
            query = query.Where(product => product.Brand == brand);

        if (!string.IsNullOrWhiteSpace(type))
            query = query.Where(product => product.Type == type);

        switch (sort)
        {
            case "priceAsc":
                query = query.OrderBy(product => product.Price);
                break;
            case "priceDesc":
                query = query.OrderByDescending(product => product.Price);
                break;
            default:
                query = query.OrderBy(product => product.Name);
                break;
        }

        return await query.ToListAsync();
    }

    public bool ProductExists(int id)
    {
        return context.Products.Any(product => product.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void UpdateProduct(Product product)
    {
        context.Entry(product).State = EntityState.Modified;
    }
}
