using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;

namespace DedalusSdk.Models;

[JsonConverter(typeof(JsonModelConverter<ModelSettings, ModelSettingsFromRaw>))]
public sealed record class ModelSettings : JsonModel
{
    public IReadOnlyDictionary<string, JsonElement>? Attributes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "attributes"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "attributes",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyDictionary<string, JsonValueInput?>? Audio
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "audio"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "audio",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public bool? Deferred
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("deferred");
        }
        init { this._rawData.Set("deferred", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? ExtraArgs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "extra_args"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "extra_args",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyDictionary<string, string>? ExtraHeaders
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "extra_headers"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "extra_headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? ExtraQuery
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "extra_query"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "extra_query",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public double? FrequencyPenalty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("frequency_penalty");
        }
        init { this._rawData.Set("frequency_penalty", value); }
    }

    public IReadOnlyDictionary<string, JsonValueInput?>? GenerationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "generation_config"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "generation_config",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public bool? IncludeUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("include_usage");
        }
        init { this._rawData.Set("include_usage", value); }
    }

    public string? InputAudioFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("input_audio_format");
        }
        init { this._rawData.Set("input_audio_format", value); }
    }

    public IReadOnlyDictionary<string, JsonValueInput?>? InputAudioTranscription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "input_audio_transcription"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "input_audio_transcription",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyDictionary<string, long>? LogitBias
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, long>>("logit_bias");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, long>?>(
                "logit_bias",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public bool? Logprobs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("logprobs");
        }
        init { this._rawData.Set("logprobs", value); }
    }

    public long? MaxCompletionTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_completion_tokens");
        }
        init { this._rawData.Set("max_completion_tokens", value); }
    }

    public long? MaxTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_tokens");
        }
        init { this._rawData.Set("max_tokens", value); }
    }

    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyList<string>? Modalities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("modalities");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "modalities",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? N
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("n");
        }
        init { this._rawData.Set("n", value); }
    }

    public string? OutputAudioFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("output_audio_format");
        }
        init { this._rawData.Set("output_audio_format", value); }
    }

    public bool? ParallelToolCalls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("parallel_tool_calls");
        }
        init { this._rawData.Set("parallel_tool_calls", value); }
    }

    public IReadOnlyDictionary<string, JsonValueInput?>? Prediction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "prediction"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "prediction",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public double? PresencePenalty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("presence_penalty");
        }
        init { this._rawData.Set("presence_penalty", value); }
    }

    public string? PromptCacheKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prompt_cache_key");
        }
        init { this._rawData.Set("prompt_cache_key", value); }
    }

    /// <summary>
    /// **gpt-5 and o-series models only**
    ///
    /// <para>Configuration options for [reasoning models](https://platform.openai.com/docs/guides/reasoning).</para>
    /// </summary>
    public Reasoning? Reasoning
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Reasoning>("reasoning");
        }
        init { this._rawData.Set("reasoning", value); }
    }

    public string? ReasoningEffort
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reasoning_effort");
        }
        init { this._rawData.Set("reasoning_effort", value); }
    }

    public IReadOnlyDictionary<string, JsonValueInput?>? ResponseFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "response_format"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "response_format",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? SafetyIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("safety_identifier");
        }
        init { this._rawData.Set("safety_identifier", value); }
    }

    public IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>>? SafetySettings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FrozenDictionary<string, JsonValueInput?>>
            >("safety_settings");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonValueInput?>>?>(
                "safety_settings",
                value == null
                    ? null
                    : ImmutableArray.ToImmutableArray(
                        Enumerable.Select(
                            value,
                            (item) => FrozenDictionary.ToFrozenDictionary(item)
                        )
                    )
            );
        }
    }

    public IReadOnlyDictionary<string, JsonValueInput?>? SearchParameters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "search_parameters"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "search_parameters",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public long? Seed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("seed");
        }
        init { this._rawData.Set("seed", value); }
    }

    public string? ServiceTier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("service_tier");
        }
        init { this._rawData.Set("service_tier", value); }
    }

    public Stop? Stop
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Stop>("stop");
        }
        init { this._rawData.Set("stop", value); }
    }

    public bool? Store
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("store");
        }
        init { this._rawData.Set("store", value); }
    }

    public bool? Stream
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("stream");
        }
        init { this._rawData.Set("stream", value); }
    }

    public IReadOnlyDictionary<string, JsonValueInput?>? StreamOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "stream_options"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "stream_options",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public JsonElement? StructuredOutput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("structured_output");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("structured_output", value);
        }
    }

    public IReadOnlyDictionary<string, JsonValueInput?>? SystemInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "system_instruction"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "system_instruction",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public double? Temperature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("temperature");
        }
        init { this._rawData.Set("temperature", value); }
    }

    public IReadOnlyDictionary<string, JsonValueInput?>? Thinking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "thinking"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "thinking",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public double? Timeout
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("timeout");
        }
        init { this._rawData.Set("timeout", value); }
    }

    public ToolChoice? ToolChoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ToolChoice>("tool_choice");
        }
        init { this._rawData.Set("tool_choice", value); }
    }

    public IReadOnlyDictionary<string, JsonValueInput?>? ToolConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "tool_config"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "tool_config",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public long? TopK
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("top_k");
        }
        init { this._rawData.Set("top_k", value); }
    }

    public long? TopLogprobs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("top_logprobs");
        }
        init { this._rawData.Set("top_logprobs", value); }
    }

    public double? TopP
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("top_p");
        }
        init { this._rawData.Set("top_p", value); }
    }

    public ApiEnum<string, Truncation>? Truncation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Truncation>>("truncation");
        }
        init { this._rawData.Set("truncation", value); }
    }

    public IReadOnlyDictionary<string, JsonValueInput?>? TurnDetection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "turn_detection"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "turn_detection",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? User
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user");
        }
        init { this._rawData.Set("user", value); }
    }

    public string? Verbosity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("verbosity");
        }
        init { this._rawData.Set("verbosity", value); }
    }

    public string? Voice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("voice");
        }
        init { this._rawData.Set("voice", value); }
    }

    public IReadOnlyDictionary<string, JsonValueInput?>? WebSearchOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "web_search_options"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "web_search_options",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Attributes;
        if (this.Audio != null)
        {
            foreach (var item in this.Audio.Values)
            {
                item?.Validate();
            }
        }
        _ = this.Deferred;
        _ = this.ExtraArgs;
        _ = this.ExtraHeaders;
        _ = this.ExtraQuery;
        _ = this.FrequencyPenalty;
        if (this.GenerationConfig != null)
        {
            foreach (var item in this.GenerationConfig.Values)
            {
                item?.Validate();
            }
        }
        _ = this.IncludeUsage;
        _ = this.InputAudioFormat;
        if (this.InputAudioTranscription != null)
        {
            foreach (var item in this.InputAudioTranscription.Values)
            {
                item?.Validate();
            }
        }
        _ = this.LogitBias;
        _ = this.Logprobs;
        _ = this.MaxCompletionTokens;
        _ = this.MaxTokens;
        _ = this.Metadata;
        _ = this.Modalities;
        _ = this.N;
        _ = this.OutputAudioFormat;
        _ = this.ParallelToolCalls;
        if (this.Prediction != null)
        {
            foreach (var item in this.Prediction.Values)
            {
                item?.Validate();
            }
        }
        _ = this.PresencePenalty;
        _ = this.PromptCacheKey;
        this.Reasoning?.Validate();
        _ = this.ReasoningEffort;
        if (this.ResponseFormat != null)
        {
            foreach (var item in this.ResponseFormat.Values)
            {
                item?.Validate();
            }
        }
        _ = this.SafetyIdentifier;
        foreach (var item in this.SafetySettings ?? [])
        {
            foreach (var item1 in item.Values)
            {
                item1?.Validate();
            }
        }
        if (this.SearchParameters != null)
        {
            foreach (var item in this.SearchParameters.Values)
            {
                item?.Validate();
            }
        }
        _ = this.Seed;
        _ = this.ServiceTier;
        this.Stop?.Validate();
        _ = this.Store;
        _ = this.Stream;
        if (this.StreamOptions != null)
        {
            foreach (var item in this.StreamOptions.Values)
            {
                item?.Validate();
            }
        }
        _ = this.StructuredOutput;
        if (this.SystemInstruction != null)
        {
            foreach (var item in this.SystemInstruction.Values)
            {
                item?.Validate();
            }
        }
        _ = this.Temperature;
        if (this.Thinking != null)
        {
            foreach (var item in this.Thinking.Values)
            {
                item?.Validate();
            }
        }
        _ = this.Timeout;
        this.ToolChoice?.Validate();
        if (this.ToolConfig != null)
        {
            foreach (var item in this.ToolConfig.Values)
            {
                item?.Validate();
            }
        }
        _ = this.TopK;
        _ = this.TopLogprobs;
        _ = this.TopP;
        this.Truncation?.Validate();
        if (this.TurnDetection != null)
        {
            foreach (var item in this.TurnDetection.Values)
            {
                item?.Validate();
            }
        }
        _ = this.User;
        _ = this.Verbosity;
        _ = this.Voice;
        if (this.WebSearchOptions != null)
        {
            foreach (var item in this.WebSearchOptions.Values)
            {
                item?.Validate();
            }
        }
    }

    public ModelSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelSettings(ModelSettings modelSettings)
        : base(modelSettings) { }
