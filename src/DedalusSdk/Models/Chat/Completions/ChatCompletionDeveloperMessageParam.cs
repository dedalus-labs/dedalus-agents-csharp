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
/// Developer-provided instructions that the model should follow, regardless of messages
/// sent by the user. With o1 models and newer, `developer` messages replace the previous
/// `system` messages.
///
/// <para>Fields: - content (required): str | Annotated[list[ChatCompletionRequestMessageContentPartText],
/// MinLen(1), ArrayTitle("ChatCompletionRequestDeveloperMessageContentArray")] -
/// role (required): Literal["developer"] - name (optional): str</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChatCompletionDeveloperMessageParam,
        ChatCompletionDeveloperMessageParamFromRaw
    >)
)]
public sealed record class ChatCompletionDeveloperMessageParam : JsonModel
{
    /// <summary>
    /// The contents of the developer message.
    /// </summary>
    public required ChatCompletionDeveloperMessageParamContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ChatCompletionDeveloperMessageParamContent>(
                "content"
            );
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// The role of the messages author, in this case `developer`.
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
        if (!JsonElement.DeepEquals(this.Role, JsonSerializer.SerializeToElement("developer")))
        {
            throw new DedalusInvalidDataException("Invalid value given for constant");
        }
        _ = this.Name;
    }

    public ChatCompletionDeveloperMessageParam()
    {
        this.Role = JsonSerializer.SerializeToElement("developer");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCompletionDeveloperMessageParam(
        ChatCompletionDeveloperMessageParam chatCompletionDeveloperMessageParam
    )
        : base(chatCompletionDeveloperMessageParam) { }
#pragma warning restore CS8618

    public ChatCompletionDeveloperMessageParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Role = JsonSerializer.SerializeToElement("developer");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCompletionDeveloperMessageParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCompletionDeveloperMessageParamFromRaw.FromRawUnchecked"/>
    public static ChatCompletionDeveloperMessageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChatCompletionDeveloperMessageParam(ChatCompletionDeveloperMessageParamContent content)
        : this()
    {
        this.Content = content;
    }
}

class ChatCompletionDeveloperMessageParamFromRaw : IFromRawJson<ChatCompletionDeveloperMessageParam>
{
    /// <inheritdoc/>
    public ChatCompletionDeveloperMessageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCompletionDeveloperMessageParam.FromRawUnchecked(rawData);
}

/// <summary>
/// The contents of the developer message.
/// </summary>
[JsonConverter(typeof(ChatCompletionDeveloperMessageParamContentConverter))]
public record class ChatCompletionDeveloperMessageParamContent : ModelBase
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

    public ChatCompletionDeveloperMessageParamContent(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionDeveloperMessageParamContent(
        IReadOnlyList<ChatCompletionContentPartTextParam> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ChatCompletionDeveloperMessageParamContent(JsonElement element)
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
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>ChatCompletionContentPartTextParam</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChatCompletionRequestDeveloperMessageContentArray(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;ChatCompletionContentPartTextParam&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChatCompletionRequestDeveloperMessageContentArray(
        [NotNullWhen(true)] out IReadOnlyList<ChatCompletionContentPartTextParam>? value
    )
    {
        value = this.Value as IReadOnlyList<ChatCompletionContentPartTextParam>;
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
    ///     (IReadOnlyList&lt;ChatCompletionContentPartTextParam&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<
            IReadOnlyList<ChatCompletionContentPartTextParam>
        > chatCompletionRequestDeveloperMessageContentArray
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyList<ChatCompletionContentPartTextParam> value:
                chatCompletionRequestDeveloperMessageContentArray(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of ChatCompletionDeveloperMessageParamContent"
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
    ///     (IReadOnlyList&lt;ChatCompletionContentPartTextParam&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<
            IReadOnlyList<ChatCompletionContentPartTextParam>,
            T
        > chatCompletionRequestDeveloperMessageContentArray
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<ChatCompletionContentPartTextParam> value =>
                chatCompletionRequestDeveloperMessageContentArray(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of ChatCompletionDeveloperMessageParamContent"
            ),
        };
    }

    public static implicit operator ChatCompletionDeveloperMessageParamContent(string value) =>
        new(value);

    public static implicit operator ChatCompletionDeveloperMessageParamContent(
        List<ChatCompletionContentPartTextParam> value
    ) => new((IReadOnlyList<ChatCompletionContentPartTextParam>)value);

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
                "Data did not match any variant of ChatCompletionDeveloperMessageParamContent"
            );
        }
        this.Switch(
            (_) => { },
            (chatCompletionRequestDeveloperMessageContentArray) =>
            {
                foreach (var item in chatCompletionRequestDeveloperMessageContentArray)
                {
                    item.Validate();
                }
            }
        );
    }

    public virtual bool Equals(ChatCompletionDeveloperMessageParamContent? other) =>
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
            IReadOnlyList<ChatCompletionContentPartTextParam> _ => 1,
            _ => -1,
        };
    }
}

sealed class ChatCompletionDeveloperMessageParamContentConverter
    : JsonConverter<ChatCompletionDeveloperMessageParamContent>
{
    public override ChatCompletionDeveloperMessageParamContent? Read(
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
            var deserialized = JsonSerializer.Deserialize<List<ChatCompletionContentPartTextParam>>(
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
        ChatCompletionDeveloperMessageParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
