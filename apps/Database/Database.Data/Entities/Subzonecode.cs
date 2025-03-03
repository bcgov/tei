namespace TEI.Database.Data.Entities;

public partial class Subzonecode
{
    public string SubZoneCode { get; set; } = null!;

    public virtual ICollection<Bgccode> Bgccodes { get; set; } = new List<Bgccode>();

    public virtual ICollection<Phasecode> PhaseCodes { get; set; } = new List<Phasecode>();

    public virtual ICollection<Variantcode> VariantCodes { get; set; } = new List<Variantcode>();

    public virtual ICollection<Zonecode> ZoneCodes { get; set; } = new List<Zonecode>();
}
