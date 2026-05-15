using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;

namespace DedalusSdk.Models.Chat.Completions;

/// <summary>
/// Learn about [text inputs](/docs/guides/text-generation).
///
/// <para>Fields: - type (required): Literal["text"] - text (required): str</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChatCompletionContentPartTextParam,
        ChatCompletionContentPartTextParamFromRaw
    >)
)]
public sealed record class ChatCompletionContentPartTextParam : JsonModel
{
    /// <summary>
    /// The text content.
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
    /// The type of the content part.
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
        _ = this.Text;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("text")))
        {
            throw new DedalusInvalidDataException("Invalid value given for constant");
        }
    }

    public ChatCompletionContentPartTextParam()
    {
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCompletionContentPartTextParam(
        ChatCompletionContentPartTextParam chatCompletionContentPartTextParam
    )
        : base(chatCompletionContentPartTextParam) { }
#pragma warning restore CS8618

    public ChatCompletionContentPartTextParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCompletionContentPartTextParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCompletionContentPartTextParamFromRaw.FromRawUnchecked"/>
    public static ChatCompletionContentPartTextParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChatCompletionContentPartTextParam(string text)
        : this()
    {
        this.Text = text;
    }
}

class ChatCompletionContentPartTextParamFromRaw : IFromRawJson<ChatCompletionContentPartTextParam>
{
    /// <inheritdoc/>
    public ChatCompletionContentPartTextParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCompletionContentPartTextParam.FromRawUnchecked(rawData);
}
