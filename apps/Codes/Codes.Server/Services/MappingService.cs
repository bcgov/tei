namespace TEI.Codes.Server.Services;

using AutoMapper;
using TEI.Codes.Data;
using TEI.Database.Data.Entities;
using TEI.Database.Server.Access;

public class MappingService(IMapper mapper) : IMappingService
{
    public BcgEcoCodeParameters MapToBcgEcoCodeParameters(FilterBcgEcoCodesRequest source)
    {
        return mapper.Map<FilterBcgEcoCodesRequest, BcgEcoCodeParameters>(source);
    }

    public FilterBcgEcoCodesResponse MapToFilterBcgEcoCodesResponse(IList<Bgcecocode> source)
    {
        return new()
        {
            BgcCodeValues = Filter(source.Select(x => x.BgcCode)),
            ZoneCodeValues = Filter(source.Select(x => x.BgcCodeNavigation.ZoneCode)),
            SubzoneCodeValues = Filter(source.Select(x => x.BgcCodeNavigation.SubZoneCode)),
            VariantCodeValues = Filter(source.Select(x => x.BgcCodeNavigation.VariantCode)),
            PhaseCodeValues = Filter(source.Select(x => x.BgcCodeNavigation.PhaseCode)),
            EcosystemCodeValues = Filter(source.Select(x => x.EcoCode)),
            MapCodeValues = Filter(source.Select(x => x.EcoCodeNavigation.MapCode)),
            SiteSeriesCodeValues = Filter(source.Select(x => x.EcoCodeNavigation.SiteSeriesCode)),
            SsPhaseCodeValues = Filter(source.Select(x => x.EcoCodeNavigation.SsPhaseCode)),
            SeralCodeValues = Filter(source.Select(x => x.EcoCodeNavigation.SeralCode)),
            VariationCodeValues = Filter(source.Select(x => x.EcoCodeNavigation.VariationCode)),
            NbecCodeValues = Filter(source.Select(x => x.NbecCode)),
            SiteComponentCodeValues = Filter(source.Select(x => x.SiteComponentCode)),
            RealmCodeValues = Filter(source.Select(x => x.SiteComponentCodeNavigation?.RealmCode)),
            GroupCodeValues = Filter(source.Select(x => x.SiteComponentCodeNavigation?.GroupCode)),
            ClassCodeValues = Filter(source.Select(x => x.SiteComponentCodeNavigation?.ClassCode)),
            AssociationCodeValues = Filter(source.Select(x => x.SiteComponentCodeNavigation?.AssociationCode)),
            SubclassCodeValues = Filter(source.Select(x => x.SiteComponentCodeNavigation?.SubClassCode)),
            SourceValues = Filter(source.Select(x => x.Source)),
            EcosystemTypeValues = Filter(source.Select(x => x.EcoSystemType)),
            EcosystemSubtypeValues = Filter(source.Select(x => x.EcoSystemSubType)),
            KindTypeValues = Filter(source.Select(x => x.KindType)),
            SiteSeriesNameValues = Filter(source.Select(x => x.SiteSeriesName)),
            ForestedValues = source.Select(x => x.Forested).Distinct().ToList(),
            ApprovedValues = source.Select(x => x.Approved).Distinct().ToList(),
            ResultCount = source.Count,
            UniqueResult = source.Count == 1 ? this.MapToFullBgcEcoCode(source[0]) : null,
        };

        List<string> Filter(IEnumerable<string?> collection)
        {
            return collection.Distinct().OrderBy(x => x).Select(x => x ?? string.Empty).ToList();
        }
    }

    private FullBgcEcoCode MapToFullBgcEcoCode(Bgcecocode source)
    {
        return mapper.Map<Bgcecocode, FullBgcEcoCode>(source);
    }
}
