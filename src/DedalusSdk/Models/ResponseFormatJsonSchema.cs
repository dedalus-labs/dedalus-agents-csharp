using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;

namespace DedalusSdk.Models;

/// <summary>
/// JSON Schema response format. Used to generate structured JSON responses. Learn
/// more about [Structured Outputs](/docs/guides/structured-outputs).
///
/// <para>Fields: - type (required): Literal["json_schema"] - json_schema (required): JSONSchema</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ResponseFormatJsonSchema, ResponseFormatJsonSchemaFromRaw>)
)]
public sealed record class ResponseFormatJsonSchema : JsonModel
{
    /// <summary>
    /// Structured Outputs configuration options, including a JSON Schema.
    /// </summary>
    public required JsonSchema JsonSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<JsonSchema>("json_schema");
        }
        init { this._rawData.Set("json_schema", value); }
    }

    /// <summary>
    /// The type of response format being defined. Always `json_schema`.
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
        this.JsonSchema.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("json_schema")))
        {
            throw new DedalusInvalidDataException("Invalid value given for constant");
        }
    }

    public ResponseFormatJsonSchema()
    {
        this.Type = JsonSerializer.SerializeToElement("json_schema");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResponseFormatJsonSchema(ResponseFormatJsonSchema responseFormatJsonSchema)
        : base(responseFormatJsonSchema) { }
#pragma warning restore CS8618

    public ResponseFormatJsonSchema(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("json_schema");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResponseFormatJsonSchema(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResponseFormatJsonSchemaFromRaw.FromRawUnchecked"/>
    public static ResponseFormatJsonSchema FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ResponseFormatJsonSchema(JsonSchema jsonSchema)
        : this()
    {
        this.JsonSchema = jsonSchema;
    }
}

class ResponseFormatJsonSchemaFromRaw : IFromRawJson<ResponseFormatJsonSchema>
{
    /// <inheritdoc/>
    public ResponseFormatJsonSchema FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ResponseFormatJsonSchema.FromRawUnchecked(rawData);
}

/// <summary>
/// Structured Outputs configuration options, including a JSON Schema.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JsonSchema, JsonSchemaFromRaw>))]
public sealed record class JsonSchema : JsonModel
{
    /// <summary>
    /// The name of the response format. Must be a-z, A-Z, 0-9, or contain underscores
    /// and dashes, with a maximum length of 64.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// A description of what the response format is for, used by the model to determine
    /// how to respond in the format.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// The schema for the response format, described as a JSON Schema object. Learn
    /// how to build JSON schemas [here](https://json-schema.org/).
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Schema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("schema");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "schema",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Whether to enable strict schema adherence when generating the output. If set
    /// to true, the model will always follow the exact schema defined in the `schema`
    /// field. Only a subset of JSON Schema is supported when `strict` is `true`.
    /// To learn more, read the [Structured Outputs guide](/docs/guides/structured-outputs).
    /// </summary>
    public bool? Strict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("strict");
        }
        init { this._rawData.Set("strict", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Description;
        _ = this.Schema;
        _ = this.Strict;
    }

    public JsonSchema() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JsonSchema(JsonSchema jsonSchema)
        : base(jsonSchema) { }
#pragma warning restore CS8618

    public JsonSchema(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JsonSchema(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JsonSchemaFromRaw.FromRawUnchecked"/>
    public static JsonSchema FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JsonSchema(string name)
        : this()
    {
        this.Name = name;
    }
}

class JsonSchemaFromRaw : IFromRawJson<JsonSchema>
{
    /// <inheritdoc/>
    public JsonSchema FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JsonSchema.FromRawUnchecked(rawData);
}
