namespace TEI.Database.Model.Entities;

public partial class Bgccode
{
    public string BgcCode { get; set; } = null!;

    public string ZoneCode { get; set; } = null!;

    public string SubZoneCode { get; set; } = null!;

    public string? VariantCode { get; set; }

    public string? PhaseCode { get; set; }

    public string Detail { get; set; } = null!;

    public virtual ICollection<Bgcecocode> Bgcecocodes { get; set; } = new List<Bgcecocode>();

    public virtual ICollection<Ecoobject> Ecoobjects { get; set; } = new List<Ecoobject>();

    public virtual Phasecode? PhaseCodeNavigation { get; set; }

    public virtual Subzonecode SubZoneCodeNavigation { get; set; } = null!;

    public virtual Variantcode? VariantCodeNavigation { get; set; }

    public virtual Zonecode ZoneCodeNavigation { get; set; } = null!;
}
