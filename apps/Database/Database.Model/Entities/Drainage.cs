namespace TEI.Database.Model.Entities;

public partial class Drainage
{
    public int DrainageId { get; set; }

    public virtual ICollection<Geometry> Geometries { get; set; } = new List<Geometry>();

    public virtual ICollection<Tercomponent> Tercomponents { get; set; } = new List<Tercomponent>();
}
