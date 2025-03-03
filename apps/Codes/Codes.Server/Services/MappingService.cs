namespace TEI.Codes.Server.Services;

using AutoMapper;
using TEI.Codes.Data.Models;
using TEI.Common.Data.Models;
using TEI.Common.Server;
using TEI.Database.Data.Entities;
using TEI.Database.Server.Access;

public class MappingService(IMapper mapper) : IMappingService
{
    public BcgEcoCodeParameters MapToBcgEcoCodeParameters(FilterBcgEcoCodesRequest source)
    {
        return mapper.Map<FilterBcgEcoCodesRequest, BcgEcoCodeParameters>(source);
    }

    public PaginatedResult<FilterBcgEcoCodesResponse> MapToFilterBcgEcoCodesResponse(PaginatedRequest<IList<Bgcecocode>> request)
    {
        IList<Bgcecocode> source = request.Data;
        FilterBcgEcoCodesResponse response = new()
        {
            BgcCodeValues = SortValuesAlphabetically(source.Select(x => GenerateCodeDescription(x.BgcCode, x.BgcCodeNavigation.Detail))),
            ZoneCodeValues = SortValuesAlphabetically(source.Select(x => GenerateCodeDescription(x.BgcCodeNavigation.ZoneCode, x.BgcCodeNavigation.ZoneCodeNavigation.Detail))),
            SubzoneCodeValues = SortAlphabetically(source.Select(x => x.BgcCodeNavigation.SubZoneCode)),
            VariantCodeValues = SortAlphabetically(source.Select(x => x.BgcCodeNavigation.VariantCode)),
            PhaseCodeValues = SortAlphabetically(source.Select(x => x.BgcCodeNavigation.PhaseCode)),
            EcosystemCodeValues = SortAlphabetically(source.Select(x => x.EcoCode)),
            MapCodeValues = SortAlphabetically(source.Select(x => x.EcoCodeNavigation.MapCode)),
            SiteSeriesCodeValues = SortNumerically(source.Select(x => x.EcoCodeNavigation.SiteSeriesCode)),
            SsPhaseCodeValues = SortAlphabetically(source.Select(x => x.EcoCodeNavigation.SsPhaseCode)),
            SeralCodeValues = SortAlphabetically(source.Select(x => x.EcoCodeNavigation.SeralCode)),
            VariationCodeValues = SortAlphabetically(source.Select(x => x.EcoCodeNavigation.VariationCode)),
            NbecCodeValues = SortAlphabetically(source.Select(x => x.NbecCode)),
            SiteComponentCodeValues = SortAlphabetically(source.Select(x => x.SiteComponentCode)),
            RealmCodeValues = SortAlphabetically(source.Select(x => x.SiteComponentCodeNavigation?.RealmCode)),
            GroupCodeValues = SortAlphabetically(source.Select(x => x.SiteComponentCodeNavigation?.GroupCode)),
            ClassCodeValues = SortAlphabetically(source.Select(x => x.SiteComponentCodeNavigation?.ClassCode)),
            AssociationCodeValues = SortAlphabetically(source.Select(x => x.SiteComponentCodeNavigation?.AssociationCode)),
            SubclassCodeValues = SortAlphabetically(source.Select(x => x.SiteComponentCodeNavigation?.SubClassCode)),
            SourceValues = SortAlphabetically(source.Select(x => x.Source)),
            EcosystemTypeValues = SortValuesAlphabetically(source.Select(x => GenerateCodeDescription(x.EcoSystemType, x.EcoSystemTypeNavigation?.Detail))),
            EcosystemSubtypeValues = SortValuesAlphabetically(source.Select(x => GenerateCodeDescription(x.EcoSystemSubType, x.EcoSystemSubTypeNavigation?.Detail))),
            KindTypeValues = SortValuesAlphabetically(source.Select(x => GenerateCodeDescription(x.KindType, x.KindTypeNavigation?.Detail))),
            SiteSeriesNameValues = SortAlphabetically(source.Select(x => x.SiteSeriesName)),
            ForestedValues = source.Select(x => x.Forested).Distinct().ToList(),
            ApprovedValues = source.Select(x => x.Approved).Distinct().ToList(),
            ResultPreviews = source.Skip(request.SkipAmount).Take(request.PageSize).Select(GenerateResultPreview).ToList(),
            UniqueResult = source.Count == 1 ? this.MapToFullBgcEcoCode(source[0]) : null,
        };

        return new(response, source.Count, request);

        ResultPreview GenerateResultPreview(Bgcecocode x)
        {
            return new()
            {
                BgcLabel = x.BgcCode,
                BgcDetail = x.BgcCodeNavigation.Detail,
                ZoneDetail = x.BgcCodeNavigation.ZoneCodeNavigation.Detail,
                EcosystemCode = x.EcoCode,
                SiteSeriesName = x.SiteSeriesName ?? string.Empty,
                Source = x.Source ?? string.Empty,
                Approved = x.Approved,
            };
        }

        CodeDescription GenerateCodeDescription(string? value, string? description)
        {
            return new() { Value = value ?? string.Empty, Description = description };
        }

        List<string> SortAlphabetically(IEnumerable<string?> collection)
        {
            return collection.Distinct().OrderBy(x => x).Select(x => x ?? string.Empty).ToList();
        }

        List<string> SortNumerically(IEnumerable<string?> collection)
        {
            return collection.Distinct().OrderBy(x => x.AsInt()).Select(x => x ?? string.Empty).ToList();
        }

        List<CodeDescription> SortValuesAlphabetically(IEnumerable<CodeDescription> collection)
        {
            return collection.Distinct().OrderBy(x => x.Value).ToList();
        }
    }

    private FullBgcEcoCode MapToFullBgcEcoCode(Bgcecocode source)
    {
        return mapper.Map<Bgcecocode, FullBgcEcoCode>(source);
    }
}
