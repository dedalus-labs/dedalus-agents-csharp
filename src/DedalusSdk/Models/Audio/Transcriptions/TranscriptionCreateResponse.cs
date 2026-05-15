using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using Completions = DedalusSdk.Models.Chat.Completions;

namespace DedalusSdk.Models.Audio.Transcriptions;

/// <summary>
/// Represents a verbose json transcription response returned by model, based on the
/// provided input.
///
/// <para>Fields:   - language (required): str   - duration (required): float   -
/// text (required): str   - words (optional): list[TranscriptionWord]   - segments
/// (optional): list[TranscriptionSegment]   - usage (optional): TranscriptTextUsageDuration</para>
/// </summary>
[JsonConverter(typeof(TranscriptionCreateResponseConverter))]
public record class TranscriptionCreateResponse : ModelBase
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
                createTranscriptionResponseVerboseJson: (x) => x.Text,
                createTranscriptionResponseJson: (x) => x.Text
            );
        }
    }

    public TranscriptionCreateResponse(
        CreateTranscriptionResponseVerboseJson value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionCreateResponse(
        CreateTranscriptionResponseJson value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionCreateResponse(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreateTranscriptionResponseVerboseJson"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreateTranscriptionResponseVerboseJson(out var value)) {
    ///     // `value` is of type `CreateTranscriptionResponseVerboseJson`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreateTranscriptionResponseVerboseJson(
        [NotNullWhen(true)] out CreateTranscriptionResponseVerboseJson? value
    )
    {
        value = this.Value as CreateTranscriptionResponseVerboseJson;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreateTranscriptionResponseJson"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreateTranscriptionResponseJson(out var value)) {
    ///     // `value` is of type `CreateTranscriptionResponseJson`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreateTranscriptionResponseJson(
        [NotNullWhen(true)] out CreateTranscriptionResponseJson? value
    )
    {
        value = this.Value as CreateTranscriptionResponseJson;
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
    ///     (CreateTranscriptionResponseVerboseJson value) =&gt; {...},
    ///     (CreateTranscriptionResponseJson value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<CreateTranscriptionResponseVerboseJson> createTranscriptionResponseVerboseJson,
        Action<CreateTranscriptionResponseJson> createTranscriptionResponseJson
    )
    {
        switch (this.Value)
        {
            case CreateTranscriptionResponseVerboseJson value:
                createTranscriptionResponseVerboseJson(value);
                break;
            case CreateTranscriptionResponseJson value:
                createTranscriptionResponseJson(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of TranscriptionCreateResponse"
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
    ///     (CreateTranscriptionResponseVerboseJson value) =&gt; {...},
    ///     (CreateTranscriptionResponseJson value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<CreateTranscriptionResponseVerboseJson, T> createTranscriptionResponseVerboseJson,
        Func<CreateTranscriptionResponseJson, T> createTranscriptionResponseJson
    )
    {
        return this.Value switch
        {
            CreateTranscriptionResponseVerboseJson value => createTranscriptionResponseVerboseJson(
                value
            ),
            CreateTranscriptionResponseJson value => createTranscriptionResponseJson(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of TranscriptionCreateResponse"
            ),
        };
    }

    public static implicit operator TranscriptionCreateResponse(
        CreateTranscriptionResponseVerboseJson value
    ) => new(value);

    public static implicit operator TranscriptionCreateResponse(
        CreateTranscriptionResponseJson value
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
                "Data did not match any variant of TranscriptionCreateResponse"
            );
        }
        this.Switch(
            (createTranscriptionResponseVerboseJson) =>
                createTranscriptionResponseVerboseJson.Validate(),
            (createTranscriptionResponseJson) => createTranscriptionResponseJson.Validate()
        );
    }

    public virtual bool Equals(TranscriptionCreateResponse? other) =>
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
            CreateTranscriptionResponseVerboseJson _ => 0,
            CreateTranscriptionResponseJson _ => 1,
            _ => -1,
        };
    }
}

