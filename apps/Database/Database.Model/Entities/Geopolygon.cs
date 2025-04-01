namespace TEI.Database.Model.Entities;

using NpgsqlTypes;

public partial class Geopolygon
{
    public int GeoPolygonId { get; set; }

    public int GeometryId { get; set; }

    public NpgsqlPolygon GeoPolygon { get; set; }

    public virtual ICollection<Ecocomponent> Ecocomponents { get; set; } = new List<Ecocomponent>();

    public virtual Geometry Geometry { get; set; } = null!;

    public virtual ICollection<Tercomponent> Tercomponents { get; set; } = new List<Tercomponent>();

    public virtual ICollection<Geopoint> Points { get; set; } = new List<Geopoint>();
}
