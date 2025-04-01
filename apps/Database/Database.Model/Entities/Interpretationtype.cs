namespace TEI.Database.Model.Entities;

public partial class Interpretationtype
{
    public string InterpretationType { get; set; } = null!;

    public virtual ICollection<Interpretation> Interpretations { get; set; } = new List<Interpretation>();
}
