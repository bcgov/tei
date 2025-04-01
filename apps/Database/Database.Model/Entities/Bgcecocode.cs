namespace TEI.Database.Model.Entities;

public partial class Bgcecocode
{
    public int BgcEcocodeId { get; set; }

    public string BgcCode { get; set; } = null!;

    public string EcoCode { get; set; } = null!;

    public string? NbecCode { get; set; }

    public string? SiteComponentCode { get; set; }

    public string? EcoSystemType { get; set; }

    public string? EcoSystemSubType { get; set; }

    public string? KindType { get; set; }

    public string? SiteSeriesName { get; set; }

    public bool Forested { get; set; }

    public string? Source { get; set; }

    public DateOnly? DateAdded { get; set; }

    public bool Approved { get; set; }

    public virtual Bgccode BgcCodeNavigation { get; set; } = null!;

    public virtual Ecocode EcoCodeNavigation { get; set; } = null!;

    public virtual Ecosystemsubtype? EcoSystemSubTypeNavigation { get; set; }

    public virtual Ecosystemtype? EcoSystemTypeNavigation { get; set; }

    public virtual ICollection<Ecocomponent> Ecocomponents { get; set; } = new List<Ecocomponent>();

    public virtual ICollection<Geopoint> Geopoints { get; set; } = new List<Geopoint>();

    public virtual Kindtype? KindTypeNavigation { get; set; }

    public virtual Nbeccode? NbecCodeNavigation { get; set; }

    public virtual Sitecomponentcode? SiteComponentCodeNavigation { get; set; }

    public virtual ICollection<Cnwibc> CnwiBcCodes { get; set; } = new List<Cnwibc>();
}
