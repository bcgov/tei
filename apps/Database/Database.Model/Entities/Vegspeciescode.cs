namespace TEI.Database.Model.Entities;

public partial class Vegspeciescode
{
    public string VegSpeciesCode { get; set; } = null!;

    public virtual ICollection<PointVeglayer> PointVeglayers { get; set; } = new List<PointVeglayer>();

    public virtual ICollection<Veglayercode> VegLayerCodes { get; set; } = new List<Veglayercode>();
}
