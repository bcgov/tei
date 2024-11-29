namespace TEI.Codes.Data;

public record FilterBcgEcoCodesRequest
{
    public string? BgcCode { get; set; }
    public string? ZoneCode { get; set; }
    public string? SubzoneCode { get; set; }
    public string? VariantCode { get; set; }
    public string? PhaseCode { get; set; }
    public string? EcosystemCode { get; set; }
    public string? MapCode { get; set; }
    public string? SiteSeriesCode { get; set; }
    public string? SsPhaseCode { get; set; }
    public string? SeralCode { get; set; }
    public string? VariationCode { get; set; }
    public string? NbecCode { get; set; }
    public string? SiteComponentCode { get; set; }
    public string? RealmCode { get; set; }
    public string? GroupCode { get; set; }
    public string? ClassCode { get; set; }
    public string? AssociationCode { get; set; }
    public string? SubclassCode { get; set; }
    public string? EcosystemType { get; set; }
    public string? EcosystemSubtype { get; set; }
    public string? KindType { get; set; }
    public string? SiteSeriesName { get; set; }
    public bool? Forested { get; set; }
    public string? Source { get; set; }
    public bool? Approved { get; set; }
}

public record FilterBcgEcoCodesResponse
{
    public required List<string> BgcCodeValues { get; init; }
    public required List<string> ZoneCodeValues { get; init; }
    public required List<string> SubzoneCodeValues { get; init; }
    public required List<string> VariantCodeValues { get; init; }
    public required List<string> PhaseCodeValues { get; init; }
    public required List<string> EcosystemCodeValues { get; init; }
    public required List<string> MapCodeValues { get; init; }
    public required List<string> SiteSeriesCodeValues { get; init; }
    public required List<string> SsPhaseCodeValues { get; init; }
    public required List<string> SeralCodeValues { get; init; }
    public required List<string> VariationCodeValues { get; init; }
    public required List<string> NbecCodeValues { get; init; }
    public required List<string> SiteComponentCodeValues { get; init; }
    public required List<string> RealmCodeValues { get; init; }
    public required List<string> GroupCodeValues { get; init; }
    public required List<string> ClassCodeValues { get; init; }
    public required List<string> AssociationCodeValues { get; init; }
    public required List<string> SubclassCodeValues { get; init; }
    public required List<string> SourceValues { get; init; }
    public required List<string> EcosystemTypeValues { get; init; }
    public required List<string> EcosystemSubtypeValues { get; init; }
    public required List<string> KindTypeValues { get; init; }
    public required List<string> SiteSeriesNameValues { get; init; }
    public required List<bool> ForestedValues { get; init; }
    public required List<bool> ApprovedValues { get; init; }
    public required int ResultCount { get; init; }
    public required FullBgcEcoCode? UniqueResult { get; init; }
}

public record FullBgcEcoCode
{
    public int Id { get; set; }
    public string BgcCode { get; set; } = string.Empty;
    public string ZoneCode { get; set; } = string.Empty;
    public string SubzoneCode { get; set; } = string.Empty;
    public string VariantCode { get; set; } = string.Empty;
    public string PhaseCode { get; set; } = string.Empty;
    public string EcosystemCode { get; set; } = string.Empty;
    public string MapCode { get; set; } = string.Empty;
    public string SiteSeriesCode { get; set; } = string.Empty;
    public string SsPhaseCode { get; set; } = string.Empty;
    public string SeralCode { get; set; } = string.Empty;
    public string VariationCode { get; set; } = string.Empty;
    public string NbecCode { get; set; } = string.Empty;
    public string SiteComponentCode { get; set; } = string.Empty;
    public string RealmCode { get; set; } = string.Empty;
    public string GroupCode { get; set; } = string.Empty;
    public string ClassCode { get; set; } = string.Empty;
    public string AssociationCode { get; set; } = string.Empty;
    public string SubclassCode { get; set; } = string.Empty;
    public string EcosystemType { get; set; } = string.Empty;
    public string EcosystemSubtype { get; set; } = string.Empty;
    public string KindType { get; set; } = string.Empty;
    public string SiteSeriesName { get; set; } = string.Empty;
    public bool Forested { get; set; }
    public string Source { get; set; } = string.Empty;
    public DateOnly DateAdded { get; set; }
    public bool Approved { get; set; }
}
