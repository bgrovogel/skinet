using Core.Entities;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(ProductSpecParams specParams) : base(product =>
        (string.IsNullOrEmpty(specParams.Search) || product.Name.ToLower().Contains(specParams.Search)) &&
        (!specParams.Brands.Any() || specParams.Brands.Contains(product.Brand)) &&
        (!specParams.Types.Any() || specParams.Types.Contains(product.Type)))
    {
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

        switch (specParams.Sort)
        {
            case "priceAsc":
                AddOrderBy(product => product.Price);
                break;
            case "priceDesc":
                AddOrderByDescending(product => product.Price);
                break;
            default:
                AddOrderBy(product => product.Name);
                break;
        }
    }
}