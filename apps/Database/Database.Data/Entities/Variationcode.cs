﻿namespace TEI.Database.Data.Entities;

public partial class Variationcode
{
    public string VariationCode { get; set; } = null!;

    public virtual ICollection<Ecocode> Ecocodes { get; set; } = new List<Ecocode>();
}
