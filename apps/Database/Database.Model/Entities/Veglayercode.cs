namespace TEI.Database.Model.Entities;

public partial class Veglayercode
{
    public string VegLayerCode { get; set; } = null!;

    public virtual ICollection<PointVeglayer> PointVeglayers { get; set; } = new List<PointVeglayer>();

    public virtual ICollection<Vegspeciescode> VegSpeciesCodes { get; set; } = new List<Vegspeciescode>();
}
