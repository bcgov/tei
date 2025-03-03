namespace TEI.Database.Data.Entities;

public partial class Bedrocktype
{
    public string BedrockType { get; set; } = null!;

    public virtual ICollection<Tercomponent> Tercomponents { get; set; } = new List<Tercomponent>();
}
