using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class SpecificationEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
    {
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria); // filter example: x => x.Brand == brand
        }

        if (spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy); // sort example: x => x.Name
        }

        if (spec.OrderByDescending != null)
        {
            query = query.OrderByDescending(spec.OrderByDescending); // sort example: x => x.Name
        }

        if (spec.IsDistinct)
        {
            query = query.Distinct();
        }

        return query;
    }

    // Overload for GetQuery with TResult
    public static IQueryable<TResult> GetQuery<TResult>(IQueryable<T> query, ISpecification<T, TResult> spec)
    {
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria); // filter example: x => x.Brand == brand
        }

        if (spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy); // sort example: x => x.Name
        }

        if (spec.OrderByDescending != null)
        {
            query = query.OrderByDescending(spec.OrderByDescending); // sort example: x => x.Name
        }

        var selectQuery = query as IQueryable<TResult>;

        if (spec.Select != null)
        {
            selectQuery = query.Select(spec.Select); // select example: x => new { x.Name, x.Price
        }

        if (spec.IsDistinct)
        {
            selectQuery = selectQuery?.Distinct();
        }

        return selectQuery ?? query.Cast<TResult>();
    }
}