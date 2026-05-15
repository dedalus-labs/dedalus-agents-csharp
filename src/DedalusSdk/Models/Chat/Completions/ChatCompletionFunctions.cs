using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models.Chat.Completions;

/// <summary>
/// Schema for ChatCompletionFunctions.
///
/// <para>Fields: - description (optional): str - name (required): str - parameters
/// (optional): FunctionParameters</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChatCompletionFunctions, ChatCompletionFunctionsFromRaw>))]
public sealed record class ChatCompletionFunctions : JsonModel
{
    /// <summary>
    /// The name of the function to be called. Must be a-z, A-Z, 0-9, or contain underscores
    /// and dashes, with a maximum length of 64.
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
    /// A description of what the function does, used by the model to choose when
    /// and how to call the function.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// The parameters the functions accepts, described as a JSON Schema object. See
    /// the [guide](/docs/guides/function-calling) for examples, and the [JSON Schema
    /// reference](https://json-schema.org/understanding-json-schema/) for documentation
    /// about the format.
    ///
    /// <para>Omitting `parameters` defines a function with an empty parameter list.</para>
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Parameters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "parameters"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "parameters",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Description;
        _ = this.Parameters;
    }

    public ChatCompletionFunctions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCompletionFunctions(ChatCompletionFunctions chatCompletionFunctions)
        : base(chatCompletionFunctions) { }
#pragma warning restore CS8618

    public ChatCompletionFunctions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCompletionFunctions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCompletionFunctionsFromRaw.FromRawUnchecked"/>
    public static ChatCompletionFunctions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChatCompletionFunctions(string name)
        : this()
    {
        this.Name = name;
    }
}

class ChatCompletionFunctionsFromRaw : IFromRawJson<ChatCompletionFunctions>
{
    /// <inheritdoc/>
    public ChatCompletionFunctions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCompletionFunctions.FromRawUnchecked(rawData);
}
