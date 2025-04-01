namespace TEI.Codes.Client.Components.Classification.Output;

using TEI.Codes.Client.Models.Classification;

/// <summary>
/// Tree leaf node for organizing output fields, containing a single field and no child nodes.
/// </summary>
/// <param name="Field">The output field.</param>
public record OutputFieldLeafNode(ClassificationOutputField Field) : OutputFieldNode([], 6, null, null);
