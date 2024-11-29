namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("nbeccode", Schema = "codes")]
public partial class Nbeccode
{
    [Key]
    [Column("nbec_code")]
    [StringLength(6)]
    public string NbecCode { get; set; } = null!;

    [InverseProperty("NbecCodeNavigation")]
    public virtual ICollection<Bgcecocode> Bgcecocodes { get; set; } = new List<Bgcecocode>();

    [InverseProperty("NbecCodeNavigation")]
    public virtual ICollection<Sitecomponentcode> Sitecomponentcodes { get; set; } = new List<Sitecomponentcode>();
}
