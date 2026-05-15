using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;

namespace DedalusSdk.Models.Models;

/// <summary>
/// Unified model metadata across all providers.
///
/// <para>Combines provider-specific schemas into a single, consistent format. Fields
/// that aren't available from a provider are set to None.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Model, ModelFromRaw>))]
public sealed record class Model : JsonModel
{
    /// <summary>
    /// Unique model identifier with provider prefix (e.g., 'openai/gpt-4')
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
    /// When the model was released (RFC 3339)
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Provider that hosts this model
    /// </summary>
    public required ApiEnum<string, Provider> Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Provider>>("provider");
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// Normalized model capabilities across all providers.
    /// </summary>
    public Capabilities? Capabilities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Capabilities>("capabilities");
        }
        init { this._rawData.Set("capabilities", value); }
    }

    /// <summary>
    /// Provider-declared default parameters for model generation.
    /// </summary>
    public Defaults? Defaults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Defaults>("defaults");
        }
        init { this._rawData.Set("defaults", value); }
    }

    /// <summary>
    /// Model description
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Human-readable model name
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
    }

    /// <summary>
    /// Provider-specific generation method names (None = not declared)
    /// </summary>
    public IReadOnlyList<string>? ProviderDeclaredGenerationMethods
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "provider_declared_generation_methods"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "provider_declared_generation_methods",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Raw provider-specific metadata
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? ProviderInfo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "provider_info"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "provider_info",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Model version identifier
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.Provider.Validate();
        this.Capabilities?.Validate();
        this.Defaults?.Validate();
        _ = this.Description;
        _ = this.DisplayName;
        _ = this.ProviderDeclaredGenerationMethods;
        _ = this.ProviderInfo;
        _ = this.Version;
    }

    public Model() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Model(Model model)
        : base(model) { }
#pragma warning restore CS8618

    public Model(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Model(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelFromRaw.FromRawUnchecked"/>
    public static Model FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModelFromRaw : IFromRawJson<Model>
{
    /// <inheritdoc/>
    public Model FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Model.FromRawUnchecked(rawData);
}

/// <summary>
/// Provider that hosts this model
/// </summary>
[JsonConverter(typeof(ProviderConverter))]
public enum Provider
{
    OpenAI,
    Anthropic,
    Google,
    Xai,
    Mistral,
    Groq,
    Fireworks,
    Deepseek,
    Moonshot,
    Cerebras,
}

sealed class ProviderConverter : JsonConverter<Provider>
{
    public override Provider Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai" => Provider.OpenAI,
            "anthropic" => Provider.Anthropic,
            "google" => Provider.Google,
            "xai" => Provider.Xai,
            "mistral" => Provider.Mistral,
            "groq" => Provider.Groq,
            "fireworks" => Provider.Fireworks,
            "deepseek" => Provider.Deepseek,
            "moonshot" => Provider.Moonshot,
            "cerebras" => Provider.Cerebras,
            _ => (Provider)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Provider value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Provider.OpenAI => "openai",
                Provider.Anthropic => "anthropic",
                Provider.Google => "google",
                Provider.Xai => "xai",
                Provider.Mistral => "mistral",
                Provider.Groq => "groq",
                Provider.Fireworks => "fireworks",
                Provider.Deepseek => "deepseek",
                Provider.Moonshot => "moonshot",
                Provider.Cerebras => "cerebras",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Normalized model capabilities across all providers.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Capabilities, CapabilitiesFromRaw>))]
public sealed record class Capabilities : JsonModel
{
    /// <summary>
    /// Supports audio processing
    /// </summary>
    public bool? Audio
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("audio");
        }
        init { this._rawData.Set("audio", value); }
    }

    /// <summary>
    /// Supports image generation
    /// </summary>
    public bool? ImageGeneration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("image_generation");
        }
        init { this._rawData.Set("image_generation", value); }
    }

    /// <summary>
    /// Maximum input tokens
    /// </summary>
    public long? InputTokenLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("input_token_limit");
        }
        init { this._rawData.Set("input_token_limit", value); }
    }

    /// <summary>
    /// Maximum output tokens
    /// </summary>
    public long? OutputTokenLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("output_token_limit");
        }
        init { this._rawData.Set("output_token_limit", value); }
    }

    /// <summary>
    /// Supports streaming responses
    /// </summary>
    public bool? Streaming
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("streaming");
        }
        init { this._rawData.Set("streaming", value); }
    }

    /// <summary>
    /// Supports structured JSON output
    /// </summary>
    public bool? StructuredOutput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("structured_output");
        }
        init { this._rawData.Set("structured_output", value); }
    }

    /// <summary>
    /// Supports text generation
    /// </summary>
    public bool? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// Supports extended thinking/reasoning
    /// </summary>
    public bool? Thinking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("thinking");
        }
        init { this._rawData.Set("thinking", value); }
    }

    /// <summary>
    /// Supports function/tool calling
    /// </summary>
    public bool? Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("tools");
        }
        init { this._rawData.Set("tools", value); }
    }

    /// <summary>
    /// Supports image understanding
    /// </summary>
    public bool? Vision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("vision");
        }
        init { this._rawData.Set("vision", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Audio;
        _ = this.ImageGeneration;
        _ = this.InputTokenLimit;
        _ = this.OutputTokenLimit;
        _ = this.Streaming;
        _ = this.StructuredOutput;
        _ = this.Text;
        _ = this.Thinking;
        _ = this.Tools;
        _ = this.Vision;
    }

    public Capabilities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Capabilities(Capabilities capabilities)
        : base(capabilities) { }
#pragma warning restore CS8618

    public Capabilities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Capabilities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CapabilitiesFromRaw.FromRawUnchecked"/>
    public static Capabilities FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CapabilitiesFromRaw : IFromRawJson<Capabilities>
{
    /// <inheritdoc/>
    public Capabilities FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Capabilities.FromRawUnchecked(rawData);
}

/// <summary>
/// Provider-declared default parameters for model generation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Defaults, DefaultsFromRaw>))]
public sealed record class Defaults : JsonModel
{
    /// <summary>
    /// Default maximum output tokens
    /// </summary>
    public long? MaxOutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_output_tokens");
        }
        init { this._rawData.Set("max_output_tokens", value); }
    }

    /// <summary>
    /// Default temperature setting
    /// </summary>
    public double? Temperature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("temperature");
        }
        init { this._rawData.Set("temperature", value); }
    }

    /// <summary>
    /// Default top_k setting
    /// </summary>
    public long? TopK
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("top_k");
        }
        init { this._rawData.Set("top_k", value); }
    }

    /// <summary>
    /// Default top_p setting
    /// </summary>
    public double? TopP
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("top_p");
        }
        init { this._rawData.Set("top_p", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MaxOutputTokens;
        _ = this.Temperature;
        _ = this.TopK;
        _ = this.TopP;
    }

    public Defaults() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Defaults(Defaults defaults)
        : base(defaults) { }
#pragma warning restore CS8618

    public Defaults(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Defaults(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DefaultsFromRaw.FromRawUnchecked"/>
    public static Defaults FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DefaultsFromRaw : IFromRawJson<Defaults>
{
    /// <inheritdoc/>
    public Defaults FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Defaults.FromRawUnchecked(rawData);
}
