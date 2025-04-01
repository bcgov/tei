namespace TEI.Database.Model.Entities;

public partial class Expression
{
    public int ExpressionId { get; set; }

    public virtual ICollection<Layer> LayerExpression1s { get; set; } = new List<Layer>();

    public virtual ICollection<Layer> LayerExpression2s { get; set; } = new List<Layer>();

    public virtual ICollection<Layer> LayerExpression3s { get; set; } = new List<Layer>();
}
