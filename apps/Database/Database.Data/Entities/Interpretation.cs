namespace TEI.Database.Data.Entities;

public partial class Interpretation
{
    public int InterpretationId { get; set; }

    public string? InterpretationType { get; set; }

    public virtual ICollection<Geometry> Geometries { get; set; } = new List<Geometry>();

    public virtual Interpretationtype? InterpretationTypeNavigation { get; set; }

    public virtual ICollection<Tercomponent> Tercomponents { get; set; } = new List<Tercomponent>();
}
