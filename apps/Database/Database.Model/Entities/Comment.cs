namespace TEI.Database.Model.Entities;

public partial class Comment
{
    public int CommentId { get; set; }

    public string? CommentType { get; set; }

    public int? ProjectBapid { get; set; }

    public string Comment1 { get; set; } = null!;

    public string? Url { get; set; }

    public DateTime? CreatedDt { get; set; }

    public virtual Commenttype? CommentTypeNavigation { get; set; }

    public virtual Project? ProjectBap { get; set; }
}
