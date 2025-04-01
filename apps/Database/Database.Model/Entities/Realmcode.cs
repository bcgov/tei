namespace TEI.Database.Model.Entities;

public partial class Realmcode
{
    public string RealmCode { get; set; } = null!;

    public string Detail { get; set; } = null!;

    public virtual ICollection<Groupcode> Groupcodes { get; set; } = new List<Groupcode>();

    public virtual ICollection<Sitecomponentcode> Sitecomponentcodes { get; set; } = new List<Sitecomponentcode>();
}
