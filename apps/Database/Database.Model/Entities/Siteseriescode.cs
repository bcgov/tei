﻿namespace TEI.Database.Model.Entities;

public partial class Siteseriescode
{
    public string SiteSeriesCode { get; set; } = null!;

    public virtual ICollection<Ecocode> Ecocodes { get; set; } = new List<Ecocode>();
}
