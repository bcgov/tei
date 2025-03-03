namespace TEI.Database.Data.Entities;

public partial class Ecocomponent
{
    public int EcoComponentId { get; set; }

    public int PolygonId { get; set; }

    public int? BgcEcocodeId { get; set; }

    public string? SiteModifierCode1 { get; set; }

    public string? SiteModifierCode2 { get; set; }

    public int? Num { get; set; }

    public int? Decile { get; set; }

    public virtual Bgcecocode? BgcEcocode { get; set; }

    public virtual Geopolygon Polygon { get; set; } = null!;

    public virtual Sitemodifiercode? SiteModifierCode1Navigation { get; set; }

    public virtual Sitemodifiercode? SiteModifierCode2Navigation { get; set; }
}
