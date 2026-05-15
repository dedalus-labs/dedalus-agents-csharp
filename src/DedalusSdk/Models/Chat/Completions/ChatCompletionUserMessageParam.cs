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
/// Messages sent by an end user, containing prompts or additional context information.
///
/// <para>Fields: - content (required): str | Annotated[list[ChatCompletionRequestUserMessageContentPart],
/// MinLen(1), ArrayTitle("ChatCompletionRequestUserMessageContentArray")] - role
/// (required): Literal["user"] - name (optional): str</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChatCompletionUserMessageParam,
        ChatCompletionUserMessageParamFromRaw
    >)
)]
public sealed record class ChatCompletionUserMessageParam : JsonModel
{
    /// <summary>
    /// The contents of the user message.
    /// </summary>
    public required ChatCompletionUserMessageParamContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ChatCompletionUserMessageParamContent>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// The role of the messages author, in this case `user`.
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

    /// <summary>
    /// An optional name for the participant. Provides the model information to differentiate
    /// between participants of the same role.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        if (!JsonElement.DeepEquals(this.Role, JsonSerializer.SerializeToElement("user")))
        {
            throw new DedalusInvalidDataException("Invalid value given for constant");
        }
        _ = this.Name;
    }

    public ChatCompletionUserMessageParam()
    {
        this.Role = JsonSerializer.SerializeToElement("user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCompletionUserMessageParam(
        ChatCompletionUserMessageParam chatCompletionUserMessageParam
    )
        : base(chatCompletionUserMessageParam) { }
#pragma warning restore CS8618

    public ChatCompletionUserMessageParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Role = JsonSerializer.SerializeToElement("user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCompletionUserMessageParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCompletionUserMessageParamFromRaw.FromRawUnchecked"/>
    public static ChatCompletionUserMessageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChatCompletionUserMessageParam(ChatCompletionUserMessageParamContent content)
        : this()
    {
        this.Content = content;
    }
}

class ChatCompletionUserMessageParamFromRaw : IFromRawJson<ChatCompletionUserMessageParam>
{
    /// <inheritdoc/>
    public ChatCompletionUserMessageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCompletionUserMessageParam.FromRawUnchecked(rawData);
}

/// <summary>
/// The contents of the user message.
/// </summary>
[JsonConverter(typeof(ChatCompletionUserMessageParamContentConverter))]
public record class ChatCompletionUserMessageParamContent : ModelBase
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

    public ChatCompletionUserMessageParamContent(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionUserMessageParamContent(
        IReadOnlyList<UnnamedSchemaWithArrayParent2> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ChatCompletionUserMessageParamContent(JsonElement element)
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
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>UnnamedSchemaWithArrayParent2</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChatCompletionRequestUserMessageContentArray(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;UnnamedSchemaWithArrayParent2&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChatCompletionRequestUserMessageContentArray(
        [NotNullWhen(true)] out IReadOnlyList<UnnamedSchemaWithArrayParent2>? value
    )
    {
        value = this.Value as IReadOnlyList<UnnamedSchemaWithArrayParent2>;
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
    ///     (IReadOnlyList&lt;UnnamedSchemaWithArrayParent2&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<
            IReadOnlyList<UnnamedSchemaWithArrayParent2>
        > chatCompletionRequestUserMessageContentArray
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyList<UnnamedSchemaWithArrayParent2> value:
                chatCompletionRequestUserMessageContentArray(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of ChatCompletionUserMessageParamContent"
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
    ///     (string value) =&gt; {...},
    ///     (IReadOnlyList&lt;UnnamedSchemaWithArrayParent2&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<
            IReadOnlyList<UnnamedSchemaWithArrayParent2>,
            T
        > chatCompletionRequestUserMessageContentArray
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<UnnamedSchemaWithArrayParent2> value =>
                chatCompletionRequestUserMessageContentArray(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of ChatCompletionUserMessageParamContent"
            ),
        };
    }

    public static implicit operator ChatCompletionUserMessageParamContent(string value) =>
        new(value);

    public static implicit operator ChatCompletionUserMessageParamContent(
        List<UnnamedSchemaWithArrayParent2> value
    ) => new((IReadOnlyList<UnnamedSchemaWithArrayParent2>)value);

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
                "Data did not match any variant of ChatCompletionUserMessageParamContent"
            );
        }
        this.Switch(
            (_) => { },
            (chatCompletionRequestUserMessageContentArray) =>
            {
                foreach (var item in chatCompletionRequestUserMessageContentArray)
                {
                    item.Validate();
                }
            }
        );
    }

    public virtual bool Equals(ChatCompletionUserMessageParamContent? other) =>
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
            IReadOnlyList<UnnamedSchemaWithArrayParent2> _ => 1,
            _ => -1,
        };
    }
}

