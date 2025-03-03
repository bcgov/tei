namespace TEI.Database.Data.Entities;

public partial class Ssphasecode
{
    public string SsPhaseCode { get; set; } = null!;

    public virtual ICollection<Ecocode> Ecocodes { get; set; } = new List<Ecocode>();
}
