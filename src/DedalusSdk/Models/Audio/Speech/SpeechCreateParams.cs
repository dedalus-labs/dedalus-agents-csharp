using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;

namespace DedalusSdk.Models.Audio.Speech;

/// <summary>
/// Generate speech audio from text.
///
/// <para>Generates audio from the input text using text-to-speech models. Supports
/// multiple voices and output formats including mp3, opus, aac, flac, wav, and pcm.</para>
///
/// <para>Returns streaming audio data that can be saved to a file or streamed directly
/// to users.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SpeechCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The text to generate audio for. The maximum length is 4096 characters.
    /// </summary>
    public required string Input
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("input");
        }
        init { this._rawBodyData.Set("input", value); }
    }

    /// <summary>
    /// One of the available [TTS models](/docs/models#tts): `tts-1`, `tts-1-hd`,
    /// `gpt-4o-mini-tts`, or `gpt-4o-mini-tts-2025-12-15`.
    /// </summary>
    public required ApiEnum<string, Model> Model
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Model>>("model");
        }
        init { this._rawBodyData.Set("model", value); }
    }

    /// <summary>
    /// The voice to use when generating the audio. Supported built-in voices are
    /// `alloy`, `ash`, `ballad`, `coral`, `echo`, `fable`, `onyx`, `nova`, `sage`,
    /// `shimmer`, `verse`, `marin`, and `cedar`. You may also provide a custom voice
    /// object with an `id`, for example `{ "id": "voice_1234" }`. Previews of the
    /// voices are available in the [Text to speech guide](/docs/guides/text-to-speech#voice-options).
    /// </summary>
    public required Voice Voice
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Voice>("voice");
        }
        init { this._rawBodyData.Set("voice", value); }
    }

    /// <summary>
    /// Control the voice of your generated audio with additional instructions. Does
    /// not work with `tts-1` or `tts-1-hd`.
    /// </summary>
    public string? Instructions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("instructions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("instructions", value);
        }
    }

    /// <summary>
    /// The format to audio in. Supported formats are `mp3`, `opus`, `aac`, `flac`,
    /// `wav`, and `pcm`.
    /// </summary>
    public ApiEnum<string, ResponseFormat>? ResponseFormat
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ResponseFormat>>(
                "response_format"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("response_format", value);
        }
    }

    /// <summary>
    /// The speed of the generated audio. Select a value from `0.25` to `4.0`. `1.0`
    /// is the default.
    /// </summary>
    public double? Speed
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("speed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("speed", value);
        }
    }

    /// <summary>
    /// The format to stream the audio in. Supported formats are `sse` and `audio`.
    /// `sse` is not supported for `tts-1` or `tts-1-hd`.
    /// </summary>
    public ApiEnum<string, StreamFormat>? StreamFormat
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, StreamFormat>>(
                "stream_format"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("stream_format", value);
        }
    }

    public SpeechCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpeechCreateParams(SpeechCreateParams speechCreateParams)
        : base(speechCreateParams)
    {
        this._rawBodyData = new(speechCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SpeechCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpeechCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SpeechCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SpeechCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/audio/speech")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        request.Headers.Add("Accept", "audio/mpeg");
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// One of the available [TTS models](/docs/models#tts): `tts-1`, `tts-1-hd`, `gpt-4o-mini-tts`,
/// or `gpt-4o-mini-tts-2025-12-15`.
/// </summary>
[JsonConverter(typeof(ModelConverter))]
public enum Model
{
    Tts1,
    Tts1HD,
    Gpt4oMiniTts,
    Gpt4oMiniTts2025_12_15,
}

sealed class ModelConverter : JsonConverter<Model>
{
    public override Model Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tts-1" => Model.Tts1,
            "tts-1-hd" => Model.Tts1HD,
            "gpt-4o-mini-tts" => Model.Gpt4oMiniTts,
            "gpt-4o-mini-tts-2025-12-15" => Model.Gpt4oMiniTts2025_12_15,
            _ => (Model)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Model value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Model.Tts1 => "tts-1",
                Model.Tts1HD => "tts-1-hd",
                Model.Gpt4oMiniTts => "gpt-4o-mini-tts",
                Model.Gpt4oMiniTts2025_12_15 => "gpt-4o-mini-tts-2025-12-15",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The voice to use when generating the audio. Supported built-in voices are `alloy`,
/// `ash`, `ballad`, `coral`, `echo`, `fable`, `onyx`, `nova`, `sage`, `shimmer`,
/// `verse`, `marin`, and `cedar`. You may also provide a custom voice object with
/// an `id`, for example `{ "id": "voice_1234" }`. Previews of the voices are available
/// in the [Text to speech guide](/docs/guides/text-to-speech#voice-options).
/// </summary>
[JsonConverter(typeof(VoiceConverter))]
public record class Voice : ModelBase
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

    public Voice(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Voice(ApiEnum<string, UnionMember1> value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Voice(VoiceIdsOrCustomVoice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Voice(JsonElement element)
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
    /// type <see cref="ApiEnum{TRaw, TEnum}"/> with a <c>TRaw</c> of <c>string</c> and a <c>TEnum</c> of UnionMember1>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember1(out var value)) {
    ///     // `value` is of type `ApiEnum&lt;string, UnionMember1&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember1([NotNullWhen(true)] out ApiEnum<string, UnionMember1>? value)
    {
        value = this.Value as ApiEnum<string, UnionMember1>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VoiceIdsOrCustomVoice"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickIdsOrCustom(out var value)) {
    ///     // `value` is of type `VoiceIdsOrCustomVoice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickIdsOrCustom([NotNullWhen(true)] out VoiceIdsOrCustomVoice? value)
    {
        value = this.Value as VoiceIdsOrCustomVoice;
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
    ///     (ApiEnum&lt;string, UnionMember1&gt; value) =&gt; {...},
    ///     (VoiceIdsOrCustomVoice value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<ApiEnum<string, UnionMember1>> unionMember1,
        Action<VoiceIdsOrCustomVoice> idsOrCustom
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case ApiEnum<string, UnionMember1> value:
                unionMember1(value);
                break;
            case VoiceIdsOrCustomVoice value:
                idsOrCustom(value);
                break;
            default:
                throw new DedalusInvalidDataException("Data did not match any variant of Voice");
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
    ///     (ApiEnum&lt;string, UnionMember1&gt; value) =&gt; {...},
    ///     (VoiceIdsOrCustomVoice value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<ApiEnum<string, UnionMember1>, T> unionMember1,
        Func<VoiceIdsOrCustomVoice, T> idsOrCustom
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            ApiEnum<string, UnionMember1> value => unionMember1(value),
            VoiceIdsOrCustomVoice value => idsOrCustom(value),
            _ => throw new DedalusInvalidDataException("Data did not match any variant of Voice"),
        };
    }

    public static implicit operator Voice(string value) => new(value);

    public static implicit operator Voice(ApiEnum<string, UnionMember1> value) => new(value);

    public static implicit operator Voice(UnionMember1 value) => new(value);

    public static implicit operator Voice(VoiceIdsOrCustomVoice value) => new(value);

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
            throw new DedalusInvalidDataException("Data did not match any variant of Voice");
        }
        this.Switch(
            (_) => { },
            (unionMember1) => unionMember1.Validate(),
            (idsOrCustom) => idsOrCustom.Validate()
        );
    }

    public virtual bool Equals(Voice? other) =>
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
            ApiEnum<string, UnionMember1> _ => 1,
            VoiceIdsOrCustomVoice _ => 2,
            _ => -1,
        };
    }
}

sealed class VoiceConverter : JsonConverter<Voice>
{
    public override Voice? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1>>(
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
            var deserialized = JsonSerializer.Deserialize<VoiceIdsOrCustomVoice>(element, options);
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

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Voice value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(UnionMember1Converter))]
public enum UnionMember1
{
    Alloy,
    Ash,
    Ballad,
    Coral,
    Echo,
    Sage,
    Shimmer,
    Verse,
    Marin,
    Cedar,
}

sealed class UnionMember1Converter : JsonConverter<UnionMember1>
{
    public override UnionMember1 Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "alloy" => UnionMember1.Alloy,
            "ash" => UnionMember1.Ash,
            "ballad" => UnionMember1.Ballad,
            "coral" => UnionMember1.Coral,
            "echo" => UnionMember1.Echo,
            "sage" => UnionMember1.Sage,
            "shimmer" => UnionMember1.Shimmer,
            "verse" => UnionMember1.Verse,
            "marin" => UnionMember1.Marin,
            "cedar" => UnionMember1.Cedar,
            _ => (UnionMember1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionMember1.Alloy => "alloy",
                UnionMember1.Ash => "ash",
                UnionMember1.Ballad => "ballad",
                UnionMember1.Coral => "coral",
                UnionMember1.Echo => "echo",
                UnionMember1.Sage => "sage",
                UnionMember1.Shimmer => "shimmer",
                UnionMember1.Verse => "verse",
                UnionMember1.Marin => "marin",
                UnionMember1.Cedar => "cedar",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The format to audio in. Supported formats are `mp3`, `opus`, `aac`, `flac`, `wav`,
/// and `pcm`.
/// </summary>
[JsonConverter(typeof(ResponseFormatConverter))]
public enum ResponseFormat
{
    Mp3,
    Opus,
    Aac,
    Flac,
    Wav,
    Pcm,
}

sealed class ResponseFormatConverter : JsonConverter<ResponseFormat>
{
    public override ResponseFormat Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mp3" => ResponseFormat.Mp3,
            "opus" => ResponseFormat.Opus,
            "aac" => ResponseFormat.Aac,
            "flac" => ResponseFormat.Flac,
            "wav" => ResponseFormat.Wav,
            "pcm" => ResponseFormat.Pcm,
            _ => (ResponseFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResponseFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ResponseFormat.Mp3 => "mp3",
                ResponseFormat.Opus => "opus",
                ResponseFormat.Aac => "aac",
                ResponseFormat.Flac => "flac",
                ResponseFormat.Wav => "wav",
                ResponseFormat.Pcm => "pcm",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The format to stream the audio in. Supported formats are `sse` and `audio`. `sse`
/// is not supported for `tts-1` or `tts-1-hd`.
/// </summary>
[JsonConverter(typeof(StreamFormatConverter))]
public enum StreamFormat
{
    Sse,
    Audio,
}

sealed class StreamFormatConverter : JsonConverter<StreamFormat>
{
    public override StreamFormat Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sse" => StreamFormat.Sse,
            "audio" => StreamFormat.Audio,
            _ => (StreamFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StreamFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StreamFormat.Sse => "sse",
                StreamFormat.Audio => "audio",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
