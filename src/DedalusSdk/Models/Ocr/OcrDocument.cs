using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models.Ocr;

/// <summary>
/// Document input for OCR.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OcrDocument, OcrDocumentFromRaw>))]
public sealed record class OcrDocument : JsonModel
{
    /// <summary>
    /// Data URI with base64-encoded document
    /// </summary>
    public required string DocumentUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("document_url");
        }
        init { this._rawData.Set("document_url", value); }
    }

    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DocumentUrl;
        _ = this.Type;
    }

    public OcrDocument() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OcrDocument(OcrDocument ocrDocument)
        : base(ocrDocument) { }
#pragma warning restore CS8618

    public OcrDocument(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OcrDocument(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OcrDocumentFromRaw.FromRawUnchecked"/>
    public static OcrDocument FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OcrDocument(string documentUrl)
        : this()
    {
        this.DocumentUrl = documentUrl;
    }
}

class OcrDocumentFromRaw : IFromRawJson<OcrDocument>
{
    /// <inheritdoc/>
    public OcrDocument FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OcrDocument.FromRawUnchecked(rawData);
}
