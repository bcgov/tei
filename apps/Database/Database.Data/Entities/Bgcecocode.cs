namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("bgcecocode", Schema = "codes")]
public partial class Bgcecocode
{
    [Key]
    [Column("bgc_ecocode_id")]
    public int BgcEcocodeId { get; set; }

    [Column("bgc_code")]
    [StringLength(10)]
    public string BgcCode { get; set; } = null!;

    [Column("eco_code")]
    [StringLength(10)]
    public string EcoCode { get; set; } = null!;

    [Column("nbec_code")]
    [StringLength(6)]
    public string? NbecCode { get; set; }

    [Column("site_component_code")]
    [StringLength(8)]
    public string? SiteComponentCode { get; set; }

    [Column("eco_system_type")]
    [StringLength(2)]
    public string? EcoSystemType { get; set; }

    [Column("eco_system_sub_type")]
    [StringLength(2)]
    public string? EcoSystemSubType { get; set; }

    [Column("kind_type")]
    [StringLength(1)]
    public string? KindType { get; set; }

    [Column("site_series_name")]
    [StringLength(80)]
    public string? SiteSeriesName { get; set; }

    [Column("forested")]
    public bool Forested { get; set; }

    [Column("source")]
    [StringLength(40)]
    public string? Source { get; set; }

    [Column("date_added")]
    public DateOnly? DateAdded { get; set; }

    [Column("approved")]
    public bool Approved { get; set; }

    [ForeignKey("BgcCode")]
    [InverseProperty("Bgcecocodes")]
    public virtual Bgccode BgcCodeNavigation { get; set; } = null!;

    [ForeignKey("EcoCode")]
    [InverseProperty("Bgcecocodes")]
    public virtual Ecocode EcoCodeNavigation { get; set; } = null!;

    [ForeignKey("EcoSystemSubType")]
    [InverseProperty("Bgcecocodes")]
    public virtual Ecosystemsubtype? EcoSystemSubTypeNavigation { get; set; }

    [ForeignKey("EcoSystemType")]
    [InverseProperty("Bgcecocodes")]
    public virtual Ecosystemtype? EcoSystemTypeNavigation { get; set; }

    [ForeignKey("KindType")]
    [InverseProperty("Bgcecocodes")]
    public virtual Kindtype? KindTypeNavigation { get; set; }

    [ForeignKey("NbecCode")]
    [InverseProperty("Bgcecocodes")]
    public virtual Nbeccode? NbecCodeNavigation { get; set; }

    [ForeignKey("SiteComponentCode")]
    [InverseProperty("Bgcecocodes")]
    public virtual Sitecomponentcode? SiteComponentCodeNavigation { get; set; }
}
