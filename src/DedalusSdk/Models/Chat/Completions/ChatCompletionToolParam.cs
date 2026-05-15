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
/// Schema for Tool.
///
/// <para>Fields: - type (optional): ToolTypes - function (required): Function</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChatCompletionToolParam, ChatCompletionToolParamFromRaw>))]
public sealed record class ChatCompletionToolParam : JsonModel
{
    /// <summary>
    /// Schema for Function.
    ///
    /// <para>Fields: - name (required): str</para>
    /// </summary>
    public required FunctionDefinition Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FunctionDefinition>("function");
        }
        init { this._rawData.Set("function", value); }
    }

    public ApiEnum<string, global::DedalusSdk.Models.Chat.Completions.Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::DedalusSdk.Models.Chat.Completions.Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Function.Validate();
        this.Type?.Validate();
    }

    public ChatCompletionToolParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCompletionToolParam(ChatCompletionToolParam chatCompletionToolParam)
        : base(chatCompletionToolParam) { }
#pragma warning restore CS8618

    public ChatCompletionToolParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCompletionToolParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCompletionToolParamFromRaw.FromRawUnchecked"/>
    public static ChatCompletionToolParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChatCompletionToolParam(FunctionDefinition function)
        : this()
    {
        this.Function = function;
    }
}

class ChatCompletionToolParamFromRaw : IFromRawJson<ChatCompletionToolParam>
{
    /// <inheritdoc/>
    public ChatCompletionToolParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCompletionToolParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Function,
}

sealed class TypeConverter : JsonConverter<global::DedalusSdk.Models.Chat.Completions.Type>
{
    public override global::DedalusSdk.Models.Chat.Completions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "function" => global::DedalusSdk.Models.Chat.Completions.Type.Function,
            _ => (global::DedalusSdk.Models.Chat.Completions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::DedalusSdk.Models.Chat.Completions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::DedalusSdk.Models.Chat.Completions.Type.Function => "function",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
