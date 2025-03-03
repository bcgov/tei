namespace TEI.Common.Data.Models;

using System.Text.Json.Serialization;

[method: JsonConstructor]
public record PaginatedResult<T>(T Data, int TotalCount, int PageIndex, int PageSize)
{
    public PaginatedResult(T data, int totalCount, PaginatedRequest request) : this(data, totalCount, request.PageIndex, request.PageSize) { }

    public PaginatedResult<TOutput> Transform<TOutput>(Func<T, TOutput> transformFunction)
    {
        return new(transformFunction(this.Data), this.TotalCount, this.PageIndex, this.PageSize);
    }
}
