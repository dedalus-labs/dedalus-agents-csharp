using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models.Ocr;

/// <summary>
/// OCR response schema.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OcrResponse, OcrResponseFromRaw>))]
public sealed record class OcrResponse : JsonModel
{
    public required string Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    public required IReadOnlyList<OcrPage> Pages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<OcrPage>>("pages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<OcrPage>>(
                "pages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("usage");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "usage",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Model;
        foreach (var item in this.Pages)
        {
            item.Validate();
        }
        _ = this.Usage;
    }

    public OcrResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OcrResponse(OcrResponse ocrResponse)
        : base(ocrResponse) { }
#pragma warning restore CS8618

    public OcrResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OcrResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OcrResponseFromRaw.FromRawUnchecked"/>
    public static OcrResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OcrResponseFromRaw : IFromRawJson<OcrResponse>
{
    /// <inheritdoc/>
    public OcrResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OcrResponse.FromRawUnchecked(rawData);
}
