namespace TEI.Codes.Client.Models.Classification;

using TEI.Codes.Data.Models;
using TEI.Common.Data.Utilities;

public class ClassificationOutputField(ClassificationFieldType fieldType, Func<FullBgcEcoCode?, string?> selectValueFunc)
{
    private Func<FullBgcEcoCode?, string?> SelectValueFunc { get; } = selectValueFunc;

    public ClassificationFieldType FieldType { get; } = fieldType;
    public string Label => EnumUtility.ToEnumString(this.FieldType);
    public string? Value { get; private set; }
    public Guid ElementId { get; } = Guid.NewGuid();

    public void SetValues(FullBgcEcoCode? code)
    {
        this.Value = this.SelectValueFunc(code);
    }
}
