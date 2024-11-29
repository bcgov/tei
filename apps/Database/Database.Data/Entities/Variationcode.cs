namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("variationcode", Schema = "codes")]
public partial class Variationcode
{
    [Key]
    [Column("variation_code")]
    [StringLength(1)]
    public string VariationCode { get; set; } = null!;

    [InverseProperty("VariationCodeNavigation")]
    public virtual ICollection<Ecocode> Ecocodes { get; set; } = new List<Ecocode>();
}
