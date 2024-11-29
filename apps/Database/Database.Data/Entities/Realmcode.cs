namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("realmcode", Schema = "codes")]
public partial class Realmcode
{
    [Key]
    [Column("realm_code")]
    [StringLength(1)]
    public string RealmCode { get; set; } = null!;

    [InverseProperty("RealmCodeNavigation")]
    public virtual ICollection<Groupcode> Groupcodes { get; set; } = new List<Groupcode>();

    [InverseProperty("RealmCodeNavigation")]
    public virtual ICollection<Sitecomponentcode> Sitecomponentcodes { get; set; } = new List<Sitecomponentcode>();
}
