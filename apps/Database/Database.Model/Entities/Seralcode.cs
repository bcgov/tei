﻿namespace TEI.Database.Model.Entities;

public partial class Seralcode
{
    public string SeralCode { get; set; } = null!;

    public virtual ICollection<Ecocode> Ecocodes { get; set; } = new List<Ecocode>();
}
