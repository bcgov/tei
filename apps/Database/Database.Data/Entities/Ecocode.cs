namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ecocode", Schema = "codes")]
public partial class Ecocode
{
    [Key]
    [Column("eco_code")]
    [StringLength(10)]
    public string EcoCode { get; set; } = null!;

    [Column("map_code")]
    [StringLength(2)]
    public string? MapCode { get; set; }

    [Column("site_series_code")]
    [StringLength(4)]
    public string? SiteSeriesCode { get; set; }

    [Column("ss_phase_code")]
    [StringLength(1)]
    public string? SsPhaseCode { get; set; }

    [Column("seral_code")]
    [StringLength(6)]
    public string? SeralCode { get; set; }

    [Column("variation_code")]
    [StringLength(1)]
    public string? VariationCode { get; set; }

    [InverseProperty("EcoCodeNavigation")]
    public virtual ICollection<Bgcecocode> Bgcecocodes { get; set; } = new List<Bgcecocode>();

    [ForeignKey("MapCode")]
    [InverseProperty("Ecocodes")]
    public virtual Mapcode? MapCodeNavigation { get; set; }

    [ForeignKey("SeralCode")]
    [InverseProperty("Ecocodes")]
    public virtual Seralcode? SeralCodeNavigation { get; set; }

    [ForeignKey("SiteSeriesCode")]
    [InverseProperty("Ecocodes")]
    public virtual Siteseriescode? SiteSeriesCodeNavigation { get; set; }

    [ForeignKey("SsPhaseCode")]
    [InverseProperty("Ecocodes")]
    public virtual Ssphasecode? SsPhaseCodeNavigation { get; set; }

    [ForeignKey("VariationCode")]
    [InverseProperty("Ecocodes")]
    public virtual Variationcode? VariationCodeNavigation { get; set; }
}
