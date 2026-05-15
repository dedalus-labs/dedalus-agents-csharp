using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models.Ocr;

/// <summary>
/// Single page OCR result.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OcrPage, OcrPageFromRaw>))]
public sealed record class OcrPage : JsonModel
{
    public required long Index
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("index");
        }
        init { this._rawData.Set("index", value); }
    }

    public required string Markdown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("markdown");
        }
        init { this._rawData.Set("markdown", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Index;
        _ = this.Markdown;
    }

    public OcrPage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OcrPage(OcrPage ocrPage)
        : base(ocrPage) { }
#pragma warning restore CS8618

    public OcrPage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OcrPage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OcrPageFromRaw.FromRawUnchecked"/>
    public static OcrPage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OcrPageFromRaw : IFromRawJson<OcrPage>
{
    /// <inheritdoc/>
    public OcrPage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OcrPage.FromRawUnchecked(rawData);
}