#pragma warning restore CS8618

    public ModelSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelSettingsFromRaw.FromRawUnchecked"/>
    public static ModelSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModelSettingsFromRaw : IFromRawJson<ModelSettings>
{
    /// <inheritdoc/>
    public ModelSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ModelSettings.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StopConverter))]
public record class Stop : ModelBase
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

    public Stop(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Stop(IReadOnlyList<string> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Stop(JsonElement element)
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
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>string</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStrings(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;string&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStrings([NotNullWhen(true)] out IReadOnlyList<string>? value)
    {
        value = this.Value as IReadOnlyList<string>;
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
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<string> @string, Action<IReadOnlyList<string>> strings)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyList<string> value:
                strings(value);
                break;
            default:
                throw new DedalusInvalidDataException("Data did not match any variant of Stop");
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
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<string, T> @string, Func<IReadOnlyList<string>, T> strings)
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<string> value => strings(value),
            _ => throw new DedalusInvalidDataException("Data did not match any variant of Stop"),
        };
    }

    public static implicit operator Stop(string value) => new(value);

    public static implicit operator Stop(List<string> value) => new((IReadOnlyList<string>)value);

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
            throw new DedalusInvalidDataException("Data did not match any variant of Stop");
        }
    }

    public virtual bool Equals(Stop? other) =>
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
            IReadOnlyList<string> _ => 1,
            _ => -1,
        };
    }
}

sealed class StopConverter : JsonConverter<Stop?>
{
    public override Stop? Read(
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
            var deserialized = JsonSerializer.Deserialize<List<string>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Stop? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(TruncationConverter))]
public enum Truncation
{
    Auto,
    Disabled,
}

sealed class TruncationConverter : JsonConverter<Truncation>
{
    public override Truncation Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => Truncation.Auto,
            "disabled" => Truncation.Disabled,
            _ => (Truncation)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Truncation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Truncation.Auto => "auto",
                Truncation.Disabled => "disabled",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
