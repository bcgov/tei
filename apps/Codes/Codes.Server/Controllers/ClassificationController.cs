namespace TEI.Codes.Server.Controllers;

using Microsoft.AspNetCore.Mvc;
using TEI.Codes.Data.Models;
using TEI.Codes.Server.Services;
using TEI.Common.Data.Models;
using TEI.Database.Data.Entities;
using TEI.Database.Server.Access;

[ApiController]
[Route("[controller]")]
public class ClassificationController(IBgcRepository bgcRepository, IMappingService mappingService) : ControllerBase
{
    [HttpPost]
    [Route("FilterBgcEcoCodes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<PaginatedResult<FilterBcgEcoCodesResponse>> FilterBgcEcoCodes(FilterBcgEcoCodesRequest request, CancellationToken ct)
    {
        BcgEcoCodeParameters parameters = mappingService.MapToBcgEcoCodeParameters(request);

        IList<Bgcecocode> data = await bgcRepository.RetrieveBgcEcoCodesAsync(parameters, ct);

        PaginatedRequest<IList<Bgcecocode>> paginatedRequest = new(data) { PageSize = 1000 };
        return mappingService.MapToFilterBcgEcoCodesResponse(paginatedRequest);
    }
}
