namespace TEI.Database.Model.Entities;

public partial class Ecocode
{
    public string EcoCode { get; set; } = null!;

    public string? MapCode { get; set; }

    public string? SiteSeriesCode { get; set; }

    public string? SsPhaseCode { get; set; }

    public string? SeralCode { get; set; }

    public string? VariationCode { get; set; }

    public virtual ICollection<Bgcecocode> Bgcecocodes { get; set; } = new List<Bgcecocode>();

    public virtual Mapcode? MapCodeNavigation { get; set; }

    public virtual Seralcode? SeralCodeNavigation { get; set; }

    public virtual Siteseriescode? SiteSeriesCodeNavigation { get; set; }

    public virtual Ssphasecode? SsPhaseCodeNavigation { get; set; }

    public virtual Variationcode? VariationCodeNavigation { get; set; }
}