sealed class ChatCompletionUserMessageParamContentConverter
    : JsonConverter<ChatCompletionUserMessageParamContent>
{
    public override ChatCompletionUserMessageParamContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
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

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<UnnamedSchemaWithArrayParent2>>(
                element,
                options
            );
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChatCompletionUserMessageParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Learn about [text inputs](/docs/guides/text-generation).
///
/// <para>Fields: - type (required): Literal["text"] - text (required): str</para>
/// </summary>
[JsonConverter(typeof(UnnamedSchemaWithArrayParent2Converter))]
public record class UnnamedSchemaWithArrayParent2 : ModelBase
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
        get
        {
            return Match(
                chatCompletionContentPartTextParam: (x) => x.Type,
                chatCompletionContentPartImageParam: (x) => x.Type,
                chatCompletionContentPartInputAudioParam: (x) => x.Type,
                chatCompletionContentPartFileParam: (x) => x.Type
            );
        }
    }

    public UnnamedSchemaWithArrayParent2(
        ChatCompletionContentPartTextParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent2(
        ChatCompletionContentPartImageParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent2(
        ChatCompletionContentPartInputAudioParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent2(
        ChatCompletionContentPartFileParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent2(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ChatCompletionContentPartTextParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChatCompletionContentPartTextParam(out var value)) {
    ///     // `value` is of type `ChatCompletionContentPartTextParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChatCompletionContentPartTextParam(
        [NotNullWhen(true)] out ChatCompletionContentPartTextParam? value
    )
    {
        value = this.Value as ChatCompletionContentPartTextParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ChatCompletionContentPartImageParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChatCompletionContentPartImageParam(out var value)) {
    ///     // `value` is of type `ChatCompletionContentPartImageParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChatCompletionContentPartImageParam(
        [NotNullWhen(true)] out ChatCompletionContentPartImageParam? value
    )
    {
        value = this.Value as ChatCompletionContentPartImageParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ChatCompletionContentPartInputAudioParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChatCompletionContentPartInputAudioParam(out var value)) {
    ///     // `value` is of type `ChatCompletionContentPartInputAudioParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChatCompletionContentPartInputAudioParam(
        [NotNullWhen(true)] out ChatCompletionContentPartInputAudioParam? value
    )
    {
        value = this.Value as ChatCompletionContentPartInputAudioParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ChatCompletionContentPartFileParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChatCompletionContentPartFileParam(out var value)) {
    ///     // `value` is of type `ChatCompletionContentPartFileParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChatCompletionContentPartFileParam(
        [NotNullWhen(true)] out ChatCompletionContentPartFileParam? value
    )
    {
        value = this.Value as ChatCompletionContentPartFileParam;
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
    ///     (ChatCompletionContentPartTextParam value) =&gt; {...},
    ///     (ChatCompletionContentPartImageParam value) =&gt; {...},
    ///     (ChatCompletionContentPartInputAudioParam value) =&gt; {...},
    ///     (ChatCompletionContentPartFileParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ChatCompletionContentPartTextParam> chatCompletionContentPartTextParam,
        System::Action<ChatCompletionContentPartImageParam> chatCompletionContentPartImageParam,
        System::Action<ChatCompletionContentPartInputAudioParam> chatCompletionContentPartInputAudioParam,
        System::Action<ChatCompletionContentPartFileParam> chatCompletionContentPartFileParam
    )
    {
        switch (this.Value)
        {
            case ChatCompletionContentPartTextParam value:
                chatCompletionContentPartTextParam(value);
                break;
            case ChatCompletionContentPartImageParam value:
                chatCompletionContentPartImageParam(value);
                break;
            case ChatCompletionContentPartInputAudioParam value:
                chatCompletionContentPartInputAudioParam(value);
                break;
            case ChatCompletionContentPartFileParam value:
                chatCompletionContentPartFileParam(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of UnnamedSchemaWithArrayParent2"
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
    ///     (ChatCompletionContentPartTextParam value) =&gt; {...},
    ///     (ChatCompletionContentPartImageParam value) =&gt; {...},
    ///     (ChatCompletionContentPartInputAudioParam value) =&gt; {...},
    ///     (ChatCompletionContentPartFileParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ChatCompletionContentPartTextParam, T> chatCompletionContentPartTextParam,
        System::Func<ChatCompletionContentPartImageParam, T> chatCompletionContentPartImageParam,
        System::Func<
            ChatCompletionContentPartInputAudioParam,
            T
        > chatCompletionContentPartInputAudioParam,
        System::Func<ChatCompletionContentPartFileParam, T> chatCompletionContentPartFileParam
    )
    {
        return this.Value switch
        {
            ChatCompletionContentPartTextParam value => chatCompletionContentPartTextParam(value),
            ChatCompletionContentPartImageParam value => chatCompletionContentPartImageParam(value),
            ChatCompletionContentPartInputAudioParam value =>
                chatCompletionContentPartInputAudioParam(value),
            ChatCompletionContentPartFileParam value => chatCompletionContentPartFileParam(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent2"
            ),
        };
    }

    public static implicit operator UnnamedSchemaWithArrayParent2(
        ChatCompletionContentPartTextParam value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent2(
        ChatCompletionContentPartImageParam value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent2(
        ChatCompletionContentPartInputAudioParam value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent2(
        ChatCompletionContentPartFileParam value
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
                "Data did not match any variant of UnnamedSchemaWithArrayParent2"
            );
        }
        this.Switch(
            (chatCompletionContentPartTextParam) => chatCompletionContentPartTextParam.Validate(),
            (chatCompletionContentPartImageParam) => chatCompletionContentPartImageParam.Validate(),
            (chatCompletionContentPartInputAudioParam) =>
                chatCompletionContentPartInputAudioParam.Validate(),
            (chatCompletionContentPartFileParam) => chatCompletionContentPartFileParam.Validate()
        );
    }

    public virtual bool Equals(UnnamedSchemaWithArrayParent2? other) =>
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
            ChatCompletionContentPartTextParam _ => 0,
            ChatCompletionContentPartImageParam _ => 1,
            ChatCompletionContentPartInputAudioParam _ => 2,
            ChatCompletionContentPartFileParam _ => 3,
            _ => -1,
        };
    }
}

sealed class UnnamedSchemaWithArrayParent2Converter : JsonConverter<UnnamedSchemaWithArrayParent2>
{
    public override UnnamedSchemaWithArrayParent2? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
            case "text":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ChatCompletionContentPartTextParam>(
                            element,
                            options
                        );
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
            case "image_url":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ChatCompletionContentPartImageParam>(
                            element,
                            options
                        );
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
            case "input_audio":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ChatCompletionContentPartInputAudioParam>(
                            element,
                            options
                        );
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
            case "file":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ChatCompletionContentPartFileParam>(
                            element,
                            options
                        );
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
                return new UnnamedSchemaWithArrayParent2(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent2 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
