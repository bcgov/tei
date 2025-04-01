namespace TEI.Database.Model.Entities;

public partial class Methodologycode
{
    public string MethodologyCode { get; set; } = null!;

    public virtual ICollection<Geometry> Geometries { get; set; } = new List<Geometry>();
}
