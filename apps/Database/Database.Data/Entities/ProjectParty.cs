namespace TEI.Database.Data.Entities;

public partial class ProjectParty
{
    public int ProjectBapid { get; set; }

    public int PartyId { get; set; }

    public bool AssociateOrg { get; set; }

    public bool ProjSup { get; set; }

    public bool EcoMap { get; set; }

    public bool TerMap { get; set; }

    public bool SoilMap { get; set; }

    public bool WildMap { get; set; }

    public bool DigCap { get; set; }

    public bool GisSup { get; set; }

    public bool RecName { get; set; }

    public bool Client { get; set; }

    public bool LeadProp { get; set; }

    public bool FundingSrc { get; set; }

    public bool Contact { get; set; }

    public virtual Party Party { get; set; } = null!;

    public virtual Project ProjectBap { get; set; } = null!;
}
