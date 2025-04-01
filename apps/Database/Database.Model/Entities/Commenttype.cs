namespace TEI.Database.Model.Entities;

public partial class Commenttype
{
    public string CommentType { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Valid { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
