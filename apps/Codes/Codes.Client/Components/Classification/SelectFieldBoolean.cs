namespace TEI.Codes.Client.Components.Classification;

using System.Globalization;
using TEI.Codes.Data;

public class SelectFieldBoolean(string label, Func<FilterBcgEcoCodesResponse?, IList<bool>> retrieveOptions, Action<FilterBcgEcoCodesRequest, bool?> populateRequest)
    : SelectField(label, RetrieveOptionsWrapper(retrieveOptions), PopulateRequestWrapper(populateRequest))
{
    private static Func<FilterBcgEcoCodesResponse?, IList<string>> RetrieveOptionsWrapper(Func<FilterBcgEcoCodesResponse?, IList<bool>> retrieveOptions)
    {
        return response => retrieveOptions(response).Select(x => x.ToString()).ToList();
    }

    private static Action<FilterBcgEcoCodesRequest, string?> PopulateRequestWrapper(Action<FilterBcgEcoCodesRequest, bool?> populateRequest)
    {
        return (request, value) => populateRequest(request, value == null ? null : Convert.ToBoolean(value, CultureInfo.InvariantCulture));
    }
}
