using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;

namespace DedalusSdk.Models.Audio.Translations;

/// <summary>
/// Fields:  # noqa: D415.
///
/// <para>- language (required): str - duration (required): float - text (required):
/// str - segments (optional): list[TranscriptionSegment]</para>
/// </summary>
[JsonConverter(typeof(TranslationCreateResponseConverter))]
public record class TranslationCreateResponse : ModelBase
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

    public string Text
    {
        get
        {
            return Match(
                createTranslationResponseVerboseJson: (x) => x.Text,
                createTranslationResponseJson: (x) => x.Text
            );
        }
    }

    public TranslationCreateResponse(
        CreateTranslationResponseVerboseJson value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranslationCreateResponse(
        CreateTranslationResponseJson value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranslationCreateResponse(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreateTranslationResponseVerboseJson"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreateTranslationResponseVerboseJson(out var value)) {
    ///     // `value` is of type `CreateTranslationResponseVerboseJson`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreateTranslationResponseVerboseJson(
        [NotNullWhen(true)] out CreateTranslationResponseVerboseJson? value
    )
    {
        value = this.Value as CreateTranslationResponseVerboseJson;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreateTranslationResponseJson"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreateTranslationResponseJson(out var value)) {
    ///     // `value` is of type `CreateTranslationResponseJson`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreateTranslationResponseJson(
        [NotNullWhen(true)] out CreateTranslationResponseJson? value
    )
    {
        value = this.Value as CreateTranslationResponseJson;
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
    ///     (CreateTranslationResponseVerboseJson value) =&gt; {...},
    ///     (CreateTranslationResponseJson value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<CreateTranslationResponseVerboseJson> createTranslationResponseVerboseJson,
        Action<CreateTranslationResponseJson> createTranslationResponseJson
    )
    {
        switch (this.Value)
        {
            case CreateTranslationResponseVerboseJson value:
                createTranslationResponseVerboseJson(value);
                break;
            case CreateTranslationResponseJson value:
                createTranslationResponseJson(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of TranslationCreateResponse"
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
    ///     (CreateTranslationResponseVerboseJson value) =&gt; {...},
    ///     (CreateTranslationResponseJson value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<CreateTranslationResponseVerboseJson, T> createTranslationResponseVerboseJson,
        Func<CreateTranslationResponseJson, T> createTranslationResponseJson
    )
    {
        return this.Value switch
        {
            CreateTranslationResponseVerboseJson value => createTranslationResponseVerboseJson(
                value
            ),
            CreateTranslationResponseJson value => createTranslationResponseJson(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of TranslationCreateResponse"
            ),
        };
    }

    public static implicit operator TranslationCreateResponse(
        CreateTranslationResponseVerboseJson value
    ) => new(value);

    public static implicit operator TranslationCreateResponse(
        CreateTranslationResponseJson value
    ) => new(value);

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
                "Data did not match any variant of TranslationCreateResponse"
            );
        }
        this.Switch(
            (createTranslationResponseVerboseJson) =>
                createTranslationResponseVerboseJson.Validate(),
            (createTranslationResponseJson) => createTranslationResponseJson.Validate()
        );
    }

    public virtual bool Equals(TranslationCreateResponse? other) =>
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
            CreateTranslationResponseVerboseJson _ => 0,
            CreateTranslationResponseJson _ => 1,
            _ => -1,
        };
    }
}

sealed class TranslationCreateResponseConverter : JsonConverter<TranslationCreateResponse>
{
    public override TranslationCreateResponse? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<CreateTranslationResponseVerboseJson>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CreateTranslationResponseJson>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
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
        TranslationCreateResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Fields:  # noqa: D415.
///
/// <para>- language (required): str - duration (required): float - text (required):
/// str - segments (optional): list[TranscriptionSegment]</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CreateTranslationResponseVerboseJson,
        CreateTranslationResponseVerboseJsonFromRaw
    >)
)]
public sealed record class CreateTranslationResponseVerboseJson : JsonModel
{
    /// <summary>
    /// The duration of the input audio.
    /// </summary>
    public required double Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("duration");
        }
        init { this._rawData.Set("duration", value); }
    }

    /// <summary>
    /// The language of the output translation (always `english`).
    /// </summary>
    public required string Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("language");
        }
        init { this._rawData.Set("language", value); }
    }

    /// <summary>
    /// The translated text.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// Segments of the translated text and their corresponding details.
    /// </summary>
    public IReadOnlyList<Segment>? Segments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Segment>>("segments");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Segment>?>(
                "segments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Duration;
        _ = this.Language;
        _ = this.Text;
        foreach (var item in this.Segments ?? [])
        {
            item.Validate();
        }
    }

    public CreateTranslationResponseVerboseJson() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreateTranslationResponseVerboseJson(
        CreateTranslationResponseVerboseJson createTranslationResponseVerboseJson
    )
        : base(createTranslationResponseVerboseJson) { }
