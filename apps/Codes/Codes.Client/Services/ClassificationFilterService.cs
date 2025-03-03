namespace TEI.Codes.Client.Services;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using TEI.Codes.Client.Api;
using TEI.Codes.Client.Models.Classification;
using TEI.Codes.Data.Models;
using TEI.Common.Data.Models;

public class ClassificationFilterService(ILogger<ClassificationFilterService> logger, IClassificationApi classificationApi) : IClassificationFilterService
{
    private PaginatedResult<FilterBcgEcoCodesResponse>? filterResponse;

    private Stack<FilterBcgEcoCodes> FilterHistory { get; } = new();

    public IDictionary<ClassificationFieldType, ClassificationInputField> InputFields { get; } = GenerateInputFields();
    public IDictionary<ClassificationFieldType, ClassificationOutputField> OutputFields { get; } = GenerateOutputFields();

    public PaginatedResult<FilterBcgEcoCodesResponse>? FilterResponse
    {
        get => this.filterResponse;

        private set
        {
            this.filterResponse = value;
            this.UpdateInputFields(value?.Data);
            this.UpdateOutputFields(value?.Data);
        }
    }

    public bool Loading { get; private set; }

    public bool FiltersAreEmpty => this.InputFields.Values.All(x => x.IsEmpty);

    public bool HistoryIsEmpty => this.FilterHistory.Count == 0;

    public void ClearAllFilters()
    {
        logger.LogInformation("Clearing all filters");

        FilterBcgEcoCodes initialFilter = this.FilterHistory.Last();
        this.FilterHistory.Clear();
        this.RestoreFilter(initialFilter);
        this.FilterHistory.Push(initialFilter);
    }

    public void RestorePreviousFilter()
    {
        this.FilterHistory.Pop();
        this.RestoreFilter(this.FilterHistory.Peek());
    }

    public async Task FilterResultsAsync()
    {
        if (this.FilterHistory.Count > 0 && this.FiltersAreEmpty)
        {
            this.FilterResponse = this.FilterHistory.Last().Response;
        }
        else
        {
            FilterBcgEcoCodesRequest request = new();
            foreach (ClassificationInputField field in this.InputFields.Values)
            {
                field.PopulateRequest(request, logger, false);
            }

            await this.GetFilterResponseAsync(request);
        }
    }

    public async Task FilterToResultAsync(ResultPreview preview)
    {
        this.InputFields[ClassificationFieldType.BgcLabel].UpdateSelectedValue(preview.BgcLabel, logger);
        this.InputFields[ClassificationFieldType.EcosystemCode].UpdateSelectedValue(preview.EcosystemCode, logger);
        this.InputFields[ClassificationFieldType.SiteSeriesName].UpdateSelectedValue(preview.SiteSeriesName, logger);
        this.InputFields[ClassificationFieldType.Source].UpdateSelectedValue(preview.Source, logger);
        (this.InputFields[ClassificationFieldType.Approved] as ClassificationInputFieldBoolean)?.UpdateSelectedValue(preview.Approved, logger);
        await this.FilterResultsAsync();
    }

