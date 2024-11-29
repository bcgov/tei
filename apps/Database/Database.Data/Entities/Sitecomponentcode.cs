namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("sitecomponentcode", Schema = "codes")]
public partial class Sitecomponentcode
{
    [Key]
    [Column("site_component_code")]
    [StringLength(8)]
    public string SiteComponentCode { get; set; } = null!;

    [Column("realm_code")]
    [StringLength(1)]
    public string RealmCode { get; set; } = null!;

    [Column("group_code")]
    [StringLength(1)]
    public string? GroupCode { get; set; }

    [Column("class_code")]
    [StringLength(1)]
    public string? ClassCode { get; set; }

    [Column("association_code")]
    [StringLength(2)]
    public string? AssociationCode { get; set; }

    [Column("sub_class_code")]
    [StringLength(1)]
    public string? SubClassCode { get; set; }

    [Column("nbec_code")]
    [StringLength(6)]
    public string? NbecCode { get; set; }

    [ForeignKey("AssociationCode")]
    [InverseProperty("Sitecomponentcodes")]
    public virtual Associationcode? AssociationCodeNavigation { get; set; }

    [InverseProperty("SiteComponentCodeNavigation")]
    public virtual ICollection<Bgcecocode> Bgcecocodes { get; set; } = new List<Bgcecocode>();

    [ForeignKey("ClassCode")]
    [InverseProperty("Sitecomponentcodes")]
    public virtual Classcode? ClassCodeNavigation { get; set; }

    [ForeignKey("GroupCode")]
    [InverseProperty("Sitecomponentcodes")]
    public virtual Groupcode? GroupCodeNavigation { get; set; }

    [ForeignKey("NbecCode")]
    [InverseProperty("Sitecomponentcodes")]
    public virtual Nbeccode? NbecCodeNavigation { get; set; }

    [ForeignKey("RealmCode")]
    [InverseProperty("Sitecomponentcodes")]
    public virtual Realmcode RealmCodeNavigation { get; set; } = null!;

    [ForeignKey("SubClassCode")]
    [InverseProperty("Sitecomponentcodes")]
    public virtual Subclasscode? SubClassCodeNavigation { get; set; }
}
