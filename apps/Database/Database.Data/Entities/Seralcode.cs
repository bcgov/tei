namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("seralcode", Schema = "codes")]
public partial class Seralcode
{
    [Key]
    [Column("seral_code")]
    [StringLength(6)]
    public string SeralCode { get; set; } = null!;

    [InverseProperty("SeralCodeNavigation")]
    public virtual ICollection<Ecocode> Ecocodes { get; set; } = new List<Ecocode>();
}
