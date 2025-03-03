namespace TEI.Database.Data.Entities;

public partial class Legacyproject
{
    public int ProjectBapid { get; set; }

    public string? Esil { get; set; }

    public string? Tsil { get; set; }

    public string? MapshLst { get; set; }

    public string? TrimNbr { get; set; }

    public string? PhotoType { get; set; }

    public string? PhotoSc { get; set; }

    public string? PhotoYr { get; set; }

    public string? TerLegSc { get; set; }

    public string? TerLegTp { get; set; }

    public string? PackNbr { get; set; }

    public string? StbclsTp { get; set; }

    public string? SlpUnit { get; set; }

    public string? TrsApprovalCondition { get; set; }

    public string? AaLevel { get; set; }

    public string? AaComment { get; set; }

    public virtual Project ProjectBap { get; set; } = null!;
}
