namespace TEI.Codes.Server.Mapping;

using AutoMapper;
using TEI.Codes.Data.Models;
using TEI.Database.Data.Entities;
using TEI.Database.Server.Access;

public class ClassificationProfile : Profile
{
    public ClassificationProfile()
    {
        this.CreateMap<FilterBcgEcoCodesRequest, BcgEcoCodeParameters>();

        this.CreateMap<Bgccode, FullBgcEcoCode>(MemberList.None)
            .ForMember(x => x.SubzoneCode, o => o.MapFrom(x => x.SubZoneCode));

        this.CreateMap<Ecocode, FullBgcEcoCode>(MemberList.None);

        this.CreateMap<Sitecomponentcode, FullBgcEcoCode>(MemberList.None)
            .ForMember(x => x.SubclassCode, o => o.MapFrom(x => x.SubClassCode));

        this.CreateMap<Bgcecocode, FullBgcEcoCode>()
            .IncludeMembers(x => x.BgcCodeNavigation, x => x.EcoCodeNavigation, x => x.SiteComponentCodeNavigation)
            .ForMember(
                x => x.BgcCode,
                o => o.MapFrom(x => new CodeDescription { Value = x.BgcCode, Description = x.BgcCodeNavigation.Detail }))
            .ForMember(
                x =>
                    x.ZoneCode,
                o => o.MapFrom(x => new CodeDescription { Value = x.BgcCodeNavigation.ZoneCode, Description = x.BgcCodeNavigation.ZoneCodeNavigation.Detail }))
            .ForMember(
                x => x.MapCode,
                o => o.MapFrom(
                    x => x.EcoCodeNavigation.MapCodeNavigation == null
                        ? null
                        : new CodeDescription { Value = x.EcoCodeNavigation.MapCodeNavigation.MapCode, Description = x.EcoCodeNavigation.MapCodeNavigation.Detail }))
            .ForMember(
                x => x.EcosystemType,
                o => o.MapFrom(x => x.EcoSystemTypeNavigation == null ? null : new CodeDescription { Value = x.EcoSystemTypeNavigation.EcoSystemType, Description = x.EcoSystemTypeNavigation.Detail }))
            .ForMember(
                x => x.EcosystemSubtype,
                o => o.MapFrom(
                    x => x.EcoSystemSubTypeNavigation == null
                        ? null
                        : new CodeDescription { Value = x.EcoSystemSubTypeNavigation.EcoSystemSubType, Description = x.EcoSystemSubTypeNavigation.Detail }))
            .ForMember(
                x => x.KindType,
                o => o.MapFrom(x => x.KindTypeNavigation == null ? null : new CodeDescription { Value = x.KindTypeNavigation.KindType, Description = x.KindTypeNavigation.Detail }))
            .ForMember(
                x => x.Id,
                o => o.MapFrom(x => x.BgcEcocodeId))
            .ForMember(
                x => x.EcosystemCode,
                o => o.MapFrom(x => x.EcoCode));
    }
}
