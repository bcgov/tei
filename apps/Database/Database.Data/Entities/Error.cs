namespace TEI.Database.Data.Entities;

public partial class Error
{
    public int ErrorId { get; set; }

    public int GeometryId { get; set; }

    public virtual Geometry Geometry { get; set; } = null!;
}
