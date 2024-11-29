namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("siteseriescode", Schema = "codes")]
public partial class Siteseriescode
{
    [Key]
    [Column("site_series_code")]
    [StringLength(4)]
    public string SiteSeriesCode { get; set; } = null!;

    [InverseProperty("SiteSeriesCodeNavigation")]
    public virtual ICollection<Ecocode> Ecocodes { get; set; } = new List<Ecocode>();
}
