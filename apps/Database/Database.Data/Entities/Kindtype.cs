namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("kindtype", Schema = "codes")]
public partial class Kindtype
{
    [Key]
    [Column("kind_type")]
    [StringLength(1)]
    public string KindType { get; set; } = null!;

    [Column("detail")]
    [StringLength(40)]
    public string Detail { get; set; } = null!;

    [InverseProperty("KindTypeNavigation")]
    public virtual ICollection<Bgcecocode> Bgcecocodes { get; set; } = new List<Bgcecocode>();
}
