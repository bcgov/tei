namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ecosystemsubtype", Schema = "codes")]
public partial class Ecosystemsubtype
{
    [Key]
    [Column("eco_system_sub_type")]
    [StringLength(2)]
    public string EcoSystemSubType { get; set; } = null!;

    [Column("detail")]
    [StringLength(40)]
    public string Detail { get; set; } = null!;

    [InverseProperty("EcoSystemSubTypeNavigation")]
    public virtual ICollection<Bgcecocode> Bgcecocodes { get; set; } = new List<Bgcecocode>();
}
