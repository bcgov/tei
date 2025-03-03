namespace TEI.Common.Data.Models;

public record PaginatedRequest
{
    public int PageIndex { get; init; } = 0;
    public required int PageSize { get; init; }

    public int SkipAmount => this.PageIndex * this.PageSize;
}

public record PaginatedRequest<T>(T Data) : PaginatedRequest;
