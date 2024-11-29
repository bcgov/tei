namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ecosystemtype", Schema = "codes")]
public partial class Ecosystemtype
{
    [Key]
    [Column("eco_system_type")]
    [StringLength(2)]
    public string EcoSystemType { get; set; } = null!;

    [Column("detail")]
    [StringLength(40)]
    public string Detail { get; set; } = null!;

    [InverseProperty("EcoSystemTypeNavigation")]
    public virtual ICollection<Bgcecocode> Bgcecocodes { get; set; } = new List<Bgcecocode>();
}
