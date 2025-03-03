namespace TEI.Database.Data.Entities;

public partial class Sitemodifiercode
{
    public string SiteModifierCode { get; set; } = null!;

    public virtual ICollection<Ecocomponent> EcocomponentSiteModifierCode1Navigations { get; set; } = new List<Ecocomponent>();

    public virtual ICollection<Ecocomponent> EcocomponentSiteModifierCode2Navigations { get; set; } = new List<Ecocomponent>();
}
