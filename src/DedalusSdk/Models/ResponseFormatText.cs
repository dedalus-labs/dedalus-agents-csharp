using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;

namespace DedalusSdk.Models;

/// <summary>
/// Default response format. Used to generate text responses.
///
/// <para>Fields: - type (required): Literal["text"]</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ResponseFormatText, ResponseFormatTextFromRaw>))]
public sealed record class ResponseFormatText : JsonModel
{
    /// <summary>
    /// The type of response format being defined. Always `text`.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("text")))
        {
            throw new DedalusInvalidDataException("Invalid value given for constant");
        }
    }

    public ResponseFormatText()
    {
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResponseFormatText(ResponseFormatText responseFormatText)
        : base(responseFormatText) { }
#pragma warning restore CS8618

    public ResponseFormatText(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResponseFormatText(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResponseFormatTextFromRaw.FromRawUnchecked"/>
    public static ResponseFormatText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResponseFormatTextFromRaw : IFromRawJson<ResponseFormatText>
{
    /// <inheritdoc/>
    public ResponseFormatText FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ResponseFormatText.FromRawUnchecked(rawData);
}
