namespace TEI.Database.Model.Entities;

public partial class Mapcode
{
    public string MapCode { get; set; } = null!;

    public string Detail { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Ecocode> Ecocodes { get; set; } = new List<Ecocode>();
}
