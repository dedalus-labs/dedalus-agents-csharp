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
/// Learn about [audio inputs](/docs/guides/audio).
///
/// <para>Fields: - type (required): Literal["input_audio"] - input_audio (required): InputAudio</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChatCompletionContentPartInputAudioParam,
        ChatCompletionContentPartInputAudioParamFromRaw
    >)
)]
public sealed record class ChatCompletionContentPartInputAudioParam : JsonModel
{
    /// <summary>
    /// Schema for InputAudio.
    ///
    /// <para>Fields: - data (required): str - format (required): Literal["wav", "mp3"]</para>
    /// </summary>
    public required InputAudio InputAudio
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<InputAudio>("input_audio");
        }
        init { this._rawData.Set("input_audio", value); }
    }

    /// <summary>
    /// The type of the content part. Always `input_audio`.
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
        this.InputAudio.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("input_audio")))
        {
            throw new DedalusInvalidDataException("Invalid value given for constant");
        }
    }

    public ChatCompletionContentPartInputAudioParam()
    {
        this.Type = JsonSerializer.SerializeToElement("input_audio");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCompletionContentPartInputAudioParam(
        ChatCompletionContentPartInputAudioParam chatCompletionContentPartInputAudioParam
    )
        : base(chatCompletionContentPartInputAudioParam) { }
#pragma warning restore CS8618

    public ChatCompletionContentPartInputAudioParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("input_audio");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCompletionContentPartInputAudioParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCompletionContentPartInputAudioParamFromRaw.FromRawUnchecked"/>
    public static ChatCompletionContentPartInputAudioParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChatCompletionContentPartInputAudioParam(InputAudio inputAudio)
        : this()
    {
        this.InputAudio = inputAudio;
    }
}

class ChatCompletionContentPartInputAudioParamFromRaw
    : IFromRawJson<ChatCompletionContentPartInputAudioParam>
{
    /// <inheritdoc/>
    public ChatCompletionContentPartInputAudioParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCompletionContentPartInputAudioParam.FromRawUnchecked(rawData);
}

/// <summary>
/// Schema for InputAudio.
///
/// <para>Fields: - data (required): str - format (required): Literal["wav", "mp3"]</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InputAudio, InputAudioFromRaw>))]
public sealed record class InputAudio : JsonModel
{
    /// <summary>
    /// Base64 encoded audio data.
    /// </summary>
    public required string Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// The format of the encoded audio data. Currently supports "wav" and "mp3".
    /// </summary>
    public required ApiEnum<string, InputAudioFormat> Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InputAudioFormat>>("format");
        }
        init { this._rawData.Set("format", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        this.Format.Validate();
    }

    public InputAudio() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InputAudio(InputAudio inputAudio)
        : base(inputAudio) { }
#pragma warning restore CS8618

    public InputAudio(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InputAudio(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InputAudioFromRaw.FromRawUnchecked"/>
    public static InputAudio FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InputAudioFromRaw : IFromRawJson<InputAudio>
{
    /// <inheritdoc/>
    public InputAudio FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InputAudio.FromRawUnchecked(rawData);
}

/// <summary>
/// The format of the encoded audio data. Currently supports "wav" and "mp3".
/// </summary>
[JsonConverter(typeof(InputAudioFormatConverter))]
public enum InputAudioFormat
{
    Wav,
    Mp3,
}

sealed class InputAudioFormatConverter : JsonConverter<InputAudioFormat>
{
    public override InputAudioFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "wav" => InputAudioFormat.Wav,
            "mp3" => InputAudioFormat.Mp3,
            _ => (InputAudioFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InputAudioFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InputAudioFormat.Wav => "wav",
                InputAudioFormat.Mp3 => "mp3",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
