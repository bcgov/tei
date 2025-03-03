namespace TEI.Database.Data.Entities;

public partial class GeometryGeomorphicprocess
{
    public int GeometryId { get; set; }

    public int GeoMorphicProcessId { get; set; }

    public bool? Active { get; set; }

    public virtual Geomorphicprocess GeoMorphicProcess { get; set; } = null!;

    public virtual Geometry Geometry { get; set; } = null!;
}
