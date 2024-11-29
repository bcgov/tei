namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("bgccode", Schema = "codes")]
public partial class Bgccode
{
    [Key]
    [Column("bgc_code")]
    [StringLength(10)]
    public string BgcCode { get; set; } = null!;

    [Column("zone_code")]
    [StringLength(4)]
    public string ZoneCode { get; set; } = null!;

    [Column("sub_zone_code")]
    [StringLength(3)]
    public string SubZoneCode { get; set; } = null!;

    [Column("variant_code")]
    [StringLength(1)]
    public string? VariantCode { get; set; }

    [Column("phase_code")]
    [StringLength(1)]
    public string? PhaseCode { get; set; }

    [InverseProperty("BgcCodeNavigation")]
    public virtual ICollection<Bgcecocode> Bgcecocodes { get; set; } = new List<Bgcecocode>();

    [ForeignKey("PhaseCode")]
    [InverseProperty("Bgccodes")]
    public virtual Phasecode? PhaseCodeNavigation { get; set; }

    [ForeignKey("SubZoneCode")]
    [InverseProperty("Bgccodes")]
    public virtual Subzonecode SubZoneCodeNavigation { get; set; } = null!;

    [ForeignKey("VariantCode")]
    [InverseProperty("Bgccodes")]
    public virtual Variantcode? VariantCodeNavigation { get; set; }

    [ForeignKey("ZoneCode")]
    [InverseProperty("Bgccodes")]
    public virtual Zonecode ZoneCodeNavigation { get; set; } = null!;
}
