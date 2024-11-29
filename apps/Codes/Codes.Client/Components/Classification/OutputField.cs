namespace TEI.Codes.Client.Components.Classification;

using TEI.Codes.Data;

public class OutputField(string label, Func<FullBgcEcoCode?, string?> selectValue)
{
    public string Label { get; } = label;
    private Func<FullBgcEcoCode?, string?> SelectValue { get; } = selectValue;

    public IList<OutputField> Subfields { get; init; } = [];
    public OutputFieldSize Size { get; init; } = OutputFieldSize.Medium;
    public bool StartNewRow { get; init; }

    public string? Value { get; private set; }

    public Guid InputId { get; } = Guid.NewGuid();

    public void SetValues(FullBgcEcoCode? code, bool includeChildren = true)
    {
        this.Value = this.SelectValue(code);

        if (includeChildren)
        {
            foreach (OutputField subfield in this.Subfields)
            {
                subfield.SetValues(code);
            }
        }
    }
}

public enum OutputFieldSize
{
    Small,
    Medium,
    Large,
}
