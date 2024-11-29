namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("subzonecode", Schema = "codes")]
public partial class Subzonecode
{
    [Key]
    [Column("sub_zone_code")]
    [StringLength(3)]
    public string SubZoneCode { get; set; } = null!;

    [InverseProperty("SubZoneCodeNavigation")]
    public virtual ICollection<Bgccode> Bgccodes { get; set; } = new List<Bgccode>();

    [ForeignKey("SubZoneCode")]
    [InverseProperty("SubZoneCodes")]
    public virtual ICollection<Phasecode> PhaseCodes { get; set; } = new List<Phasecode>();

    [ForeignKey("SubZoneCode")]
    [InverseProperty("SubZoneCodes")]
    public virtual ICollection<Variantcode> VariantCodes { get; set; } = new List<Variantcode>();

    [ForeignKey("SubZoneCode")]
    [InverseProperty("SubZoneCodes")]
    public virtual ICollection<Zonecode> ZoneCodes { get; set; } = new List<Zonecode>();
}
