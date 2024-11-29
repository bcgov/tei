namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("subclasscode", Schema = "codes")]
public partial class Subclasscode
{
    [Key]
    [Column("sub_class_code")]
    [StringLength(1)]
    public string SubClassCode { get; set; } = null!;

    [InverseProperty("SubClassCodeNavigation")]
    public virtual ICollection<Sitecomponentcode> Sitecomponentcodes { get; set; } = new List<Sitecomponentcode>();

    [ForeignKey("SubClassCode")]
    [InverseProperty("SubClassCodes")]
    public virtual ICollection<Classcode> ClassCodes { get; set; } = new List<Classcode>();
}
