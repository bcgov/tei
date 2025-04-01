namespace TEI.Database.Model.Entities;

public partial class Issue
{
    public int IssueId { get; set; }

    public int ProjectBapid { get; set; }

    public string IssueDescription { get; set; } = null!;

    public DateTime RecordedDt { get; set; }

    public string? RecordedBy { get; set; }

    public DateTime? ResolvedDt { get; set; }

    public string? ResolvedBy { get; set; }

    public string? ResolutionNotes { get; set; }

    public virtual Project ProjectBap { get; set; } = null!;
}