    [SuppressMessage("Maintainability", "CA1502:Avoid excessive complexity")]
    private static Dictionary<ClassificationFieldType, ClassificationInputField> GenerateInputFields()
    {
        IList<ClassificationInputField> inputFieldList =
        [
            new(
                ClassificationFieldType.BgcLabel,
                response => response?.BgcCodeValues.Select(x => (x.Value, FormatCodeDescription(x))).ToList() ?? [],
                (request, value) => request.BgcCode = value,
                request => request.BgcCode)
            {
                Subfields =
                [
                    new(
                        ClassificationFieldType.Zone,
                        response => response?.ZoneCodeValues.Select(x => (x.Value, FormatCodeDescription(x))).ToList() ?? [],
                        (request, value) => request.ZoneCode = value,
                        request => request.ZoneCode),
                    new(
                        ClassificationFieldType.Subzone,
                        response => response?.SubzoneCodeValues ?? [],
                        (request, value) => request.SubzoneCode = value,
                        request => request.SubzoneCode),
                    new(
                        ClassificationFieldType.Variant,
                        response => response?.VariantCodeValues ?? [],
                        (request, value) => request.VariantCode = value,
                        request => request.VariantCode),
                    new(
                        ClassificationFieldType.Phase,
                        response => response?.PhaseCodeValues ?? [],
                        (request, value) => request.PhaseCode = value,
                        request => request.PhaseCode),
                ],
            },
            new(
                ClassificationFieldType.EcosystemCode,
                response => response?.EcosystemCodeValues ?? [],
                (request, value) => request.EcosystemCode = value,
                request => request.EcosystemCode)
            {
                Subfields =
                [
                    new(
                        ClassificationFieldType.MapCode,
                        response => response?.MapCodeValues ?? [],
                        (request, value) => request.MapCode = value,
                        request => request.MapCode),
                    new(
                        ClassificationFieldType.SiteSeries,
                        response => response?.SiteSeriesCodeValues ?? [],
                        (request, value) => request.SiteSeriesCode = value,
                        request => request.SiteSeriesCode),
                    new(
                        ClassificationFieldType.SsPhase,
                        response => response?.SsPhaseCodeValues ?? [],
                        (request, value) => request.SsPhaseCode = value,
                        request => request.SsPhaseCode),
                    new(
                        ClassificationFieldType.Seral,
                        response => response?.SeralCodeValues ?? [],
                        (request, value) => request.SeralCode = value,
                        request => request.SeralCode),
                    new(
                        ClassificationFieldType.Variation,
                        response => response?.VariationCodeValues ?? [],
                        (request, value) => request.VariationCode = value,
                        request => request.VariationCode),
                ],
            },
            new(
                ClassificationFieldType.NbecCode,
                response => response?.NbecCodeValues ?? [],
                (request, value) => request.NbecCode = value,
                request => request.NbecCode),
            new(
                ClassificationFieldType.SiteComponentCode,
                response => response?.SiteComponentCodeValues ?? [],
                (request, value) => request.SiteComponentCode = value,
                request => request.SiteComponentCode)
            {
                Subfields =
                [
                    new(
                        ClassificationFieldType.Realm,
                        response => response?.RealmCodeValues ?? [],
                        (request, value) => request.RealmCode = value,
                        request => request.RealmCode),
                    new(
                        ClassificationFieldType.Group,
                        response => response?.GroupCodeValues ?? [],
                        (request, value) => request.GroupCode = value,
                        request => request.GroupCode),
                    new(
                        ClassificationFieldType.Class,
                        response => response?.ClassCodeValues ?? [],
                        (request, value) => request.ClassCode = value,
                        request => request.ClassCode),
                    new(
                        ClassificationFieldType.Association,
                        response => response?.AssociationCodeValues ?? [],
                        (request, value) => request.AssociationCode = value,
                        request => request.AssociationCode),
                    new(
                        ClassificationFieldType.Subclass,
                        response => response?.SubclassCodeValues ?? [],
                        (request, value) => request.SubclassCode = value,
                        request => request.SubclassCode),
                ],
            },
            new(
                ClassificationFieldType.SiteSeriesName,
                response => response?.SiteSeriesNameValues ?? [],
                (request, value) => request.SiteSeriesName = value,
                request => request.SiteSeriesName),
            new ClassificationInputFieldBoolean(
                ClassificationFieldType.Forested,
                response => response?.ForestedValues ?? [],
                (request, value) => request.Forested = value,
                request => request.Forested),
            new(
                ClassificationFieldType.EcosystemType,
                response => response?.EcosystemTypeValues.Select(x => (x.Value, FormatCodeDescription(x))).ToList() ?? [],
                (request, value) => request.EcosystemType = value,
                request => request.EcosystemType),
            new(
                ClassificationFieldType.EcosystemSubtype,
                response => response?.EcosystemSubtypeValues.Select(x => (x.Value, FormatCodeDescription(x))).ToList() ?? [],
                (request, value) => request.EcosystemSubtype = value,
                request => request.EcosystemSubtype),
            new(
                ClassificationFieldType.KindType,
                response => response?.KindTypeValues.Select(x => (x.Value, FormatCodeDescription(x))).ToList() ?? [],
                (request, value) => request.KindType = value,
                request => request.KindType),
            new(
                ClassificationFieldType.Source,
                response => response?.SourceValues ?? [],
                (request, value) => request.Source = value,
                request => request.Source),
            new ClassificationInputFieldBoolean(
                ClassificationFieldType.Approved,
                response => response?.ApprovedValues ?? [],
                (request, value) => request.Approved = value,
                request => request.Approved),
        ];

        return inputFieldList.Concat(inputFieldList.SelectMany(f => f.Descendants)).ToDictionary(f => f.FieldType, f => f);

        static string FormatCodeDescription(CodeDescription codeDescription)
        {
            return string.IsNullOrEmpty(codeDescription.Description)
                ? codeDescription.Value
                : $"{codeDescription.Value} - {codeDescription.Description}";
        }
    }