sealed class TranscriptionCreateResponseConverter : JsonConverter<TranscriptionCreateResponse>
{
    public override TranscriptionCreateResponse? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<CreateTranscriptionResponseVerboseJson>(
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
            var deserialized = JsonSerializer.Deserialize<CreateTranscriptionResponseJson>(
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
        TranscriptionCreateResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Represents a verbose json transcription response returned by model, based on the
/// provided input.
///
/// <para>Fields:   - language (required): str   - duration (required): float   -
/// text (required): str   - words (optional): list[TranscriptionWord]   - segments
/// (optional): list[TranscriptionSegment]   - usage (optional): TranscriptTextUsageDuration</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CreateTranscriptionResponseVerboseJson,
        CreateTranscriptionResponseVerboseJsonFromRaw
    >)
)]
public sealed record class CreateTranscriptionResponseVerboseJson : JsonModel
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
    /// The language of the input audio.
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
    /// The transcribed text.
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
    /// Segments of the transcribed text and their corresponding details.
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

    /// <summary>
    /// Usage statistics for models billed by audio input duration.
    /// </summary>
    public Usage? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Usage>("usage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usage", value);
        }
    }

    /// <summary>
    /// Extracted words and their corresponding timestamps.
    /// </summary>
    public IReadOnlyList<Word>? Words
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Word>>("words");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Word>?>(
                "words",
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
        this.Usage?.Validate();
        foreach (var item in this.Words ?? [])
        {
            item.Validate();
        }
    }

    public CreateTranscriptionResponseVerboseJson() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreateTranscriptionResponseVerboseJson(
        CreateTranscriptionResponseVerboseJson createTranscriptionResponseVerboseJson
    )
        : base(createTranscriptionResponseVerboseJson) { }
#pragma warning restore CS8618

    public CreateTranscriptionResponseVerboseJson(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreateTranscriptionResponseVerboseJson(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreateTranscriptionResponseVerboseJsonFromRaw.FromRawUnchecked"/>
    public static CreateTranscriptionResponseVerboseJson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreateTranscriptionResponseVerboseJsonFromRaw
    : IFromRawJson<CreateTranscriptionResponseVerboseJson>
{
    /// <inheritdoc/>
    public CreateTranscriptionResponseVerboseJson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreateTranscriptionResponseVerboseJson.FromRawUnchecked(rawData);
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
/// Usage statistics for models billed by audio input duration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Usage, UsageFromRaw>))]
public sealed record class Usage : JsonModel
{
    /// <summary>
    /// Duration of the input audio in seconds.
    /// </summary>
    public required double Seconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("seconds");
        }
        init { this._rawData.Set("seconds", value); }
    }

    /// <summary>
    /// The type of the usage object. Always `duration` for this variant.
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
        _ = this.Seconds;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("duration")))
        {
            throw new DedalusInvalidDataException("Invalid value given for constant");
        }
    }

    public Usage()
    {
        this.Type = JsonSerializer.SerializeToElement("duration");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Usage(Usage usage)
        : base(usage) { }
#pragma warning restore CS8618

    public Usage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("duration");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageFromRaw.FromRawUnchecked"/>
    public static Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Usage(double seconds)
        : this()
    {
        this.Seconds = seconds;
    }
}

