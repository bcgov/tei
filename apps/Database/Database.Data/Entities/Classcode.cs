namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("classcode", Schema = "codes")]
public partial class Classcode
{
    [Key]
    [Column("class_code")]
    [StringLength(1)]
    public string ClassCode { get; set; } = null!;

    [InverseProperty("ClassCodeNavigation")]
    public virtual ICollection<Sitecomponentcode> Sitecomponentcodes { get; set; } = new List<Sitecomponentcode>();

    [ForeignKey("ClassCode")]
    [InverseProperty("ClassCodes")]
    public virtual ICollection<Groupcode> GroupCodes { get; set; } = new List<Groupcode>();

    [ForeignKey("ClassCode")]
    [InverseProperty("ClassCodes")]
    public virtual ICollection<Subclasscode> SubClassCodes { get; set; } = new List<Subclasscode>();
}
