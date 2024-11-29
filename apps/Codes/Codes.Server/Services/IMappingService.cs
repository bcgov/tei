namespace TEI.Codes.Server.Services;

using TEI.Codes.Data;
using TEI.Database.Data.Entities;
using TEI.Database.Server.Access;

public interface IMappingService
{
    BcgEcoCodeParameters MapToBcgEcoCodeParameters(FilterBcgEcoCodesRequest source);
    FilterBcgEcoCodesResponse MapToFilterBcgEcoCodesResponse(IList<Bgcecocode> source);
}
