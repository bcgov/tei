namespace TEI.Codes.Client.Components.Classification.Input;

using TEI.Codes.Client.Models.Classification;

public record InputFieldLeafNode(ClassificationInputField Field) : InputFieldNode([], XlWidth: 6)
{
    public bool FloatingLabel { get; init; }

    public override bool IsEmpty => this.Field.IsEmpty;
}
