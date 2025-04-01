namespace TEI.Codes.Client.Models.Classification;

using System.Globalization;
using TEI.Codes.Data.Models;

/// <summary>
/// Manages behaviour associated with a boolean dropdown input field.
/// </summary>
public class ClassificationInputFieldBoolean(
    ClassificationFieldType fieldType,
    Func<FilterBcgEcoCodesResponse?, IList<bool>> retrieveOptions,
    Action<FilterBcgEcoCodesRequest, bool?> populateRequest,
    Func<FilterBcgEcoCodesRequest, bool?> retrieveParameter)
    : ClassificationInputField(fieldType, RetrieveOptionsWrapper(retrieveOptions), PopulateRequestWrapper(populateRequest), RetrieveParameterWrapper(retrieveParameter))
{
    private static Func<FilterBcgEcoCodesResponse?, IList<string>> RetrieveOptionsWrapper(Func<FilterBcgEcoCodesResponse?, IList<bool>> retrieveOptions)
    {
        return response => retrieveOptions(response).Select(x => x.ToString()).ToList();
    }

    private static Action<FilterBcgEcoCodesRequest, string?> PopulateRequestWrapper(Action<FilterBcgEcoCodesRequest, bool?> populateRequest)
    {
        return (request, value) => populateRequest(request, value == null ? null : Convert.ToBoolean(value, CultureInfo.InvariantCulture));
    }

    private static Func<FilterBcgEcoCodesRequest, string?> RetrieveParameterWrapper(Func<FilterBcgEcoCodesRequest, bool?> retrieveParameter)
    {
        return request => retrieveParameter(request)?.ToString();
    }

    public void UpdateSelectedValue(bool value, ILogger logger)
    {
        this.UpdateSelectedValue(value.ToString(), logger);
    }
}
