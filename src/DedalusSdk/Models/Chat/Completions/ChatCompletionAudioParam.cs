using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using System = System;

namespace DedalusSdk.Models.Chat.Completions;

/// <summary>
/// Parameters for audio output. Required when audio output is requested with `modalities:
/// ["audio"]`. [Learn more](/docs/guides/audio).
///
/// <para>Fields: - voice (required): VoiceIdsOrCustomVoice - format (required):
/// Literal["wav", "aac", "mp3", "flac", "opus", "pcm16"]</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ChatCompletionAudioParam, ChatCompletionAudioParamFromRaw>)
)]
public sealed record class ChatCompletionAudioParam : JsonModel
{
    /// <summary>
    /// Specifies the output audio format. Must be one of `wav`, `mp3`, `flac`, `opus`,
    /// or `pcm16`.
    /// </summary>
    public required ApiEnum<string, Format> Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Format>>("format");
        }
        init { this._rawData.Set("format", value); }
    }

    /// <summary>
    /// The voice the model uses to respond. Supported built-in voices are `alloy`,
    /// `ash`, `ballad`, `coral`, `echo`, `fable`, `nova`, `onyx`, `sage`, `shimmer`,
    /// `marin`, and `cedar`. You may also provide a custom voice object with an
    /// `id`, for example `{ "id": "voice_1234" }`.
    /// </summary>
    public required Voice Voice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Voice>("voice");
        }
        init { this._rawData.Set("voice", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Format.Validate();
        this.Voice.Validate();
    }

    public ChatCompletionAudioParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCompletionAudioParam(ChatCompletionAudioParam chatCompletionAudioParam)
        : base(chatCompletionAudioParam) { }
#pragma warning restore CS8618

    public ChatCompletionAudioParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCompletionAudioParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCompletionAudioParamFromRaw.FromRawUnchecked"/>
    public static ChatCompletionAudioParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatCompletionAudioParamFromRaw : IFromRawJson<ChatCompletionAudioParam>
{
    /// <inheritdoc/>
    public ChatCompletionAudioParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCompletionAudioParam.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the output audio format. Must be one of `wav`, `mp3`, `flac`, `opus`,
/// or `pcm16`.
/// </summary>
[JsonConverter(typeof(FormatConverter))]
public enum Format
{
    Wav,
    Aac,
    Mp3,
    Flac,
    Opus,
    Pcm16,
}

sealed class FormatConverter : JsonConverter<Format>
{
    public override Format Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "wav" => Format.Wav,
            "aac" => Format.Aac,
            "mp3" => Format.Mp3,
            "flac" => Format.Flac,
            "opus" => Format.Opus,
            "pcm16" => Format.Pcm16,
            _ => (Format)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Format value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Format.Wav => "wav",
                Format.Aac => "aac",
                Format.Mp3 => "mp3",
                Format.Flac => "flac",
                Format.Opus => "opus",
                Format.Pcm16 => "pcm16",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The voice the model uses to respond. Supported built-in voices are `alloy`, `ash`,
/// `ballad`, `coral`, `echo`, `fable`, `nova`, `onyx`, `sage`, `shimmer`, `marin`,
/// and `cedar`. You may also provide a custom voice object with an `id`, for example
/// `{ "id": "voice_1234" }`.
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
        System::Action<string> @string,
        System::Action<ApiEnum<string, UnionMember1>> unionMember1,
        System::Action<VoiceIdsOrCustomVoice> idsOrCustom
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
        System::Func<string, T> @string,
        System::Func<ApiEnum<string, UnionMember1>, T> unionMember1,
        System::Func<VoiceIdsOrCustomVoice, T> idsOrCustom
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
        System::Type typeToConvert,
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
        catch (System::Exception e) when (e is JsonException || e is DedalusInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is DedalusInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is DedalusInvalidDataException)
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
        System::Type typeToConvert,
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
