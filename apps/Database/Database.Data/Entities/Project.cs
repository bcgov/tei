namespace TEI.Database.Data.Entities;

public partial class Project
{
    public int ProjectBapid { get; set; }

    public string ProjectType { get; set; } = null!;

    public string StatusCode { get; set; } = null!;

    public string FeatureCode { get; set; } = null!;

    public string ProjectName { get; set; } = null!;

    public string? ProjectCode { get; set; }

    public string? LocationDescription { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Description { get; set; }

    public decimal? EstimatedCost { get; set; }

    public bool BoundaryOnly { get; set; }

    public bool SensitiveData { get; set; }

    public bool Active { get; set; }

    public DateTime? CreatedDt { get; set; }

    public virtual ICollection<Alias> Aliases { get; set; } = new List<Alias>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Featurecode FeatureCodeNavigation { get; set; } = null!;

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();

    public virtual Legacyproject? Legacyproject { get; set; }

    public virtual ICollection<ProjectParty> ProjectParties { get; set; } = new List<ProjectParty>();

    public virtual Projecttype ProjectTypeNavigation { get; set; } = null!;

    public virtual ICollection<Projectrelation> ProjectrelationProjectBapid1Navigations { get; set; } = new List<Projectrelation>();

    public virtual ICollection<Projectrelation> ProjectrelationProjectBapid2Navigations { get; set; } = new List<Projectrelation>();

    public virtual Statuscode StatusCodeNavigation { get; set; } = null!;

    public virtual ICollection<Datagroup> DataGroups { get; set; } = new List<Datagroup>();

    public virtual ICollection<Ecoobject> EcoObjects { get; set; } = new List<Ecoobject>();
}
