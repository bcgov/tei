namespace TEI.Codes.Client.Components.Classification.Input;

public record InputFieldNode(IList<InputFieldNode> Children, int? XsWidth = 12, int? MdWidth = 12, int? XlWidth = 12)
{
    public string? Label { get; init; }

    public virtual bool IsEmpty => this.Children.All(x => x.IsEmpty);
}
