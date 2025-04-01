namespace TEI.Database.Model.Entities;

public partial class Projectclass
{
    public string ProjectClass { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<Projecttype> Projecttypes { get; set; } = new List<Projecttype>();
}
