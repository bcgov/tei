namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("variantcode", Schema = "codes")]
public partial class Variantcode
{
    [Key]
    [Column("variant_code")]
    [StringLength(1)]
    public string VariantCode { get; set; } = null!;

    [InverseProperty("VariantCodeNavigation")]
    public virtual ICollection<Bgccode> Bgccodes { get; set; } = new List<Bgccode>();

    [ForeignKey("VariantCode")]
    [InverseProperty("VariantCodes")]
    public virtual ICollection<Phasecode> PhaseCodes { get; set; } = new List<Phasecode>();

    [ForeignKey("VariantCode")]
    [InverseProperty("VariantCodes")]
    public virtual ICollection<Subzonecode> SubZoneCodes { get; set; } = new List<Subzonecode>();
}
