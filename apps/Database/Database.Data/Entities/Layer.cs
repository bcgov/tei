namespace TEI.Database.Data.Entities;

public partial class Layer
{
    public int LayerId { get; set; }

    public int LayerType { get; set; }

    public int TerComponentId { get; set; }

    public int MaterialId { get; set; }

    public int? Texture1Id { get; set; }

    public int? Texture2Id { get; set; }

    public int? Texture3Id { get; set; }

    public int? Expression1Id { get; set; }

    public int? Expression2Id { get; set; }

    public int? Expression3Id { get; set; }

    public bool MaterialQualifier { get; set; }

    public virtual Expression? Expression1 { get; set; }

    public virtual Expression? Expression2 { get; set; }

    public virtual Expression? Expression3 { get; set; }

    public virtual Layertype LayerTypeNavigation { get; set; } = null!;

    public virtual Material Material { get; set; } = null!;

    public virtual Tercomponent TerComponent { get; set; } = null!;

    public virtual Texture? Texture1 { get; set; }

    public virtual Texture? Texture2 { get; set; }

    public virtual Texture? Texture3 { get; set; }
}
