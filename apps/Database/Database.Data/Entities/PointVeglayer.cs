namespace TEI.Database.Data.Entities;

public partial class PointVeglayer
{
    public int PointId { get; set; }

    public string VegLayerCode { get; set; } = null!;

    public virtual Geopoint Point { get; set; } = null!;

    public virtual Veglayercode VegLayerCodeNavigation { get; set; } = null!;

    public virtual ICollection<Vegspeciescode> VegSpeciesCodes { get; set; } = new List<Vegspeciescode>();
}
