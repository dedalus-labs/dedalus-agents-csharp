using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;

namespace DedalusSdk.Models.Models;

/// <summary>
/// Response for /v1/models endpoint.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ListModelsResponse, ListModelsResponseFromRaw>))]
public sealed record class ListModelsResponse : JsonModel
{
    /// <summary>
    /// List of available models
    /// </summary>
    public required IReadOnlyList<Model> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Model>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Model>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Response object type
    /// </summary>
    public ApiEnum<string, global::DedalusSdk.Models.Models.Object>? Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::DedalusSdk.Models.Models.Object>
            >("object");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("object", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Object?.Validate();
    }

    public ListModelsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ListModelsResponse(ListModelsResponse listModelsResponse)
        : base(listModelsResponse) { }
#pragma warning restore CS8618

    public ListModelsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListModelsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ListModelsResponseFromRaw.FromRawUnchecked"/>
    public static ListModelsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ListModelsResponse(IReadOnlyList<Model> data)
        : this()
    {
        this.Data = data;
    }
}

class ListModelsResponseFromRaw : IFromRawJson<ListModelsResponse>
{
    /// <inheritdoc/>
    public ListModelsResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ListModelsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Response object type
/// </summary>
[JsonConverter(typeof(ObjectConverter))]
public enum Object
{
    List,
}

sealed class ObjectConverter : JsonConverter<global::DedalusSdk.Models.Models.Object>
{
    public override global::DedalusSdk.Models.Models.Object Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "list" => global::DedalusSdk.Models.Models.Object.List,
            _ => (global::DedalusSdk.Models.Models.Object)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::DedalusSdk.Models.Models.Object value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::DedalusSdk.Models.Models.Object.List => "list",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
