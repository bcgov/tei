namespace TEI.Database.Data.Entities;

public partial class Image
{
    public int ImageId { get; set; }

    public virtual ICollection<Geometry> Geometries { get; set; } = new List<Geometry>();
}
