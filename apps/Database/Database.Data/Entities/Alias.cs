namespace TEI.Database.Data.Entities;

public partial class Alias
{
    public int AliasId { get; set; }

    public int ProjectBapid { get; set; }

    public string AliasName { get; set; } = null!;

    public bool Active { get; set; }

    public virtual Project ProjectBap { get; set; } = null!;
}
