namespace TEI.Database.Model.Entities;

public partial class Geometrytype
{
    public string GeometryType { get; set; } = null!;

    public virtual ICollection<Geometry> Geometries { get; set; } = new List<Geometry>();
}
