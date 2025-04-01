namespace TEI.Database.Model.Entities;

public partial class Layertype
{
    public int LayerType { get; set; }

    public virtual ICollection<Layer> Layers { get; set; } = new List<Layer>();
}
