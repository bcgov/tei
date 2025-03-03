namespace TEI.Codes.Client.Models.Classification;

using System.Runtime.Serialization;

public enum ClassificationFieldType
{
    Unspecified,

    [EnumMember(Value = "BGC Label")]
    BgcLabel,

    Zone,

    Subzone,

    Variant,

    Phase,

    [EnumMember(Value = "Ecosystem Code")]
    EcosystemCode,

    [EnumMember(Value = "Map Code")]
    MapCode,

    [EnumMember(Value = "Site Series")]
    SiteSeries,

    [EnumMember(Value = "SS Phase")]
    SsPhase,

    Seral,

    Variation,

    [EnumMember(Value = "nBEC Code")]
    NbecCode,

    [EnumMember(Value = "Site Component Code")]
    SiteComponentCode,

    Realm,

    Group,

    Class,

    Association,

    Subclass,

    [EnumMember(Value = "Site Series Name")]
    SiteSeriesName,

    Forested,

    [EnumMember(Value = "Ecosystem Type")]
    EcosystemType,

    [EnumMember(Value = "Ecosystem Subtype")]
    EcosystemSubtype,

    [EnumMember(Value = "Kind Type")]
    KindType,

    Source,

    [EnumMember(Value = "Date Added")]
    DateAdded,

    Approved,
}
