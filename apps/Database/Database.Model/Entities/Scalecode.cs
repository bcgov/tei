namespace TEI.Database.Model.Entities;

public partial class Scalecode
{
    public short ScaleCode { get; set; }

    public string Description { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<Geometry> Geometries { get; set; } = new List<Geometry>();
}
