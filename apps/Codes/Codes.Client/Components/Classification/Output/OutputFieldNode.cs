namespace TEI.Codes.Client.Components.Classification.Output;

/// <summary>
/// Tree node for organizing output fields.
/// </summary>
/// <param name="Children">Children of the node.</param>
/// <param name="XsWidth">Column width at xs size and above. Null values indicate auto-sizing with siblings.</param>
/// <param name="MdWidth">Column width at md size and above. Null values indicate auto-sizing with siblings.</param>
/// <param name="XlWidth">Column width at xl size and above. Null values indicate auto-sizing with siblings.</param>
public record OutputFieldNode(IList<OutputFieldNode> Children, int? XsWidth = 12, int? MdWidth = 12, int? XlWidth = 12)
{
    public string? Label { get; init; }
}
