namespace TEI.Database.Model.Entities;

public partial class Flag
{
    public string FlagId { get; set; } = null!;

    public virtual ICollection<Geometry> Geometries { get; set; } = new List<Geometry>();
}
