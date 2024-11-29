namespace TEI.Codes.Server.Mapping;

using AutoMapper;
using TEI.Codes.Data;
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
            .ForMember(x => x.Id, o => o.MapFrom(x => x.BgcEcocodeId))
            .ForMember(x => x.EcosystemCode, o => o.MapFrom(x => x.EcoCode))
            .ForMember(x => x.EcosystemType, o => o.MapFrom(x => x.EcoSystemType))
            .ForMember(x => x.EcosystemSubtype, o => o.MapFrom(x => x.EcoSystemSubType));
    }
}
