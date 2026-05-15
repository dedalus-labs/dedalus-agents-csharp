using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models.Ocr;

/// <summary>
/// OCR request schema.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OcrRequest, OcrRequestFromRaw>))]
public sealed record class OcrRequest : JsonModel
{
    /// <summary>
    /// Document input for OCR.
    /// </summary>
    public required OcrDocument Document
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<OcrDocument>("document");
        }
        init { this._rawData.Set("document", value); }
    }

    public string? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Document.Validate();
        _ = this.Model;
    }

    public OcrRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OcrRequest(OcrRequest ocrRequest)
        : base(ocrRequest) { }
#pragma warning restore CS8618

    public OcrRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OcrRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OcrRequestFromRaw.FromRawUnchecked"/>
    public static OcrRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OcrRequest(OcrDocument document)
        : this()
    {
        this.Document = document;
    }
}

class OcrRequestFromRaw : IFromRawJson<OcrRequest>
{
    /// <inheritdoc/>
    public OcrRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OcrRequest.FromRawUnchecked(rawData);
}
