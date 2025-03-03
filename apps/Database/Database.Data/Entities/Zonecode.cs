namespace TEI.Database.Data.Entities;

public partial class Zonecode
{
    public string ZoneCode { get; set; } = null!;

    public string Detail { get; set; } = null!;

    public virtual ICollection<Bgccode> Bgccodes { get; set; } = new List<Bgccode>();

    public virtual ICollection<Subzonecode> SubZoneCodes { get; set; } = new List<Subzonecode>();
}
