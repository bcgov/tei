namespace TEI.Database.Model.Entities;

public partial class Relationdescription
{
    public int RelationDescriptionId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Projectrelation> Projectrelations { get; set; } = new List<Projectrelation>();
}
