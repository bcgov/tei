namespace TEI.Database.Data.Entities;

public partial class Featurecode
{
    public string FeatureCode { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public string? Description { get; set; }

    public string? Attribute { get; set; }

    public string? Remark { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Geometry> Geometries { get; set; } = new List<Geometry>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
