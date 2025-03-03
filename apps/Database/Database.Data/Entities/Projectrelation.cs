namespace TEI.Database.Data.Entities;

public partial class Projectrelation
{
    public int ProjectBapid1 { get; set; }

    public int ProjectBapid2 { get; set; }

    public int RelationDescriptionId { get; set; }

    public virtual Project ProjectBapid1Navigation { get; set; } = null!;

    public virtual Project ProjectBapid2Navigation { get; set; } = null!;

    public virtual Relationdescription RelationDescription { get; set; } = null!;
}
