namespace TEI.Database.Model.Entities;

public partial class Subclasscode
{
    public string SubClassCode { get; set; } = null!;

    public virtual ICollection<Sitecomponentcode> Sitecomponentcodes { get; set; } = new List<Sitecomponentcode>();

    public virtual ICollection<Classcode> ClassCodes { get; set; } = new List<Classcode>();
}
