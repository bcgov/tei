namespace TEI.Database.Data.Entities;

public partial class Datagroup
{
    public int DataGroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public string? Description { get; set; }

    public string? ContractNumber { get; set; }

    public decimal? ContractValue { get; set; }

    public short? SrNumber { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Project> ProjectBaps { get; set; } = new List<Project>();
}
