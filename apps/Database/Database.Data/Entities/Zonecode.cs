namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("zonecode", Schema = "codes")]
public partial class Zonecode
{
    [Key]
    [Column("zone_code")]
    [StringLength(4)]
    public string ZoneCode { get; set; } = null!;

    [InverseProperty("ZoneCodeNavigation")]
    public virtual ICollection<Bgccode> Bgccodes { get; set; } = new List<Bgccode>();

    [ForeignKey("ZoneCode")]
    [InverseProperty("ZoneCodes")]
    public virtual ICollection<Subzonecode> SubZoneCodes { get; set; } = new List<Subzonecode>();
}
