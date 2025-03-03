namespace TEI.Database.Data.Entities;

public partial class Nbeccode
{
    public string NbecCode { get; set; } = null!;

    public virtual ICollection<Bgcecocode> Bgcecocodes { get; set; } = new List<Bgcecocode>();

    public virtual ICollection<Sitecomponentcode> Sitecomponentcodes { get; set; } = new List<Sitecomponentcode>();
}
