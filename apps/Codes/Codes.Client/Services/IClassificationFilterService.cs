namespace TEI.Codes.Client.Services;

using TEI.Codes.Client.Models.Classification;
using TEI.Codes.Data.Models;
using TEI.Common.Data.Models;

/// <summary>
/// Handles filter logic relating to forming and sending requests and manipulating responses.
/// </summary>
public interface IClassificationFilterService
{
    IDictionary<ClassificationFieldType, ClassificationInputField> InputFields { get; }
    IDictionary<ClassificationFieldType, ClassificationOutputField> OutputFields { get; }
    PaginatedResult<FilterBcgEcoCodesResponse>? FilterResponse { get; }
    bool Loading { get; }
    bool FiltersAreEmpty { get; }
    bool HistoryIsEmpty { get; }
    void ClearAllFilters();
    void RestorePreviousFilter();
    Task FilterResultsAsync();
    Task FilterToResultAsync(ResultPreview preview);
}
