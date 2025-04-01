namespace TEI.Database.Model.Entities;

public partial class Sitecomponentcode
{
    public string SiteComponentCode { get; set; } = null!;

    public string RealmCode { get; set; } = null!;

    public string? GroupCode { get; set; }

    public string? ClassCode { get; set; }

    public string? AssociationCode { get; set; }

    public string? SubClassCode { get; set; }

    public string? NbecCode { get; set; }

    public virtual Associationcode? AssociationCodeNavigation { get; set; }

    public virtual ICollection<Bgcecocode> Bgcecocodes { get; set; } = new List<Bgcecocode>();

    public virtual Classcode? ClassCodeNavigation { get; set; }

    public virtual Groupcode? GroupCodeNavigation { get; set; }

    public virtual Nbeccode? NbecCodeNavigation { get; set; }

    public virtual Realmcode RealmCodeNavigation { get; set; } = null!;

    public virtual Subclasscode? SubClassCodeNavigation { get; set; }
}
