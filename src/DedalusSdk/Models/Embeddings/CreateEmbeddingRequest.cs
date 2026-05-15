using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;

namespace DedalusSdk.Models.Embeddings;

/// <summary>
/// Schema for EmbeddingRequest.
///
/// <para>Fields: - input (required): str | Annotated[list[str], MinLen(1), MaxLen(2048),
/// ArrayTitle("EmbeddingRequestInputArray")] | Annotated[list[int], MinLen(1), MaxLen(2048),
/// ArrayTitle("EmbeddingRequestInputArray")] | Annotated[list[Annotated[list[int],
/// MinLen(1), ArrayTitle("EmbeddingRequestInputItemArray")]], MinLen(1), MaxLen(2048),
/// ArrayTitle("EmbeddingRequestInputArray")] - model (required): str | Literal["text-embedding-ada-002",
/// "text-embedding-3-small", "text-embedding-3-large"] - encoding_format (optional):
/// Literal["float", "base64"] - dimensions (optional): int - user (optional): str</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreateEmbeddingRequest, CreateEmbeddingRequestFromRaw>))]
public sealed record class CreateEmbeddingRequest : JsonModel
{
    /// <summary>
    /// Input text to embed, encoded as a string or array of tokens. To embed multiple
    /// inputs in a single request, pass an array of strings or array of token arrays.
    /// The input must not exceed the max input tokens for the model (8192 tokens
    /// for all embedding models), cannot be an empty string, and any array must be
    /// 2048 dimensions or less. [Example Python code](https://cookbook.openai.com/examples/how_to_count_tokens_with_tiktoken)
    /// for counting tokens. In addition to the per-input token limit, all embedding
    ///  models enforce a maximum of 300,000 tokens summed across all inputs in a
    ///  single request.
    /// </summary>
    public required CreateEmbeddingRequestInput Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CreateEmbeddingRequestInput>("input");
        }
        init { this._rawData.Set("input", value); }
    }

    /// <summary>
    /// ID of the model to use. You can use the [List models](/docs/api-reference/models/list)
    /// API to see all of your available models, or see our [Model overview](/docs/models)
    /// for descriptions of them.
    /// </summary>
    public required ApiEnum<string, CreateEmbeddingRequestModel> Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CreateEmbeddingRequestModel>>(
                "model"
            );
        }
        init { this._rawData.Set("model", value); }
    }

    /// <summary>
    /// The number of dimensions the resulting output embeddings should have. Only
    /// supported in `text-embedding-3` and later models.
    /// </summary>
    public long? Dimensions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("dimensions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("dimensions", value);
        }
    }

    /// <summary>
    /// The format to return the embeddings in. Can be either `float` or [`base64`](https://pypi.org/project/pybase64/).
    /// </summary>
    public ApiEnum<string, CreateEmbeddingRequestEncodingFormat>? EncodingFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CreateEmbeddingRequestEncodingFormat>
            >("encoding_format");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("encoding_format", value);
        }
    }

    /// <summary>
    /// A unique identifier representing your end-user, which can help OpenAI to monitor
    /// and detect abuse. [Learn more](/docs/guides/safety-best-practices#end-user-ids).
    /// </summary>
    public string? User
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("user", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Input.Validate();
        this.Model.Raw();
        _ = this.Dimensions;
        this.EncodingFormat?.Validate();
        _ = this.User;
    }

    public CreateEmbeddingRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreateEmbeddingRequest(CreateEmbeddingRequest createEmbeddingRequest)
        : base(createEmbeddingRequest) { }
