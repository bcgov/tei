namespace TEI.Database.Model.Entities;

using NpgsqlTypes;

public partial class Geoline
{
    public int GeoLineId { get; set; }

    public NpgsqlLine GeoLine { get; set; }
}