class UsageFromRaw : IFromRawJson<Usage>
{
    /// <inheritdoc/>
    public Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Usage.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields:  # noqa: D415.
///
/// <para>- word (required): str - start (required): float - end (required): float</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Word, WordFromRaw>))]
public sealed record class Word : JsonModel
{
    /// <summary>
    /// End time of the word in seconds.
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
    /// Start time of the word in seconds.
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
    /// The text content of the word.
    /// </summary>
    public required string WordValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("word");
        }
        init { this._rawData.Set("word", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.End;
        _ = this.Start;
        _ = this.WordValue;
    }

    public Word() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Word(Word word)
        : base(word) { }
#pragma warning restore CS8618

    public Word(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Word(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WordFromRaw.FromRawUnchecked"/>
    public static Word FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WordFromRaw : IFromRawJson<Word>
{
    /// <inheritdoc/>
    public Word FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Word.FromRawUnchecked(rawData);
}

/// <summary>
/// Represents a transcription response returned by model, based on the provided input.
///
/// <para>Fields:   - text (required): str   - logprobs (optional): list[LogprobsItem]
///   - usage (optional): Usage</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CreateTranscriptionResponseJson,
        CreateTranscriptionResponseJsonFromRaw
    >)
)]
public sealed record class CreateTranscriptionResponseJson : JsonModel
{
    /// <summary>
    /// The transcribed text.
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
    /// The log probabilities of the tokens in the transcription. Only returned with
    /// the models `gpt-4o-transcribe` and `gpt-4o-mini-transcribe` if `logprobs`
    /// is added to the `include` array.
    /// </summary>
    public IReadOnlyList<Logprob>? Logprobs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Logprob>>("logprobs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Logprob>?>(
                "logprobs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Token usage statistics for the request.
    /// </summary>
    public CreateTranscriptionResponseJsonUsage? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreateTranscriptionResponseJsonUsage>("usage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usage", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        foreach (var item in this.Logprobs ?? [])
        {
            item.Validate();
        }
        this.Usage?.Validate();
    }

    public CreateTranscriptionResponseJson() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreateTranscriptionResponseJson(
        CreateTranscriptionResponseJson createTranscriptionResponseJson
    )
        : base(createTranscriptionResponseJson) { }
#pragma warning restore CS8618

    public CreateTranscriptionResponseJson(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreateTranscriptionResponseJson(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreateTranscriptionResponseJsonFromRaw.FromRawUnchecked"/>
    public static CreateTranscriptionResponseJson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CreateTranscriptionResponseJson(string text)
        : this()
    {
        this.Text = text;
    }
}

class CreateTranscriptionResponseJsonFromRaw : IFromRawJson<CreateTranscriptionResponseJson>
{
    /// <inheritdoc/>
    public CreateTranscriptionResponseJson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreateTranscriptionResponseJson.FromRawUnchecked(rawData);
}

/// <summary>
/// Fields:  # noqa: D415.
///
/// <para>- token (optional): str - logprob (optional): float - bytes (optional): list[float]</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Logprob, LogprobFromRaw>))]
public sealed record class Logprob : JsonModel
{
    /// <summary>
    /// The token in the transcription.
    /// </summary>
    public string? Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("token");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("token", value);
        }
    }

    /// <summary>
    /// The bytes of the token.
    /// </summary>
    public IReadOnlyList<double>? Bytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<double>>("bytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<double>?>(
                "bytes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The log probability of the token.
    /// </summary>
    public double? LogprobValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("logprob");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("logprob", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Token;
        _ = this.Bytes;
        _ = this.LogprobValue;
    }

    public Logprob() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Logprob(Logprob logprob)
        : base(logprob) { }
#pragma warning restore CS8618

    public Logprob(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Logprob(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LogprobFromRaw.FromRawUnchecked"/>
    public static Logprob FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LogprobFromRaw : IFromRawJson<Logprob>
{
    /// <inheritdoc/>
    public Logprob FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Logprob.FromRawUnchecked(rawData);
}

/// <summary>
/// Token usage statistics for the request.
/// </summary>
[JsonConverter(typeof(CreateTranscriptionResponseJsonUsageConverter))]
public record class CreateTranscriptionResponseJsonUsage : ModelBase
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

    public JsonElement Type
    {
        get { return Match(tokens: (x) => x.Type, duration: (x) => x.Type); }
    }

    public CreateTranscriptionResponseJsonUsage(Tokens value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateTranscriptionResponseJsonUsage(Duration value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateTranscriptionResponseJsonUsage(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Tokens"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTokens(out var value)) {
    ///     // `value` is of type `Tokens`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTokens([NotNullWhen(true)] out Tokens? value)
    {
        value = this.Value as Tokens;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Duration"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDuration(out var value)) {
    ///     // `value` is of type `Duration`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDuration([NotNullWhen(true)] out Duration? value)
    {
        value = this.Value as Duration;
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
    ///     (Tokens value) =&gt; {...},
    ///     (Duration value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<Tokens> tokens, Action<Duration> duration)
    {
        switch (this.Value)
        {
            case Tokens value:
                tokens(value);
                break;
            case Duration value:
                duration(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of CreateTranscriptionResponseJsonUsage"
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
    ///     (Tokens value) =&gt; {...},
    ///     (Duration value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<Tokens, T> tokens, Func<Duration, T> duration)
    {
        return this.Value switch
        {
            Tokens value => tokens(value),
            Duration value => duration(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of CreateTranscriptionResponseJsonUsage"
            ),
        };
    }

    public static implicit operator CreateTranscriptionResponseJsonUsage(Tokens value) =>
        new(value);

    public static implicit operator CreateTranscriptionResponseJsonUsage(Duration value) =>
        new(value);

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
                "Data did not match any variant of CreateTranscriptionResponseJsonUsage"
            );
        }
        this.Switch((tokens) => tokens.Validate(), (duration) => duration.Validate());
    }

    public virtual bool Equals(CreateTranscriptionResponseJsonUsage? other) =>
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
            Tokens _ => 0,
            Duration _ => 1,
            _ => -1,
        };
    }
}

sealed class CreateTranscriptionResponseJsonUsageConverter
    : JsonConverter<CreateTranscriptionResponseJsonUsage>
{
    public override CreateTranscriptionResponseJsonUsage? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "tokens":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Tokens>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "duration":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Duration>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new CreateTranscriptionResponseJsonUsage(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreateTranscriptionResponseJsonUsage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Usage statistics for models billed by token usage.
///
/// <para>Fields:   - type (required): Literal['tokens']   - input_tokens (required):
/// int   - input_token_details (optional): InputTokenDetails   - output_tokens (required):
/// int   - total_tokens (required): int</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Tokens, TokensFromRaw>))]
public sealed record class Tokens : JsonModel
{
    /// <summary>
    /// Number of input tokens billed for this request.
    /// </summary>
    public required long InputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("input_tokens");
        }
        init { this._rawData.Set("input_tokens", value); }
    }

    /// <summary>
    /// Number of output tokens generated.
    /// </summary>
    public required long OutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("output_tokens");
        }
        init { this._rawData.Set("output_tokens", value); }
    }

    /// <summary>
    /// Total number of tokens used (input + output).
    /// </summary>
    public required long TotalTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_tokens");
        }
        init { this._rawData.Set("total_tokens", value); }
    }

    /// <summary>
    /// The type of the usage object. Always `tokens` for this variant.
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

    /// <summary>
    /// Details about the input tokens billed for this request.
    /// </summary>
    public Completions::InputTokenDetails? InputTokenDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Completions::InputTokenDetails>(
                "input_token_details"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("input_token_details", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InputTokens;
        _ = this.OutputTokens;
        _ = this.TotalTokens;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tokens")))
        {
            throw new DedalusInvalidDataException("Invalid value given for constant");
        }
        this.InputTokenDetails?.Validate();
    }

    public Tokens()
    {
        this.Type = JsonSerializer.SerializeToElement("tokens");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Tokens(Tokens tokens)
        : base(tokens) { }
#pragma warning restore CS8618

    public Tokens(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tokens");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tokens(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TokensFromRaw.FromRawUnchecked"/>
    public static Tokens FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TokensFromRaw : IFromRawJson<Tokens>
{
    /// <inheritdoc/>
    public Tokens FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tokens.FromRawUnchecked(rawData);
}

/// <summary>
/// Usage statistics for models billed by audio input duration.
///
/// <para>Fields:   - type (required): Literal['duration']   - seconds (required): float</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Duration, DurationFromRaw>))]
public sealed record class Duration : JsonModel
{
    /// <summary>
    /// Duration of the input audio in seconds.
    /// </summary>
    public required double Seconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("seconds");
        }
        init { this._rawData.Set("seconds", value); }
    }

    /// <summary>
    /// The type of the usage object. Always `duration` for this variant.
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
        _ = this.Seconds;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("duration")))
        {
            throw new DedalusInvalidDataException("Invalid value given for constant");
        }
    }

    public Duration()
    {
        this.Type = JsonSerializer.SerializeToElement("duration");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Duration(Duration duration)
        : base(duration) { }
#pragma warning restore CS8618

    public Duration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("duration");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Duration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DurationFromRaw.FromRawUnchecked"/>
    public static Duration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Duration(double seconds)
        : this()
    {
        this.Seconds = seconds;
    }
}

class DurationFromRaw : IFromRawJson<Duration>
{
    /// <inheritdoc/>
    public Duration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Duration.FromRawUnchecked(rawData);
}
