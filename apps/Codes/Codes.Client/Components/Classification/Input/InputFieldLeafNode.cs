namespace TEI.Codes.Client.Components.Classification.Input;

using TEI.Codes.Client.Models.Classification;

/// <summary>
/// Tree leaf node for organizing input fields, containing a single field and no child nodes.
/// </summary>
/// <param name="Field">The input field.</param>
public record InputFieldLeafNode(ClassificationInputField Field) : InputFieldNode([], XlWidth: 6)
{
    public bool FloatingLabel { get; init; }

    public override bool IsEmpty => this.Field.IsEmpty;
}
