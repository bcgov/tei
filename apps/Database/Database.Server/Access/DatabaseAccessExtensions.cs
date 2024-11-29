namespace TEI.Database.Server.Access;

using System.Linq.Expressions;

public static class DatabaseAccessExtensions
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool predicate, Expression<Func<T, bool>> filter)
    {
        return predicate ? query.Where(filter) : query;
    }

    public static IQueryable<T> WhereStringMatches<T>(this IQueryable<T> query, string? parameter, Expression<Func<T, bool>> filterForParameter)
    {
        return query.WhereIf(!string.IsNullOrEmpty(parameter), filterForParameter);
    }

    public static IQueryable<T> WhereStringMatchesAllowEmpty<T>(this IQueryable<T> query, string? parameter, Expression<Func<T, bool>> filterForParameter, Expression<Func<T, bool>> filterForEmpty)
    {
        return query.WhereIf(!string.IsNullOrEmpty(parameter), filterForParameter).WhereIf(parameter is { Length: 0 }, filterForEmpty);
    }
}
