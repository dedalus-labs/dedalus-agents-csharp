using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using System = System;

namespace DedalusSdk.Models.Chat.Completions;

/// <summary>
/// Represents a streamed chunk of a chat completion response returned by the model,
/// based on the provided input. [Learn more](/docs/guides/streaming-responses).
///
/// <para>Fields: - id (required): str - choices (required): list[ChatCompletionStreamResponseChoicesItem]
/// - created (required): int - model (required): str - service_tier (optional):
/// ServiceTier - system_fingerprint (optional): str - object (required): Literal["chat.completion.chunk"]
/// - usage (optional): CompletionUsage</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChatCompletionChunk, ChatCompletionChunkFromRaw>))]
public sealed record class ChatCompletionChunk : JsonModel
{
    /// <summary>
    /// A unique identifier for the chat completion. Each chunk has the same ID.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// A list of chat completion choices. Can contain more than one elements if `n`
    /// is greater than 1. Can also be empty for the last chunk if you set `stream_options:
    /// {"include_usage": true}`.
    /// </summary>
    public required IReadOnlyList<StreamChoice> Choices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<StreamChoice>>("choices");
        }
        init
        {
            this._rawData.Set<ImmutableArray<StreamChoice>>(
                "choices",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The Unix timestamp (in seconds) of when the chat completion was created.
    /// Each chunk has the same timestamp.
    /// </summary>
    public required long Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    /// <summary>
    /// The model to generate the completion.
    /// </summary>
    public required string Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    /// <summary>
    /// The object type, which is always `chat.completion.chunk`.
    /// </summary>
    public JsonElement Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("object");
        }
        init { this._rawData.Set("object", value); }
    }

    /// <summary>
    /// Specifies the processing type used for serving the request.   - If set to
    /// 'auto', then the request will be processed with the service tier configured
    /// in the Project settings. Unless otherwise configured, the Project will use
    /// 'default'.   - If set to 'default', then the request will be processed with
    /// the standard pricing and performance for the selected model.   - If set to
    /// '[flex](/docs/guides/flex-processing)' or '[priority](https://openai.com/api-priority-processing/)',
    /// then the request will be processed with the corresponding service tier.
    ///  - When not set, the default behavior is 'auto'.
    ///
    /// <para>  When the `service_tier` parameter is set, the response body will
    /// include the `service_tier` value based on the processing mode actually used
    /// to serve the request. This response value may be different from the value
    /// set in the parameter.</para>
    /// </summary>
    public ApiEnum<string, ChatCompletionChunkServiceTier>? ServiceTier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ChatCompletionChunkServiceTier>>(
                "service_tier"
            );
        }
        init { this._rawData.Set("service_tier", value); }
    }

    /// <summary>
    /// This fingerprint represents the backend configuration that the model runs
    /// with. Can be used in conjunction with the `seed` request parameter to understand
    /// when backend changes have been made that might impact determinism.
    /// </summary>
    public string? SystemFingerprint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("system_fingerprint");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("system_fingerprint", value);
        }
    }

    /// <summary>
    /// Usage statistics for the completion request.
    ///
    /// <para>Fields: - completion_tokens (required): int - prompt_tokens (required):
    /// int - total_tokens (required): int - completion_tokens_details (optional):
    /// CompletionTokensDetails - prompt_tokens_details (optional): PromptTokensDetails</para>
    /// </summary>
    public CompletionUsage? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CompletionUsage>("usage");
        }
        init { this._rawData.Set("usage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Choices)
        {
            item.Validate();
        }
        _ = this.Created;
        _ = this.Model;
        if (
            !JsonElement.DeepEquals(
                this.Object,
                JsonSerializer.SerializeToElement("chat.completion.chunk")
            )
        )
        {
            throw new DedalusInvalidDataException("Invalid value given for constant");
        }
        this.ServiceTier?.Validate();
        _ = this.SystemFingerprint;
        this.Usage?.Validate();
    }

    public ChatCompletionChunk()
    {
        this.Object = JsonSerializer.SerializeToElement("chat.completion.chunk");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCompletionChunk(ChatCompletionChunk chatCompletionChunk)
        : base(chatCompletionChunk) { }
#pragma warning restore CS8618

    public ChatCompletionChunk(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("chat.completion.chunk");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCompletionChunk(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCompletionChunkFromRaw.FromRawUnchecked"/>
    public static ChatCompletionChunk FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatCompletionChunkFromRaw : IFromRawJson<ChatCompletionChunk>
{
    /// <inheritdoc/>
    public ChatCompletionChunk FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChatCompletionChunk.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the processing type used for serving the request.   - If set to 'auto',
/// then the request will be processed with the service tier configured in the Project
/// settings. Unless otherwise configured, the Project will use 'default'.   - If
/// set to 'default', then the request will be processed with the standard pricing
/// and performance for the selected model.   - If set to '[flex](/docs/guides/flex-processing)'
/// or '[priority](https://openai.com/api-priority-processing/)', then the request
/// will be processed with the corresponding service tier.   - When not set, the default
/// behavior is 'auto'.
///
/// <para>  When the `service_tier` parameter is set, the response body will include
/// the `service_tier` value based on the processing mode actually used to serve the
/// request. This response value may be different from the value set in the parameter.</para>
/// </summary>
[JsonConverter(typeof(ChatCompletionChunkServiceTierConverter))]
public enum ChatCompletionChunkServiceTier
{
    Auto,
    Default,
    Flex,
    Scale,
    Priority,
}

sealed class ChatCompletionChunkServiceTierConverter : JsonConverter<ChatCompletionChunkServiceTier>
{
    public override ChatCompletionChunkServiceTier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => ChatCompletionChunkServiceTier.Auto,
            "default" => ChatCompletionChunkServiceTier.Default,
            "flex" => ChatCompletionChunkServiceTier.Flex,
            "scale" => ChatCompletionChunkServiceTier.Scale,
            "priority" => ChatCompletionChunkServiceTier.Priority,
            _ => (ChatCompletionChunkServiceTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChatCompletionChunkServiceTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChatCompletionChunkServiceTier.Auto => "auto",
                ChatCompletionChunkServiceTier.Default => "default",
                ChatCompletionChunkServiceTier.Flex => "flex",
                ChatCompletionChunkServiceTier.Scale => "scale",
                ChatCompletionChunkServiceTier.Priority => "priority",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
