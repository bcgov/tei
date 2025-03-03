namespace TEI.Codes.Client.Components.Classification.Output;

public record OutputFieldNode(IList<OutputFieldNode> Children, int? XsWidth = 12, int? MdWidth = 12, int? XlWidth = 12)
{
    public string? Label { get; init; }
}
