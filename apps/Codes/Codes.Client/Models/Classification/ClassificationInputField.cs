namespace TEI.Codes.Client.Models.Classification;

using TEI.Codes.Data.Models;
using TEI.Common.Data.Utilities;

public class ClassificationInputField
{
    public const string UnselectedValue = "[UNSELECTED]";

    public ClassificationInputField(
        ClassificationFieldType fieldType,
        Func<FilterBcgEcoCodesResponse?, IList<string>> retrieveOptions,
        Action<FilterBcgEcoCodesRequest, string?> populateRequest,
        Func<FilterBcgEcoCodesRequest, string?> retrieveParameter)
    {
        this.FieldType = fieldType;
        this.RetrieveOptionsFunc = r => retrieveOptions(r).Select<string, (string, string)>(o => (o, o)).ToList();
        this.PopulateRequestAction = populateRequest;
        this.RetrieveParameterFunc = retrieveParameter;
    }

    public ClassificationInputField(
        ClassificationFieldType fieldType,
        Func<FilterBcgEcoCodesResponse?, IList<(string, string)>> retrieveOptions,
        Action<FilterBcgEcoCodesRequest, string?> populateRequest,
        Func<FilterBcgEcoCodesRequest, string?> retrieveParameter)
    {
        this.FieldType = fieldType;
        this.RetrieveOptionsFunc = retrieveOptions;
        this.PopulateRequestAction = populateRequest;
        this.RetrieveParameterFunc = retrieveParameter;
    }

    public ClassificationFieldType FieldType { get; }
    public string Label => EnumUtility.ToEnumString(this.FieldType);
    private Func<FilterBcgEcoCodesResponse?, IList<(string, string)>> RetrieveOptionsFunc { get; }
    private Action<FilterBcgEcoCodesRequest, string?> PopulateRequestAction { get; }
    private Func<FilterBcgEcoCodesRequest, string?> RetrieveParameterFunc { get; }

    public IList<(string, string)> FilteredValues { get; private set; } = [];
    public string SelectedValue { get; private set; } = UnselectedValue;
    public IList<ClassificationInputField> Subfields { get; init; } = [];
    public IList<ClassificationInputField> Descendants => this.Subfields.Concat(this.Subfields.SelectMany(f => f.Descendants)).ToList();

    public Guid InputId { get; } = Guid.NewGuid();

    public bool IsEmpty => (this.SelectedValue == UnselectedValue) & this.Subfields.All(x => x.IsEmpty);

    public void UpdateSelectedValue(string value, ILogger logger)
    {
        logger.LogInformation("Changing selected {Field} from '{OldValue}' to '{NewValue}'", this.Label, this.SelectedValue, value);
        this.SelectedValue = value;
    }

    public void UpdateSelectedValue(FilterBcgEcoCodesRequest request, ILogger logger, bool includeChildren = true)
    {
        this.UpdateSelectedValue(this.RetrieveParameterFunc(request), logger);

        if (includeChildren)
        {
            foreach (ClassificationInputField subfield in this.Subfields)
            {
                subfield.UpdateSelectedValue(request, logger);
            }
        }
    }

    public void UpdateFilteredValues(FilterBcgEcoCodesResponse? response, ILogger logger, bool includeChildren = true)
    {
        logger.LogInformation("Updating filtered values for {Field}", this.Label);
        this.FilteredValues = this.RetrieveOptionsFunc(response);

        if (this.FilteredValues.Count == 1 && this.SelectedValue != this.FilteredValues[0].Item1)
        {
            logger.LogInformation("Updating selected {Field} value to match only available option", this.Label);
            this.SelectedValue = this.FilteredValues[0].Item1;
        }
        else if (this.FilteredValues.All(v => v.Item1 != this.SelectedValue))
        {
            this.SelectedValue = UnselectedValue;
        }

        if (includeChildren)
        {
            foreach (ClassificationInputField subfield in this.Subfields)
            {
                subfield.UpdateFilteredValues(response, logger);
            }
        }
    }

    public void PopulateRequest(FilterBcgEcoCodesRequest request, ILogger logger, bool includeChildren = true)
    {
        string? value = this.SelectedValue == UnselectedValue ? null : this.SelectedValue;
        logger.LogDebug("Populating request, setting {Field} to '{Value}'", this.Label, value);
        this.PopulateRequestAction(request, value);

        if (includeChildren)
        {
            foreach (ClassificationInputField subfield in this.Subfields)
            {
                subfield.PopulateRequest(request, logger);
            }
        }
    }

    public void ClearSelectedValues(ILogger logger, bool includeChildren = true)
    {
        this.UpdateSelectedValue(UnselectedValue, logger);

        if (includeChildren)
        {
            foreach (ClassificationInputField subfield in this.Subfields)
            {
                subfield.ClearSelectedValues(logger);
            }
        }
    }
}
