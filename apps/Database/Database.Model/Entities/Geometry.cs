namespace TEI.Database.Model.Entities;

public partial class Geometry
{
    public int GeometryId { get; set; }

    public int EcoObjectId { get; set; }

    public int? DrainageId { get; set; }

    public int? InterpretationId { get; set; }

    public string? GeometryType { get; set; }

    public string? FlagId { get; set; }

    public string? CnwiBcCode { get; set; }

    public string? FeatureCode { get; set; }

    public short? ScaleCode { get; set; }

    public virtual Cnwibc? CnwiBcCodeNavigation { get; set; }

    public virtual Drainage? Drainage { get; set; }

    public virtual Ecoobject EcoObject { get; set; } = null!;

    public virtual ICollection<Error> Errors { get; set; } = new List<Error>();

    public virtual Featurecode? FeatureCodeNavigation { get; set; }

    public virtual Flag? Flag { get; set; }

    public virtual ICollection<GeometryGeomorphicprocess> GeometryGeomorphicprocesses { get; set; } = new List<GeometryGeomorphicprocess>();

    public virtual Geometrytype? GeometryTypeNavigation { get; set; }

    public virtual ICollection<Geopoint> Geopoints { get; set; } = new List<Geopoint>();

    public virtual ICollection<Geopolygon> Geopolygons { get; set; } = new List<Geopolygon>();

    public virtual Interpretation? Interpretation { get; set; }

    public virtual Scalecode? ScaleCodeNavigation { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<Methodologycode> MethodologyCodes { get; set; } = new List<Methodologycode>();
}
