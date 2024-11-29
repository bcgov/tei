namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("phasecode", Schema = "codes")]
public partial class Phasecode
{
    [Key]
    [Column("phase_code")]
    [StringLength(1)]
    public string PhaseCode { get; set; } = null!;

    [InverseProperty("PhaseCodeNavigation")]
    public virtual ICollection<Bgccode> Bgccodes { get; set; } = new List<Bgccode>();

    [ForeignKey("PhaseCode")]
    [InverseProperty("PhaseCodes")]
    public virtual ICollection<Subzonecode> SubZoneCodes { get; set; } = new List<Subzonecode>();

    [ForeignKey("PhaseCode")]
    [InverseProperty("PhaseCodes")]
    public virtual ICollection<Variantcode> VariantCodes { get; set; } = new List<Variantcode>();
}
