namespace TEI.Database.Model.Entities;

public partial class Statuscode
{
    public string StatusCode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Comment { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
