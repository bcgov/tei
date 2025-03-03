namespace TEI.Database.Data.Entities;

public partial class Tercomponent
{
    public int TerComponentId { get; set; }

    public int PolygonId { get; set; }

    public int? DrainageId { get; set; }

    public int? InterpretationId { get; set; }

    public string? BedrockType { get; set; }

    public short? Decile { get; set; }

    public bool? NotMapped { get; set; }

    public bool? IceCovered { get; set; }

    public virtual Bedrocktype? BedrockTypeNavigation { get; set; }

    public virtual Drainage? Drainage { get; set; }

    public virtual Interpretation? Interpretation { get; set; }

    public virtual ICollection<Layer> Layers { get; set; } = new List<Layer>();

    public virtual Geopolygon Polygon { get; set; } = null!;
}