#pragma warning restore CS8618

    public CreateTranslationResponseVerboseJson(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreateTranslationResponseVerboseJson(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreateTranslationResponseVerboseJsonFromRaw.FromRawUnchecked"/>
    public static CreateTranslationResponseVerboseJson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreateTranslationResponseVerboseJsonFromRaw
    : IFromRawJson<CreateTranslationResponseVerboseJson>
{
    /// <inheritdoc/>
    public CreateTranslationResponseVerboseJson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreateTranslationResponseVerboseJson.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields:  # noqa: D415.
///
/// <para>- id (required): int - seek (required): int - start (required): float -
/// end (required): float - text (required): str - tokens (required): list[int] -
/// temperature (required): float - avg_logprob (required): float - compression_ratio
/// (required): float - no_speech_prob (required): float</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Segment, SegmentFromRaw>))]
public sealed record class Segment : JsonModel
{
    /// <summary>
    /// Unique identifier of the segment.
    /// </summary>
    public required long ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Average logprob of the segment. If the value is lower than -1, consider the
    /// logprobs failed.
    /// </summary>
    public required double AvgLogprob
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("avg_logprob");
        }
        init { this._rawData.Set("avg_logprob", value); }
    }

    /// <summary>
    /// Compression ratio of the segment. If the value is greater than 2.4, consider
    /// the compression failed.
    /// </summary>
    public required double CompressionRatio
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("compression_ratio");
        }
        init { this._rawData.Set("compression_ratio", value); }
    }

    /// <summary>
    /// End time of the segment in seconds.
    /// </summary>
    public required double End
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("end");
        }
        init { this._rawData.Set("end", value); }
    }

    /// <summary>
    /// Probability of no speech in the segment. If the value is higher than 1.0
    /// and the `avg_logprob` is below -1, consider this segment silent.
    /// </summary>
    public required double NoSpeechProb
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("no_speech_prob");
        }
        init { this._rawData.Set("no_speech_prob", value); }
    }

    /// <summary>
    /// Seek offset of the segment.
    /// </summary>
    public required long Seek
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("seek");
        }
        init { this._rawData.Set("seek", value); }
    }

    /// <summary>
    /// Start time of the segment in seconds.
    /// </summary>
    public required double Start
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("start");
        }
        init { this._rawData.Set("start", value); }
    }

    /// <summary>
    /// Temperature parameter used for generating the segment.
    /// </summary>
    public required double Temperature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("temperature");
        }
        init { this._rawData.Set("temperature", value); }
    }

    /// <summary>
    /// Text content of the segment.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// Array of token IDs for the text content.
    /// </summary>
    public required IReadOnlyList<long> Tokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<long>>("tokens");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>>(
                "tokens",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AvgLogprob;
        _ = this.CompressionRatio;
        _ = this.End;
        _ = this.NoSpeechProb;
        _ = this.Seek;
        _ = this.Start;
        _ = this.Temperature;
        _ = this.Text;
        _ = this.Tokens;
    }

    public Segment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Segment(Segment segment)
        : base(segment) { }
#pragma warning restore CS8618

    public Segment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Segment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SegmentFromRaw.FromRawUnchecked"/>
    public static Segment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SegmentFromRaw : IFromRawJson<Segment>
{
    /// <inheritdoc/>
    public Segment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Segment.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields:  # noqa: D415.
///
/// <para>- text (required): str</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CreateTranslationResponseJson, CreateTranslationResponseJsonFromRaw>)
)]
public sealed record class CreateTranslationResponseJson : JsonModel
{
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
    }

    public CreateTranslationResponseJson() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreateTranslationResponseJson(
        CreateTranslationResponseJson createTranslationResponseJson
    )
        : base(createTranslationResponseJson) { }
#pragma warning restore CS8618

    public CreateTranslationResponseJson(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreateTranslationResponseJson(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreateTranslationResponseJsonFromRaw.FromRawUnchecked"/>
    public static CreateTranslationResponseJson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CreateTranslationResponseJson(string text)
        : this()
    {
        this.Text = text;
    }
}

class CreateTranslationResponseJsonFromRaw : IFromRawJson<CreateTranslationResponseJson>
{
    /// <inheritdoc/>
    public CreateTranslationResponseJson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreateTranslationResponseJson.FromRawUnchecked(rawData);
}
