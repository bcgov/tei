namespace TEI.Database.Model.Entities;

public partial class Partytype
{
    public string PartyType { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<Party> Parties { get; set; } = new List<Party>();
}
