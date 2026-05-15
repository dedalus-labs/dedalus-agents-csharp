using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;

namespace DedalusSdk.Models;

/// <summary>
/// Credential for MCP server authentication.
///
/// <para>Passed at endpoint level (e.g., chat.completions.create) and matched to
/// MCP servers by connection name. Wire format matches dedalus_mcp.Credential.to_dict().</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Credential, CredentialFromRaw>))]
public sealed record class Credential : JsonModel
{
    /// <summary>
    /// Connection name. Must match a connection in MCPServer.connections.
    /// </summary>
    public required string ConnectionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("connection_name");
        }
        init { this._rawData.Set("connection_name", value); }
    }

    /// <summary>
    /// Credential values. Keys are credential field names, values are the secrets.
    /// </summary>
    public required IReadOnlyDictionary<string, CredentialValue> Values
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, CredentialValue>>(
                "values"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, CredentialValue>>(
                "values",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConnectionName;
        foreach (var item in this.Values.Values)
        {
            item.Validate();
        }
    }

    public Credential() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Credential(Credential credential)
        : base(credential) { }
#pragma warning restore CS8618

    public Credential(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Credential(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CredentialFromRaw.FromRawUnchecked"/>
    public static Credential FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CredentialFromRaw : IFromRawJson<Credential>
{
    /// <inheritdoc/>
    public Credential FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Credential.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CredentialValueConverter))]
public record class CredentialValue : ModelBase
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

    public CredentialValue(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CredentialValue(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CredentialValue(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CredentialValue(JsonElement element)
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
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
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
    ///     (long value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<string> @string, Action<long> @long, Action<bool> @bool)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case long value:
                @long(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of CredentialValue"
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
    ///     (long value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<string, T> @string, Func<long, T> @long, Func<bool, T> @bool)
    {
        return this.Value switch
        {
            string value => @string(value),
            long value => @long(value),
            bool value => @bool(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of CredentialValue"
            ),
        };
    }

    public static implicit operator CredentialValue(string value) => new(value);

    public static implicit operator CredentialValue(long value) => new(value);

    public static implicit operator CredentialValue(bool value) => new(value);

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
                "Data did not match any variant of CredentialValue"
            );
        }
    }

    public virtual bool Equals(CredentialValue? other) =>
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
            long _ => 1,
            bool _ => 2,
            _ => -1,
        };
    }
}

sealed class CredentialValueConverter : JsonConverter<CredentialValue>
{
    public override CredentialValue? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        CredentialValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
