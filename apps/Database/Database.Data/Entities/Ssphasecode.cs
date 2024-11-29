namespace TEI.Database.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ssphasecode", Schema = "codes")]
public partial class Ssphasecode
{
    [Key]
    [Column("ss_phase_code")]
    [StringLength(1)]
    public string SsPhaseCode { get; set; } = null!;

    [InverseProperty("SsPhaseCodeNavigation")]
    public virtual ICollection<Ecocode> Ecocodes { get; set; } = new List<Ecocode>();
}
