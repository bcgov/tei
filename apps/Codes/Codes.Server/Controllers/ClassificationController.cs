namespace TEI.Codes.Server.Controllers;

using Microsoft.AspNetCore.Mvc;
using TEI.Codes.Data;
using TEI.Codes.Server.Services;
using TEI.Database.Data.Entities;
using TEI.Database.Server.Access;

[ApiController]
[Route("[controller]")]
public class ClassificationController(IBgcRepository bgcRepository, IMappingService mappingService) : ControllerBase
{
    [HttpPost]
    [Route("FilterBgcEcoCodes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<FilterBcgEcoCodesResponse> FilterBgcEcoCodes(FilterBcgEcoCodesRequest request, CancellationToken ct)
    {
        BcgEcoCodeParameters parameters = mappingService.MapToBcgEcoCodeParameters(request);

        IList<Bgcecocode> codes = await bgcRepository.RetrieveBgcEcoCodesAsync(parameters, ct);

        return mappingService.MapToFilterBcgEcoCodesResponse(codes);
    }
}
