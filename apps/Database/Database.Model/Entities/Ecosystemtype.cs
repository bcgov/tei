namespace TEI.Database.Model.Entities;

public partial class Ecosystemtype
{
    public string EcoSystemType { get; set; } = null!;

    public string Detail { get; set; } = null!;

    public virtual ICollection<Bgcecocode> Bgcecocodes { get; set; } = new List<Bgcecocode>();
}