    [SuppressMessage("Maintainability", "CA1502:Avoid excessive complexity")]
    private static Dictionary<ClassificationFieldType, ClassificationOutputField> GenerateOutputFields()
    {
        IList<ClassificationOutputField> outputFieldList =
        [
            new(ClassificationFieldType.BgcLabel, code => FormatCodeDescription(code?.BgcCode)),
            new(ClassificationFieldType.Zone, code => FormatCodeDescription(code?.ZoneCode)),
            new(ClassificationFieldType.Subzone, code => code?.SubzoneCode),
            new(ClassificationFieldType.Variant, code => code?.VariantCode),
            new(ClassificationFieldType.Phase, code => code?.PhaseCode),
            new(ClassificationFieldType.EcosystemCode, code => code?.EcosystemCode),
            new(ClassificationFieldType.MapCode, code => FormatCodeDescription(code?.MapCode)),
            new(ClassificationFieldType.SiteSeries, code => code?.SiteSeriesCode),
            new(ClassificationFieldType.SsPhase, code => code?.SsPhaseCode),
            new(ClassificationFieldType.Seral, code => code?.SeralCode),
            new(ClassificationFieldType.Variation, code => code?.VariationCode),
            new(ClassificationFieldType.NbecCode, code => code?.NbecCode),
            new(ClassificationFieldType.SiteComponentCode, code => code?.SiteComponentCode),
            new(ClassificationFieldType.Realm, code => code?.RealmCode),
            new(ClassificationFieldType.Group, code => code?.GroupCode),
            new(ClassificationFieldType.Class, code => code?.ClassCode),
            new(ClassificationFieldType.Association, code => code?.AssociationCode),
            new(ClassificationFieldType.Subclass, code => code?.SubclassCode),
            new(ClassificationFieldType.SiteSeriesName, code => code?.SiteSeriesName),
            new(ClassificationFieldType.Forested, code => code?.Forested.ToString()),
            new(ClassificationFieldType.EcosystemType, code => FormatCodeDescription(code?.EcosystemType)),
            new(ClassificationFieldType.EcosystemSubtype, code => FormatCodeDescription(code?.EcosystemSubtype)),
            new(ClassificationFieldType.KindType, code => FormatCodeDescription(code?.KindType)),
            new(ClassificationFieldType.Source, code => code?.Source),
            new(ClassificationFieldType.DateAdded, code => code?.DateAdded.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)),
            new(ClassificationFieldType.Approved, code => code?.Approved.ToString()),
        ];

        return outputFieldList.ToDictionary(f => f.FieldType, f => f);

        static string FormatCodeDescription(CodeDescription? cd)
        {
            string result = cd?.Value ?? string.Empty;
            return cd?.Description != null ? $"{result} - {cd.Description}" : result;
        }
    }

    private async Task GetFilterResponseAsync(FilterBcgEcoCodesRequest request)
    {
        try
        {
            this.Loading = true;
            this.FilterResponse = await classificationApi.FilterBgcEcoCodes(request);
            this.FilterHistory.Push(new() { Request = request, Response = this.FilterResponse });
        }
        finally
        {
            this.Loading = false;
        }
    }

    private void UpdateInputFields(FilterBcgEcoCodesResponse? response)
    {
        foreach (ClassificationInputField field in this.InputFields.Values)
        {
            field.UpdateFilteredValues(response, logger, false);
        }
    }

    private void UpdateOutputFields(FilterBcgEcoCodesResponse? response)
    {
        foreach (ClassificationOutputField field in this.OutputFields.Values)
        {
            field.SetValues(response?.UniqueResult);
        }
    }

    private void RestoreFilter(FilterBcgEcoCodes filter)
    {
        foreach (ClassificationInputField field in this.InputFields.Values)
        {
            field.UpdateSelectedValue(filter.Request, logger, false);
        }

        foreach (ClassificationInputField field in this.InputFields.Values)
        {
            field.UpdateFilteredValues(filter.Response.Data, logger);
        }

        this.FilterResponse = filter.Response;
    }

    private record FilterBcgEcoCodes
    {
        public required FilterBcgEcoCodesRequest Request { get; init; }
        public required PaginatedResult<FilterBcgEcoCodesResponse> Response { get; init; }
    }
}
