namespace TEI.Database.Data.Entities;

public partial class Party
{
    public int PartyId { get; set; }

    public string PartyType { get; set; } = null!;

    public string PartyName { get; set; } = null!;

    public string? Description { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public bool Active { get; set; }

    public DateTime CreatedDt { get; set; }

    public virtual Partytype PartyTypeNavigation { get; set; } = null!;

    public virtual ICollection<ProjectParty> ProjectParties { get; set; } = new List<ProjectParty>();
}
