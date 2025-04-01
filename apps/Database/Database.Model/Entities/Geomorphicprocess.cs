namespace TEI.Database.Model.Entities;

public partial class Geomorphicprocess
{
    public int GeoMorphicProcessId { get; set; }

    public bool ActivityDefault { get; set; }

    public virtual ICollection<GeometryGeomorphicprocess> GeometryGeomorphicprocesses { get; set; } = new List<GeometryGeomorphicprocess>();
}
