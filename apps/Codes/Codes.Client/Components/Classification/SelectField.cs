namespace TEI.Codes.Client.Components.Classification;

using TEI.Codes.Data;

public class SelectField
{
    public const string UnselectedValue = "[UNSELECTED]";

    public SelectField(
        string label,
        Func<FilterBcgEcoCodesResponse?, IList<string>> retrieveOptions,
        Action<FilterBcgEcoCodesRequest, string?> populateRequest,
        Func<FilterBcgEcoCodesRequest, string?> retrieveParameter)
    {
        this.Label = label;
        this.RetrieveOptionsFunc = r => retrieveOptions(r).Select<string, (string, string)>(o => (o, o)).ToList();
        this.PopulateRequestAction = populateRequest;
        this.RetrieveParameterFunc = retrieveParameter;
    }

    public SelectField(
        string label,
        Func<FilterBcgEcoCodesResponse?, IList<(string, string)>> retrieveOptions,
        Action<FilterBcgEcoCodesRequest, string?> populateRequest,
        Func<FilterBcgEcoCodesRequest, string?> retrieveParameter)
    {
        this.Label = label;
        this.RetrieveOptionsFunc = retrieveOptions;
        this.PopulateRequestAction = populateRequest;
        this.RetrieveParameterFunc = retrieveParameter;
    }

    public string Label { get; }
    private Func<FilterBcgEcoCodesResponse?, IList<(string, string)>> RetrieveOptionsFunc { get; }
    private Action<FilterBcgEcoCodesRequest, string?> PopulateRequestAction { get; }
    private Func<FilterBcgEcoCodesRequest, string?> RetrieveParameterFunc { get; }

    public IList<(string, string)> FilteredValues { get; private set; } = [];
    public string SelectedValue { get; private set; } = UnselectedValue;
    public IList<SelectField> Subfields { get; init; } = [];

    public Guid InputId { get; } = Guid.NewGuid();

    public bool IsEmpty => (this.SelectedValue == UnselectedValue) & this.Subfields.All(x => x.IsEmpty);

    public void UpdateSelectedValue(string value, ILogger logger)
    {
        logger.LogInformation("Changing selected {Field} from '{OldValue}' to '{NewValue}'", this.Label, this.SelectedValue, value);
        this.SelectedValue = value;
    }

    public void UpdateSelectedValue(FilterBcgEcoCodesRequest request, ILogger logger)
    {
        this.UpdateSelectedValue(this.RetrieveParameterFunc(request), logger);
        foreach (SelectField subfield in this.Subfields)
        {
            subfield.UpdateSelectedValue(request, logger);
        }
    }

    public void UpdateFilteredValues(FilterBcgEcoCodesResponse? response, ILogger logger)
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

        foreach (SelectField subfield in this.Subfields)
        {
            subfield.UpdateFilteredValues(response, logger);
        }
    }

    public void PopulateRequest(FilterBcgEcoCodesRequest request, ILogger logger, bool includeChildren = true)
    {
        string? value = this.SelectedValue == UnselectedValue ? null : this.SelectedValue;
        logger.LogDebug("Populating request, setting {Field} to '{Value}'", this.Label, value);
        this.PopulateRequestAction(request, value);

        if (includeChildren)
        {
            foreach (SelectField subfield in this.Subfields)
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
            foreach (SelectField subfield in this.Subfields)
            {
                subfield.ClearSelectedValues(logger);
            }
        }
    }
}
