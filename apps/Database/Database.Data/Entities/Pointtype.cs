﻿namespace TEI.Database.Data.Entities;

public partial class Pointtype
{
    public string PointType { get; set; } = null!;

    public virtual ICollection<Geopoint> Geopoints { get; set; } = new List<Geopoint>();
}
