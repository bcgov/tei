namespace TEI.Database.Data.Entities;

public partial class Texture
{
    public int TextureId { get; set; }

    public virtual ICollection<Layer> LayerTexture1s { get; set; } = new List<Layer>();

    public virtual ICollection<Layer> LayerTexture2s { get; set; } = new List<Layer>();

    public virtual ICollection<Layer> LayerTexture3s { get; set; } = new List<Layer>();
}
