namespace TEI.Database.Model.Entities;

public partial class Groupcode
{
    public string GroupCode { get; set; } = null!;

    public string RealmCode { get; set; } = null!;

    public string Detail { get; set; } = null!;

    public virtual ICollection<GroupcodeClasscode> GroupcodeClasscodes { get; set; } = new List<GroupcodeClasscode>();

    public virtual Realmcode RealmCodeNavigation { get; set; } = null!;

    public virtual ICollection<Sitecomponentcode> Sitecomponentcodes { get; set; } = new List<Sitecomponentcode>();
}
