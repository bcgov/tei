namespace TEI.Codes.Server.Services;

using TEI.Codes.Data.Models;
using TEI.Common.Data.Models;
using TEI.Database.Model.Entities;
using TEI.Database.Server.Access;

public interface IMappingService
{
    BcgEcoCodeParameters MapToBcgEcoCodeParameters(FilterBcgEcoCodesRequest source);
    PaginatedResult<FilterBcgEcoCodesResponse> MapToFilterBcgEcoCodesResponse(PaginatedRequest<IList<Bgcecocode>> request);
}
