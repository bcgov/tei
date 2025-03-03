namespace TEI.Database.Data.Entities;

using NpgsqlTypes;

public partial class Geopoint
{
    public int GeoPointId { get; set; }

    public string? PointType { get; set; }

    public int GeometryId { get; set; }

    public int? BgcEcocodeId { get; set; }

    public NpgsqlPoint GeoPoint { get; set; }

    public virtual Bgcecocode? BgcEcocode { get; set; }

    public virtual Geometry Geometry { get; set; } = null!;

    public virtual Pointtype? PointTypeNavigation { get; set; }

    public virtual ICollection<PointVeglayer> PointVeglayers { get; set; } = new List<PointVeglayer>();

    public virtual ICollection<Geopolygon> Polygons { get; set; } = new List<Geopolygon>();
}
