using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductRepository repo) : ControllerBase
{
    [HttpGet] // api/products
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(string? brand, string? type, string? sort)
    {
        return Ok(await repo.GetProductsAsync(brand, type, sort));
    }

    [HttpGet("{id:int}")] // api/products/{id}
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        Product? product = await repo.GetProductByIdAsync(id);

        if (product == null) return NotFound();

        return product;
    }

    [HttpPost] // api/products
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        repo.AddProduct(product);

        if (await repo.SaveChangesAsync())
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);

        return BadRequest("Problem creating product");
    }

    [HttpPut("{id:int}")] // api/products/{id}
    public async Task<ActionResult> UpdateProduct(int id, Product product)
    {
        if (id != product.Id || !ProductExists(id))
            return BadRequest("Cannot update this product");

        repo.UpdateProduct(product);

        if (await repo.SaveChangesAsync())
            return NoContent();

        return BadRequest("Problem updating the product");
    }

    [HttpDelete("{id:int}")] // api/products/{id}
    public async Task<ActionResult> DeleteProduct(int id)
    {
        Product? product = await repo.GetProductByIdAsync(id);

        if (product == null) return NotFound();

        repo.DeleteProduct(product);

        if (await repo.SaveChangesAsync())
            return NoContent();

        return BadRequest("Problem deleting the product");
    }

    [HttpGet("brands")] // api/products/brands
    public async Task<ActionResult<IReadOnlyList<string>>> GetProductBrands()
    {
        return Ok(await repo.GetProductBrandsAsync());
    }

    [HttpGet("types")] // api/products/types
    public async Task<ActionResult<IReadOnlyList<string>>> GetProductTypes()
    {
        return Ok(await repo.GetProductTypesAsync());
    }

    private bool ProductExists(int id)
    {
        return repo.ProductExists(id);
    }
}