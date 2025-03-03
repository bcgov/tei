namespace TEI.Database.Data.Entities;

public partial class GroupcodeClasscode
{
    public string GroupCode { get; set; } = null!;

    public string ClassCode { get; set; } = null!;

    public string Detail { get; set; } = null!;

    public virtual Classcode ClassCodeNavigation { get; set; } = null!;

    public virtual Groupcode GroupCodeNavigation { get; set; } = null!;
}
