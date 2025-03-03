namespace TEI.Database.Data.Entities;

public partial class Ecoobject
{
    public int EcoObjectId { get; set; }

    public string? BgcCode { get; set; }

    public virtual Bgccode? BgcCodeNavigation { get; set; }

    public virtual ICollection<Geometry> Geometries { get; set; } = new List<Geometry>();

    public virtual ICollection<Project> ProjectBaps { get; set; } = new List<Project>();
}
