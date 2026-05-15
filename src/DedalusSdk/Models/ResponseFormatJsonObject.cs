using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;

namespace DedalusSdk.Models;

/// <summary>
/// JSON object response format. An older method of generating JSON responses. Using
/// `json_schema` is recommended for models that support it. Note that the model
/// will not generate JSON without a system or user message instructing it to do so.
///
/// <para>Fields: - type (required): Literal["json_object"]</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ResponseFormatJsonObject, ResponseFormatJsonObjectFromRaw>)
)]
public sealed record class ResponseFormatJsonObject : JsonModel
{
    /// <summary>
    /// The type of response format being defined. Always `json_object`.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("json_object")))
        {
            throw new DedalusInvalidDataException("Invalid value given for constant");
        }
    }

    public ResponseFormatJsonObject()
    {
        this.Type = JsonSerializer.SerializeToElement("json_object");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResponseFormatJsonObject(ResponseFormatJsonObject responseFormatJsonObject)
        : base(responseFormatJsonObject) { }
#pragma warning restore CS8618

    public ResponseFormatJsonObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("json_object");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResponseFormatJsonObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResponseFormatJsonObjectFromRaw.FromRawUnchecked"/>
    public static ResponseFormatJsonObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResponseFormatJsonObjectFromRaw : IFromRawJson<ResponseFormatJsonObject>
{
    /// <inheritdoc/>
    public ResponseFormatJsonObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ResponseFormatJsonObject.FromRawUnchecked(rawData);
}
