﻿namespace TEI.Database.Model.Entities;

public partial class Material
{
    public int MaterialId { get; set; }

    public virtual ICollection<Layer> Layers { get; set; } = new List<Layer>();
}
