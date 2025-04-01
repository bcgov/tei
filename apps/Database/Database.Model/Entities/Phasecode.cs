namespace TEI.Database.Model.Entities;

public partial class Phasecode
{
    public string PhaseCode { get; set; } = null!;

    public virtual ICollection<Bgccode> Bgccodes { get; set; } = new List<Bgccode>();

    public virtual ICollection<Subzonecode> SubZoneCodes { get; set; } = new List<Subzonecode>();

    public virtual ICollection<Variantcode> VariantCodes { get; set; } = new List<Variantcode>();
}
