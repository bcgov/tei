namespace TEI.Database.Model.Entities;

public partial class Variantcode
{
    public string VariantCode { get; set; } = null!;

    public virtual ICollection<Bgccode> Bgccodes { get; set; } = new List<Bgccode>();

    public virtual ICollection<Phasecode> PhaseCodes { get; set; } = new List<Phasecode>();

    public virtual ICollection<Subzonecode> SubZoneCodes { get; set; } = new List<Subzonecode>();
}
