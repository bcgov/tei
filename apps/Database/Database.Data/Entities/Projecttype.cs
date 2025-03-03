namespace TEI.Database.Data.Entities;

public partial class Projecttype
{
    public string ProjectType { get; set; } = null!;

    public string? ProjectClass { get; set; }

    public string? PrimaryType { get; set; }

    public string? SubType { get; set; }

    public string? ShortName { get; set; }

    public string Description { get; set; } = null!;

    public string? Notes { get; set; }

    public bool Active { get; set; }

    public virtual Projectclass? ProjectClassNavigation { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
