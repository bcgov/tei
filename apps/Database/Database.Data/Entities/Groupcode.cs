namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("groupcode", Schema = "codes")]
public partial class Groupcode
{
    [Key]
    [Column("group_code")]
    [StringLength(1)]
    public string GroupCode { get; set; } = null!;

    [Column("realm_code")]
    [StringLength(1)]
    public string RealmCode { get; set; } = null!;

    [ForeignKey("RealmCode")]
    [InverseProperty("Groupcodes")]
    public virtual Realmcode RealmCodeNavigation { get; set; } = null!;

    [InverseProperty("GroupCodeNavigation")]
    public virtual ICollection<Sitecomponentcode> Sitecomponentcodes { get; set; } = new List<Sitecomponentcode>();

    [ForeignKey("GroupCode")]
    [InverseProperty("GroupCodes")]
    public virtual ICollection<Classcode> ClassCodes { get; set; } = new List<Classcode>();
}
