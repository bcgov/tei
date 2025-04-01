namespace TEI.Database.Server.Access;

using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TEI.Database.Model.Context;
using TEI.Database.Model.Entities;

public interface IBgcRepository
{
    Task<IList<Bgcecocode>> RetrieveBgcEcoCodesAsync(BcgEcoCodeParameters parameters, CancellationToken ct = default);
}

public class BgcRepository(TeiDbContext dbContext) : IBgcRepository
{
    [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records")]
    public async Task<IList<Bgcecocode>> RetrieveBgcEcoCodesAsync(BcgEcoCodeParameters parameters, CancellationToken ct = default)
    {
        IQueryable<Bgcecocode> query = dbContext.Bgcecocodes
            .AsNoTracking()
            .Include(x => x.BgcCodeNavigation)
            .ThenInclude(x => x.ZoneCodeNavigation)
            .Include(x => x.EcoCodeNavigation)
            .ThenInclude(x => x.MapCodeNavigation)
            .Include(x => x.SiteComponentCodeNavigation)
            .Include(x => x.EcoSystemTypeNavigation)
            .Include(x => x.EcoSystemSubTypeNavigation)
            .Include(x => x.KindTypeNavigation)
            .WhereStringMatches(parameters.BgcCode, x => x.BgcCode == parameters.BgcCode)
            .WhereStringMatches(parameters.ZoneCode, x => x.BgcCodeNavigation.ZoneCode == parameters.ZoneCode)
            .WhereStringMatches(parameters.SubzoneCode, x => x.BgcCodeNavigation.SubZoneCode == parameters.SubzoneCode)
            .WhereStringMatchesAllowEmpty(parameters.VariantCode, x => x.BgcCodeNavigation.VariantCode == parameters.VariantCode, x => x.BgcCodeNavigation.VariantCode == null)
            .WhereStringMatchesAllowEmpty(parameters.PhaseCode, x => x.BgcCodeNavigation.PhaseCode == parameters.PhaseCode, x => x.BgcCodeNavigation.PhaseCode == null)
            .WhereStringMatchesAllowEmpty(parameters.MapCode, x => x.EcoCodeNavigation.MapCode == parameters.MapCode, x => x.EcoCodeNavigation.MapCode == null)
            .WhereStringMatchesAllowEmpty(parameters.SiteSeriesCode, x => x.EcoCodeNavigation.SiteSeriesCode == parameters.SiteSeriesCode, x => x.EcoCodeNavigation.SiteSeriesCode == null)
            .WhereStringMatchesAllowEmpty(parameters.SsPhaseCode, x => x.EcoCodeNavigation.SsPhaseCode == parameters.SsPhaseCode, x => x.EcoCodeNavigation.SsPhaseCode == null)
            .WhereStringMatchesAllowEmpty(parameters.SeralCode, x => x.EcoCodeNavigation.SeralCode == parameters.SeralCode, x => x.EcoCodeNavigation.SeralCode == null)
            .WhereStringMatchesAllowEmpty(parameters.VariationCode, x => x.EcoCodeNavigation.VariationCode == parameters.VariationCode, x => x.EcoCodeNavigation.VariationCode == null)
            .WhereStringMatches(parameters.EcosystemCode, x => x.EcoCode == parameters.EcosystemCode)
            .WhereStringMatchesAllowEmpty(parameters.NbecCode, x => x.NbecCode == parameters.NbecCode, x => x.NbecCode == null)
            .WhereStringMatchesAllowEmpty(parameters.SiteComponentCode, x => x.SiteComponentCode == parameters.SiteComponentCode, x => x.SiteComponentCode == null)
            .WhereStringMatchesAllowEmpty(
                parameters.RealmCode,
                x => x.SiteComponentCodeNavigation != null && x.SiteComponentCodeNavigation.RealmCode == parameters.RealmCode,
                x => x.SiteComponentCodeNavigation == null)
            .WhereStringMatchesAllowEmpty(
                parameters.GroupCode,
                x => x.SiteComponentCodeNavigation != null && x.SiteComponentCodeNavigation.GroupCode == parameters.GroupCode,
                x => x.SiteComponentCodeNavigation == null || x.SiteComponentCodeNavigation.GroupCode == null)
            .WhereStringMatchesAllowEmpty(
                parameters.ClassCode,
                x => x.SiteComponentCodeNavigation != null && x.SiteComponentCodeNavigation.ClassCode == parameters.ClassCode,
                x => x.SiteComponentCodeNavigation == null || x.SiteComponentCodeNavigation.ClassCode == null)
            .WhereStringMatchesAllowEmpty(
                parameters.AssociationCode,
                x => x.SiteComponentCodeNavigation != null && x.SiteComponentCodeNavigation.AssociationCode == parameters.AssociationCode,
                x => x.SiteComponentCodeNavigation == null || x.SiteComponentCodeNavigation.AssociationCode == null)
            .WhereStringMatchesAllowEmpty(
                parameters.SubclassCode,
                x => x.SiteComponentCodeNavigation != null && x.SiteComponentCodeNavigation.SubClassCode == parameters.SubclassCode,
                x => x.SiteComponentCodeNavigation == null || x.SiteComponentCodeNavigation.SubClassCode == null)
            .WhereStringMatchesAllowEmpty(parameters.EcosystemType, x => x.EcoSystemType == parameters.EcosystemType, x => x.EcoSystemType == null)
            .WhereStringMatchesAllowEmpty(parameters.EcosystemSubType, x => x.EcoSystemSubType == parameters.EcosystemSubType, x => x.EcoSystemSubType == null)
            .WhereStringMatchesAllowEmpty(parameters.KindType, x => x.KindType == parameters.KindType, x => x.KindType == null)
            .WhereStringMatchesAllowEmpty(parameters.SiteSeriesName, x => x.SiteSeriesName == parameters.SiteSeriesName, x => x.SiteSeriesName == null)
            .WhereIf(parameters.Forested != null, x => x.Forested == parameters.Forested)
            .WhereStringMatchesAllowEmpty(parameters.Source, x => x.Source == parameters.Source, x => x.Source == null)
            .WhereIf(parameters.Approved != null, x => x.Approved == parameters.Approved);

        return await query
            .OrderBy(x => x.BgcCode)
            .ThenBy(x => x.EcoCode)
            .ThenBy(x => x.SiteComponentCode ?? x.NbecCode)
            .ThenBy(x => x.Source)
            .ToListAsync(ct);
    }
}

public record BcgEcoCodeParameters
{
    public string? BgcCode { get; init; }
    public string? ZoneCode { get; init; }
    public string? SubzoneCode { get; init; }
    public string? VariantCode { get; init; }
    public string? PhaseCode { get; init; }
    public string? EcosystemCode { get; init; }
    public string? MapCode { get; init; }
    public string? SiteSeriesCode { get; init; }
    public string? SsPhaseCode { get; init; }
    public string? SeralCode { get; init; }
    public string? VariationCode { get; init; }
    public string? NbecCode { get; init; }
    public string? SiteComponentCode { get; init; }
    public string? RealmCode { get; init; }
    public string? GroupCode { get; init; }
    public string? ClassCode { get; init; }
    public string? AssociationCode { get; init; }
    public string? SubclassCode { get; init; }
    public string? EcosystemType { get; init; }
    public string? EcosystemSubType { get; init; }
    public string? KindType { get; init; }
    public string? SiteSeriesName { get; init; }
    public bool? Forested { get; init; }
    public string? Source { get; init; }
    public bool? Approved { get; init; }
}
