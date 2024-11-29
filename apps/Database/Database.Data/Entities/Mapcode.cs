namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("mapcode", Schema = "codes")]
public partial class Mapcode
{
    [Key]
    [Column("map_code")]
    [StringLength(2)]
    public string MapCode { get; set; } = null!;

    [InverseProperty("MapCodeNavigation")]
    public virtual ICollection<Ecocode> Ecocodes { get; set; } = new List<Ecocode>();
}
