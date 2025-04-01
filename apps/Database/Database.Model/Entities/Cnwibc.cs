namespace TEI.Database.Model.Entities;

public partial class Cnwibc
{
    public string CnwiBcCode { get; set; } = null!;

    public string? CnwiCode { get; set; }

    public virtual ICollection<Geometry> Geometries { get; set; } = new List<Geometry>();

    public virtual ICollection<Bgcecocode> BgcEcocodes { get; set; } = new List<Bgcecocode>();
}
