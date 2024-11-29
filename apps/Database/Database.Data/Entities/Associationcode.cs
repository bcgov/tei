namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("associationcode", Schema = "codes")]
public partial class Associationcode
{
    [Key]
    [Column("association_code")]
    [StringLength(2)]
    public string AssociationCode { get; set; } = null!;

    [InverseProperty("AssociationCodeNavigation")]
    public virtual ICollection<Sitecomponentcode> Sitecomponentcodes { get; set; } = new List<Sitecomponentcode>();
}
