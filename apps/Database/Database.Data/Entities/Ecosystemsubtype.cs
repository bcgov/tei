namespace TEI.Database.Data.Entities;

public partial class Ecosystemsubtype
{
    public string EcoSystemSubType { get; set; } = null!;

    public string Detail { get; set; } = null!;

    public virtual ICollection<Bgcecocode> Bgcecocodes { get; set; } = new List<Bgcecocode>();
}