#pragma warning restore CS8618

    public CreateEmbeddingRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreateEmbeddingRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreateEmbeddingRequestFromRaw.FromRawUnchecked"/>
    public static CreateEmbeddingRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreateEmbeddingRequestFromRaw : IFromRawJson<CreateEmbeddingRequest>
{
    /// <inheritdoc/>
    public CreateEmbeddingRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreateEmbeddingRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Input text to embed, encoded as a string or array of tokens. To embed multiple
/// inputs in a single request, pass an array of strings or array of token arrays.
/// The input must not exceed the max input tokens for the model (8192 tokens for
/// all embedding models), cannot be an empty string, and any array must be 2048 dimensions
/// or less. [Example Python code](https://cookbook.openai.com/examples/how_to_count_tokens_with_tiktoken)
/// for counting tokens. In addition to the per-input token limit, all embedding
/// models enforce a maximum of 300,000 tokens summed across all inputs in a  single request.
/// </summary>
[JsonConverter(typeof(CreateEmbeddingRequestInputConverter))]
public record class CreateEmbeddingRequestInput : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public CreateEmbeddingRequestInput(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateEmbeddingRequestInput(IReadOnlyList<string> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public CreateEmbeddingRequestInput(IReadOnlyList<long> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public CreateEmbeddingRequestInput(
        IReadOnlyList<IReadOnlyList<long>> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(
            Enumerable.Select(value, (item) => ImmutableArray.ToImmutableArray(item))
        );
        this._element = element;
    }

    public CreateEmbeddingRequestInput(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>string</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEmbeddingRequestInputArray(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;string&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEmbeddingRequestInputArray(
        [NotNullWhen(true)] out IReadOnlyList<string>? value
    )
    {
        value = this.Value as IReadOnlyList<string>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>long</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEmbeddingRequestInputArray1(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;long&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEmbeddingRequestInputArray1(
        [NotNullWhen(true)] out IReadOnlyList<long>? value
    )
    {
        value = this.Value as IReadOnlyList<long>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>List&lt;long&gt;</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEmbeddingRequestInputArray2(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;IReadOnlyList&lt;long&gt;&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEmbeddingRequestInputArray2(
        [NotNullWhen(true)] out IReadOnlyList<IReadOnlyList<long>>? value
    )
    {
        value = this.Value as IReadOnlyList<IReadOnlyList<long>>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="DedalusInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) =&gt; {...},
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...},
    ///     (IReadOnlyList&lt;long&gt; value) =&gt; {...},
    ///     (IReadOnlyList&lt;IReadOnlyList&lt;long&gt;&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<IReadOnlyList<string>> embeddingRequestInputArray,
        Action<IReadOnlyList<long>> embeddingRequestInputArray1,
        Action<IReadOnlyList<IReadOnlyList<long>>> embeddingRequestInputArray2
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyList<string> value:
                embeddingRequestInputArray(value);
                break;
            case IReadOnlyList<long> value:
                embeddingRequestInputArray1(value);
                break;
            case IReadOnlyList<IReadOnlyList<long>> value:
                embeddingRequestInputArray2(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of CreateEmbeddingRequestInput"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="DedalusInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) =&gt; {...},
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...},
    ///     (IReadOnlyList&lt;long&gt; value) =&gt; {...},
    ///     (IReadOnlyList&lt;IReadOnlyList&lt;long&gt;&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<IReadOnlyList<string>, T> embeddingRequestInputArray,
        Func<IReadOnlyList<long>, T> embeddingRequestInputArray1,
        Func<IReadOnlyList<IReadOnlyList<long>>, T> embeddingRequestInputArray2
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<string> value => embeddingRequestInputArray(value),
            IReadOnlyList<long> value => embeddingRequestInputArray1(value),
            IReadOnlyList<IReadOnlyList<long>> value => embeddingRequestInputArray2(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of CreateEmbeddingRequestInput"
            ),
        };
    }

    public static implicit operator CreateEmbeddingRequestInput(string value) => new(value);

    public static implicit operator CreateEmbeddingRequestInput(List<string> value) =>
        new((IReadOnlyList<string>)value);

    public static implicit operator CreateEmbeddingRequestInput(List<long> value) =>
        new((IReadOnlyList<long>)value);

    public static implicit operator CreateEmbeddingRequestInput(List<List<long>> value) =>
        new((IReadOnlyList<IReadOnlyList<long>>)value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DedalusInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new DedalusInvalidDataException(
                "Data did not match any variant of CreateEmbeddingRequestInput"
            );
        }
    }

    public virtual bool Equals(CreateEmbeddingRequestInput? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            IReadOnlyList<string> _ => 1,
            IReadOnlyList<long> _ => 2,
            IReadOnlyList<IReadOnlyList<long>> _ => 3,
            _ => -1,
        };
    }
}

sealed class CreateEmbeddingRequestInputConverter : JsonConverter<CreateEmbeddingRequestInput>
{
    public override CreateEmbeddingRequestInput? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<long>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<List<long>>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreateEmbeddingRequestInput value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// ID of the model to use. You can use the [List models](/docs/api-reference/models/list)
/// API to see all of your available models, or see our [Model overview](/docs/models)
/// for descriptions of them.
/// </summary>
[JsonConverter(typeof(CreateEmbeddingRequestModelConverter))]
public enum CreateEmbeddingRequestModel
{
    TextEmbeddingAda002,
    TextEmbedding3Small,
    TextEmbedding3Large,
}

sealed class CreateEmbeddingRequestModelConverter : JsonConverter<CreateEmbeddingRequestModel>
{
    public override CreateEmbeddingRequestModel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text-embedding-ada-002" => CreateEmbeddingRequestModel.TextEmbeddingAda002,
            "text-embedding-3-small" => CreateEmbeddingRequestModel.TextEmbedding3Small,
            "text-embedding-3-large" => CreateEmbeddingRequestModel.TextEmbedding3Large,
            _ => (CreateEmbeddingRequestModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreateEmbeddingRequestModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreateEmbeddingRequestModel.TextEmbeddingAda002 => "text-embedding-ada-002",
                CreateEmbeddingRequestModel.TextEmbedding3Small => "text-embedding-3-small",
                CreateEmbeddingRequestModel.TextEmbedding3Large => "text-embedding-3-large",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The format to return the embeddings in. Can be either `float` or [`base64`](https://pypi.org/project/pybase64/).
/// </summary>
[JsonConverter(typeof(CreateEmbeddingRequestEncodingFormatConverter))]
public enum CreateEmbeddingRequestEncodingFormat
{
    Float,
    Base64,
}

sealed class CreateEmbeddingRequestEncodingFormatConverter
    : JsonConverter<CreateEmbeddingRequestEncodingFormat>
{
    public override CreateEmbeddingRequestEncodingFormat Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "float" => CreateEmbeddingRequestEncodingFormat.Float,
            "base64" => CreateEmbeddingRequestEncodingFormat.Base64,
            _ => (CreateEmbeddingRequestEncodingFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreateEmbeddingRequestEncodingFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreateEmbeddingRequestEncodingFormat.Float => "float",
                CreateEmbeddingRequestEncodingFormat.Base64 => "base64",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
