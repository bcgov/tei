namespace TEI.Database.Model.Entities;

public partial class Associationcode
{
    public string AssociationCode { get; set; } = null!;

    public virtual ICollection<Sitecomponentcode> Sitecomponentcodes { get; set; } = new List<Sitecomponentcode>();
}
