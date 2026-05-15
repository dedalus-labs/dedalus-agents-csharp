using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;

namespace DedalusSdk.Models.Chat.Completions;

/// <summary>
/// Schema for ChatCompletionRequestFunctionMessage.
///
/// <para>Fields: - role (required): Literal["function"] - content (required): str
/// | None - name (required): str</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChatCompletionFunctionMessageParam,
        ChatCompletionFunctionMessageParamFromRaw
    >)
)]
public sealed record class ChatCompletionFunctionMessageParam : JsonModel
{
    /// <summary>
    /// The contents of the function message.
    /// </summary>
    public required string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// The name of the function to call.
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
    /// The role of the messages author, in this case `function`.
    /// </summary>
    public JsonElement Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("role");
        }
        init { this._rawData.Set("role", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Role, JsonSerializer.SerializeToElement("function")))
        {
            throw new DedalusInvalidDataException("Invalid value given for constant");
        }
    }

    public ChatCompletionFunctionMessageParam()
    {
        this.Role = JsonSerializer.SerializeToElement("function");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCompletionFunctionMessageParam(
        ChatCompletionFunctionMessageParam chatCompletionFunctionMessageParam
    )
        : base(chatCompletionFunctionMessageParam) { }
#pragma warning restore CS8618

    public ChatCompletionFunctionMessageParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Role = JsonSerializer.SerializeToElement("function");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCompletionFunctionMessageParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCompletionFunctionMessageParamFromRaw.FromRawUnchecked"/>
    public static ChatCompletionFunctionMessageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatCompletionFunctionMessageParamFromRaw : IFromRawJson<ChatCompletionFunctionMessageParam>
{
    /// <inheritdoc/>
    public ChatCompletionFunctionMessageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCompletionFunctionMessageParam.FromRawUnchecked(rawData);
}
