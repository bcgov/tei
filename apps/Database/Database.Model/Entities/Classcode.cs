namespace TEI.Database.Model.Entities;

public partial class Classcode
{
    public string ClassCode { get; set; } = null!;

    public virtual ICollection<GroupcodeClasscode> GroupcodeClasscodes { get; set; } = new List<GroupcodeClasscode>();

    public virtual ICollection<Sitecomponentcode> Sitecomponentcodes { get; set; } = new List<Sitecomponentcode>();

    public virtual ICollection<Subclasscode> SubClassCodes { get; set; } = new List<Subclasscode>();
}
