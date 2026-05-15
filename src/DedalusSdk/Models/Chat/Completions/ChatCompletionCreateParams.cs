using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using System = System;

namespace DedalusSdk.Models.Chat.Completions;

/// <summary>
/// ChatCompletion request schema.
///
/// <para>Supports OpenAI-compatible parameters, provider-specific extensions, server-side
/// execution, and agent orchestration features.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ChatCompletionCreateParams, ChatCompletionCreateParamsFromRaw>)
)]
public sealed record class ChatCompletionCreateParams : JsonModel
{
    /// <summary>
    /// Model identifier. Accepts model ID strings, lists for routing, or DedalusModel
    /// objects with per-model settings.
    /// </summary>
    public required ChatCompletionCreateParamsModel Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ChatCompletionCreateParamsModel>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    /// <summary>
    /// Agent attributes. Values in [0.0, 1.0].
    /// </summary>
    public IReadOnlyDictionary<string, double>? AgentAttributes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, double>>(
                "agent_attributes"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, double>?>(
                "agent_attributes",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Parameters for audio output. Required when audio output is requested with
    /// `modalities: ["audio"]`. [Learn more](/docs/guides/audio).
    ///
    /// <para>Fields: - voice (required): VoiceIdsOrCustomVoice - format (required):
    /// Literal["wav", "aac", "mp3", "flac", "opus", "pcm16"]</para>
    /// </summary>
    public ChatCompletionAudioParam? Audio
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChatCompletionAudioParam>("audio");
        }
        init { this._rawData.Set("audio", value); }
    }

    /// <summary>
    /// Execute tools server-side. If false, returns raw tool calls for manual handling.
    /// </summary>
    public bool? AutomaticToolExecution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("automatic_tool_execution");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("automatic_tool_execution", value);
        }
    }

    /// <summary>
    /// Optional. The name of the content [cached](https://ai.google.dev/gemini-api/docs/caching)
    /// to use as context to serve the prediction. Format: `cachedContents/{cachedContent}`
    /// </summary>
    public string? CachedContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cached_content");
        }
        init { this._rawData.Set("cached_content", value); }
    }

    /// <summary>
    /// Stable session ID for resuming a previous handoff. Returned by the server
    /// on handoff; echo it on the next request to resume.
    /// </summary>
    public string? CorrelationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("correlation_id");
        }
        init { this._rawData.Set("correlation_id", value); }
    }

    /// <summary>
    /// Credentials for MCP server authentication. Each credential is matched to
    /// servers by connection name.
    /// </summary>
    public ChatCompletionCreateParamsCredentials? Credentials
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChatCompletionCreateParamsCredentials>(
                "credentials"
            );
        }
        init { this._rawData.Set("credentials", value); }
    }

    /// <summary>
    /// If set to `true`, the request returns a `request_id`. You can then get the
    /// deferred response by GET `/v1/chat/deferred-completion/{request_id}`.
    /// </summary>
    public bool? Deferred
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("deferred");
        }
        init { this._rawData.Set("deferred", value); }
    }

    /// <summary>
    /// Tier 2 stateless resumption. Deferred tool specs from a previous handoff response,
    /// sent back verbatim so the server can resume without Redis.
    /// </summary>
    public IReadOnlyList<DeferredCallResponse>? DeferredCalls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DeferredCallResponse>>(
                "deferred_calls"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<DeferredCallResponse>?>(
                "deferred_calls",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number between -2.0 and 2.0. Positive values penalize new tokens based on
    /// their existing frequency in the text so far, decreasing the model's likelihood
    /// to repeat the same line verbatim.
    /// </summary>
    public double? FrequencyPenalty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("frequency_penalty");
        }
        init { this._rawData.Set("frequency_penalty", value); }
    }

    /// <summary>
    /// Deprecated in favor of `tool_choice`.  Controls which (if any) function is
    /// called by the model.  `none` means the model will not call a function and
    /// instead generates a message.  `auto` means the model can pick between generating
    /// a message or calling a function.  Specifying a particular function via `{"name":
    /// "my_function"}` forces the model to call that function.  `none` is the default
    /// when no functions are present. `auto` is the default if functions are present.
    /// </summary>
    public string? FunctionCall
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("function_call");
        }
        init { this._rawData.Set("function_call", value); }
    }

    /// <summary>
    /// Deprecated in favor of `tools`.  A list of functions the model may generate
    /// JSON inputs for.
    /// </summary>
    public IReadOnlyList<ChatCompletionFunctions>? Functions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ChatCompletionFunctions>>(
                "functions"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ChatCompletionFunctions>?>(
                "functions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Generation parameters wrapper (Google-specific)
    /// </summary>
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

    /// <summary>
    /// Content filtering and safety policy configuration.
    /// </summary>
    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? Guardrails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FrozenDictionary<string, JsonElement>>
            >("guardrails");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "guardrails",
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

    /// <summary>
    /// Configuration for multi-model handoffs.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? HandoffConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "handoff_config"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "handoff_config",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Handoff control. None or omitted: auto-detect. true: structured handoff (SDK).
    /// false: drop-in (LLM re-run for mixed turns).
    /// </summary>
    public bool? HandoffMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("handoff_mode");
        }
        init { this._rawData.Set("handoff_mode", value); }
    }

    /// <summary>
    /// Specifies the geographic region for inference processing. If not specified,
    /// the workspace's `default_inference_geo` is used.
    /// </summary>
    public string? InferenceGeo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inference_geo");
        }
        init { this._rawData.Set("inference_geo", value); }
    }

    /// <summary>
    /// Modify the likelihood of specified tokens appearing in the completion.  Accepts
    /// a JSON object that maps tokens (specified by their token ID in the tokenizer)
    /// to an associated bias value from -100 to 100. Mathematically, the bias is
    /// added to the logits generated by the model prior to sampling. The exact effect
    /// will vary per model, but values between -1 and 1 should decrease or increase
    /// likelihood of selection; values like -100 or 100 should result in a ban or
    /// exclusive selection of the relevant token.
    /// </summary>
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

    /// <summary>
    /// Whether to return log probabilities of the output tokens or not. If true,
    /// returns the log probabilities of each output token returned in the `content`
    /// of `message`.
    /// </summary>
    public bool? Logprobs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("logprobs");
        }
        init { this._rawData.Set("logprobs", value); }
    }

    /// <summary>
    /// Maximum tokens in completion (newer parameter name)
    /// </summary>
    public long? MaxCompletionTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_completion_tokens");
        }
        init { this._rawData.Set("max_completion_tokens", value); }
    }

    /// <summary>
    /// Maximum tokens in completion
    /// </summary>
    public long? MaxTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_tokens");
        }
        init { this._rawData.Set("max_tokens", value); }
    }

    /// <summary>
    /// Maximum conversation turns.
    /// </summary>
    public long? MaxTurns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_turns");
        }
        init { this._rawData.Set("max_turns", value); }
    }

    /// <summary>
    /// MCP server identifiers. Accepts marketplace slugs, URLs, or MCPServerSpec
    /// objects. MCP tools are executed server-side and billed separately.
    /// </summary>
    public ChatCompletionCreateParamsMcpServers? McpServers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChatCompletionCreateParamsMcpServers>(
                "mcp_servers"
            );
        }
        init { this._rawData.Set("mcp_servers", value); }
    }

    /// <summary>
    /// Conversation history (OpenAI: messages, Google: contents, Responses: input)
    /// </summary>
    public IReadOnlyList<ChatCompletionCreateParamsMessage>? Messages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ChatCompletionCreateParamsMessage>
            >("messages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ChatCompletionCreateParamsMessage>?>(
                "messages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Set of 16 key-value pairs that can be attached to an object. This can be useful
    /// for storing additional information about the object in a structured format,
    /// and querying for objects via API or the dashboard.  Keys are strings with
    /// a maximum length of 64 characters. Values are strings with a maximum length
    /// of 512 characters.
    /// </summary>
    public IReadOnlyDictionary<string, JsonValueInput?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "metadata"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Output types that you would like the model to generate. Most models are capable
    /// of generating text, which is the default:  `["text"]`  The `gpt-4o-audio-preview`
    /// model can also be used to [generate audio](/docs/guides/audio). To request
    /// that this model generate both text and audio responses, you can use:  `["text",
    /// "audio"]`
    /// </summary>
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

    /// <summary>
    /// Model attributes for routing. Maps model IDs to attribute dictionaries with
    /// values in [0.0, 1.0].
    /// </summary>
    public IReadOnlyDictionary<string, IReadOnlyDictionary<string, double>>? ModelAttributes
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableClass<
                FrozenDictionary<string, FrozenDictionary<string, double>>
            >("model_attributes");
            if (value == null)
            {
                return null;
            }

            return FrozenDictionary.ToFrozenDictionary(
                value,
                entry => entry.Key,
                (entry) => (IReadOnlyDictionary<string, double>)entry.Value
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, FrozenDictionary<string, double>>?>(
                "model_attributes",
                value == null
                    ? null
                    : FrozenDictionary.ToFrozenDictionary(
                        value,
                        entry => entry.Key,
                        (entry) => FrozenDictionary.ToFrozenDictionary(entry.Value)
                    )
            );
        }
    }

    /// <summary>
    /// How many chat completion choices to generate for each input message. Note
    /// that you will be charged based on the number of generated tokens across all
    /// of the choices. Keep `n` as `1` to minimize costs.
    /// </summary>
    public long? N
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("n");
        }
        init { this._rawData.Set("n", value); }
    }

    public IReadOnlyDictionary<string, JsonValueInput?>? OutputConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "output_config"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "output_config",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Whether to enable parallel tool calls (Anthropic uses inverted polarity).
    /// </summary>
    public bool? ParallelToolCalls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("parallel_tool_calls");
        }
        init { this._rawData.Set("parallel_tool_calls", value); }
    }

    /// <summary>
    /// Static predicted output content, such as the content of a text file that is
    /// being regenerated.
    ///
    /// <para>Fields: - type (required): Literal["content"] - content (required):
    /// str | Annotated[list[ChatCompletionRequestMessageContentPartText], MinLen(1), ArrayTitle("PredictionContentArray")]</para>
    /// </summary>
    public PredictionContent? Prediction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PredictionContent>("prediction");
        }
        init { this._rawData.Set("prediction", value); }
    }

    /// <summary>
    /// Number between -2.0 and 2.0. Positive values penalize new tokens based on
    /// whether they appear in the text so far, increasing the model's likelihood
    /// to talk about new topics.
    /// </summary>
    public double? PresencePenalty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("presence_penalty");
        }
        init { this._rawData.Set("presence_penalty", value); }
    }

    /// <summary>
    /// Used by OpenAI to cache responses for similar requests to optimize your cache
    /// hit rates. Replaces the `user` field. [Learn more](/docs/guides/prompt-caching).
    /// </summary>
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
    /// The retention policy for the prompt cache. Set to `24h` to enable extended
    /// prompt caching, which keeps cached prefixes active for longer, up to a maximum
    /// of 24 hours. [Learn more](/docs/guides/prompt-caching#prompt-cache-retention).
    /// </summary>
    public string? PromptCacheRetention
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prompt_cache_retention");
        }
        init { this._rawData.Set("prompt_cache_retention", value); }
    }

    /// <summary>
    /// Allows toggling between the reasoning mode and no system prompt. When set
    /// to `reasoning` the system prompt for reasoning models will be used.
    /// </summary>
    public ApiEnum<string, ChatCompletionCreateParamsPromptMode>? PromptMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ChatCompletionCreateParamsPromptMode>
            >("prompt_mode");
        }
        init { this._rawData.Set("prompt_mode", value); }
    }

    /// <summary>
    /// Constrains effort on reasoning for [reasoning models](https://platform.openai.com/docs/guides/reasoning).
    /// Currently supported values are `none`, `minimal`, `low`, `medium`, `high`,
    /// and `xhigh`. Reducing reasoning effort can result in faster responses and
    /// fewer tokens used on reasoning in a response.  - `gpt-5.1` defaults to `none`,
    /// which does not perform reasoning. The supported reasoning values for `gpt-5.1`
    /// are `none`, `low`, `medium`, and `high`. Tool calls are supported for all
    /// reasoning values in gpt-5.1. - All models before `gpt-5.1` default to `medium`
    /// reasoning effort, and do not support `none`. - The `gpt-5-pro` model defaults
    /// to (and only supports) `high` reasoning effort. - `xhigh` is supported for
    /// all models after `gpt-5.1-codex-max`.
    /// </summary>
    public string? ReasoningEffort
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reasoning_effort");
        }
        init { this._rawData.Set("reasoning_effort", value); }
    }

    /// <summary>
    /// An object specifying the format that the model must output.  Setting to `{
    /// "type": "json_schema", "json_schema": {...} }` enables Structured Outputs
    /// which ensures the model will match your supplied JSON schema. Learn more in
    /// the [Structured Outputs guide](/docs/guides/structured-outputs).  Setting
    /// to `{ "type": "json_object" }` enables the older JSON mode, which ensures
    /// the message the model generates is valid JSON. Using `json_schema` is preferred
    /// for models that support it.
    /// </summary>
    public ChatCompletionCreateParamsResponseFormat? ResponseFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChatCompletionCreateParamsResponseFormat>(
                "response_format"
            );
        }
        init { this._rawData.Set("response_format", value); }
    }

    /// <summary>
    /// Whether to inject a safety prompt before all conversations.
    /// </summary>
    public bool? SafePrompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("safe_prompt");
        }
        init { this._rawData.Set("safe_prompt", value); }
    }

    /// <summary>
    /// A stable identifier used to help detect users of your application that may
    /// be violating OpenAI's usage policies. The IDs should be a string that uniquely
    /// identifies each user. We recommend hashing their username or email address,
    /// in order to avoid sending us any identifying information. [Learn more](/docs/guides/safety-best-practices#safety-identifiers).
    /// </summary>
    public string? SafetyIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("safety_identifier");
        }
        init { this._rawData.Set("safety_identifier", value); }
    }

    /// <summary>
    /// Safety/content filtering settings (Google-specific)
    /// </summary>
    public IReadOnlyList<ChatCompletionCreateParamsSafetySetting>? SafetySettings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ChatCompletionCreateParamsSafetySetting>
            >("safety_settings");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ChatCompletionCreateParamsSafetySetting>?>(
                "safety_settings",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Set the parameters to be used for searched data. If not set, no data will
    /// be acquired by the model.
    /// </summary>
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

    /// <summary>
    /// Random seed for deterministic output
    /// </summary>
    public long? Seed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("seed");
        }
        init { this._rawData.Set("seed", value); }
    }

    /// <summary>
    /// Service tier for request processing
    /// </summary>
    public string? ServiceTier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("service_tier");
        }
        init { this._rawData.Set("service_tier", value); }
    }

    /// <summary>
    /// The inference speed mode for this request. `"fast"` enables high output-tokens-per-second inference.
    /// </summary>
    public ApiEnum<string, ChatCompletionCreateParamsSpeed>? Speed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ChatCompletionCreateParamsSpeed>>(
                "speed"
            );
        }
        init { this._rawData.Set("speed", value); }
    }

    /// <summary>
    /// Sequences that stop generation
    /// </summary>
    public ChatCompletionCreateParamsStop? Stop
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChatCompletionCreateParamsStop>("stop");
        }
        init { this._rawData.Set("stop", value); }
    }

    /// <summary>
    /// Whether or not to store the output of this chat completion request for use
    /// in our [model distillation](/docs/guides/distillation) or [evals](/docs/guides/evals)
    /// products.  Supports text and image inputs. Note: image inputs over 8MB will
    /// be dropped.
    /// </summary>
    public bool? Store
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("store");
        }
        init { this._rawData.Set("store", value); }
    }

    /// <summary>
    /// Enable streaming response
    /// </summary>
    public bool? Stream
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("stream");
        }
        init { this._rawData.Set("stream", value); }
    }

    /// <summary>
    /// Options for streaming response. Only set this when you set `stream: true`.
    /// </summary>
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

    /// <summary>
    /// System instruction/prompt
    /// </summary>
    public ChatCompletionCreateParamsSystemInstruction? SystemInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChatCompletionCreateParamsSystemInstruction>(
                "system_instruction"
            );
        }
        init { this._rawData.Set("system_instruction", value); }
    }

    /// <summary>
    /// Sampling temperature (0-2 for most providers)
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
    /// Extended thinking configuration (Anthropic-specific)
    /// </summary>
    public ChatCompletionCreateParamsThinking? Thinking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChatCompletionCreateParamsThinking>("thinking");
        }
        init { this._rawData.Set("thinking", value); }
    }

    /// <summary>
    /// Controls which (if any) tool is called by the model. `none` means the model
    /// will not call any tool and instead generates a message. `auto` means the model
    /// can pick between generating a message or calling one or more tools. `required`
    /// means the model must call one or more tools. Specifying a particular tool
    /// via `{"type": "function", "function": {"name": "my_function"}}` forces the
    /// model to call that tool.  `none` is the default when no tools are present.
    /// `auto` is the default if tools are present.
    /// </summary>
    public ChatCompletionCreateParamsToolChoice? ToolChoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChatCompletionCreateParamsToolChoice>(
                "tool_choice"
            );
        }
        init { this._rawData.Set("tool_choice", value); }
    }

    /// <summary>
    /// Tool calling configuration (Google-specific)
    /// </summary>
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

    /// <summary>
    /// Available tools/functions for the model
    /// </summary>
    public IReadOnlyList<ChatCompletionToolParam>? Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ChatCompletionToolParam>>(
                "tools"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ChatCompletionToolParam>?>(
                "tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Top-k sampling parameter
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
    /// An integer between 0 and 20 specifying the number of most likely tokens to
    /// return at each token position, each with an associated log probability. `logprobs`
    /// must be set to `true` if this parameter is used.
    /// </summary>
    public long? TopLogprobs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("top_logprobs");
        }
        init { this._rawData.Set("top_logprobs", value); }
    }

    /// <summary>
    /// Nucleus sampling threshold
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

    /// <summary>
    /// This field is being replaced by `safety_identifier` and `prompt_cache_key`.
    /// Use `prompt_cache_key` instead to maintain caching optimizations. A stable
    /// identifier for your end-users. Used to boost cache hit rates by better bucketing
    /// similar requests and  to help OpenAI detect and prevent abuse. [Learn more](/docs/guides/safety-best-practices#safety-identifiers).
    /// </summary>
    public string? User
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user");
        }
        init { this._rawData.Set("user", value); }
    }

    /// <summary>
    /// Constrains the verbosity of the model's response. Lower values will result
    /// in more concise responses, while higher values will result in more verbose
    /// responses. Currently supported values are `low`, `medium`, and `high`.
    /// </summary>
    public string? Verbosity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("verbosity");
        }
        init { this._rawData.Set("verbosity", value); }
    }

    /// <summary>
    /// This tool searches the web for relevant results to use in a response. Learn
    /// more about the [web search tool](/docs/guides/tools-web-search?api-mode=chat).
    /// </summary>
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
        this.Model.Validate();
        _ = this.AgentAttributes;
        this.Audio?.Validate();
        _ = this.AutomaticToolExecution;
        _ = this.CachedContent;
        _ = this.CorrelationID;
        this.Credentials?.Validate();
        _ = this.Deferred;
        foreach (var item in this.DeferredCalls ?? [])
        {
            item.Validate();
        }
        _ = this.FrequencyPenalty;
        _ = this.FunctionCall;
        foreach (var item in this.Functions ?? [])
        {
            item.Validate();
        }
        if (this.GenerationConfig != null)
        {
            foreach (var item in this.GenerationConfig.Values)
            {
                item?.Validate();
            }
        }
        _ = this.Guardrails;
        _ = this.HandoffConfig;
        _ = this.HandoffMode;
        _ = this.InferenceGeo;
        _ = this.LogitBias;
        _ = this.Logprobs;
        _ = this.MaxCompletionTokens;
        _ = this.MaxTokens;
        _ = this.MaxTurns;
        this.McpServers?.Validate();
        foreach (var item in this.Messages ?? [])
        {
            item.Validate();
        }
        if (this.Metadata != null)
        {
            foreach (var item in this.Metadata.Values)
            {
                item?.Validate();
            }
        }
        _ = this.Modalities;
        _ = this.ModelAttributes;
        _ = this.N;
        if (this.OutputConfig != null)
        {
            foreach (var item in this.OutputConfig.Values)
            {
                item?.Validate();
            }
        }
        _ = this.ParallelToolCalls;
        this.Prediction?.Validate();
        _ = this.PresencePenalty;
        _ = this.PromptCacheKey;
        _ = this.PromptCacheRetention;
        this.PromptMode?.Validate();
        _ = this.ReasoningEffort;
        this.ResponseFormat?.Validate();
        _ = this.SafePrompt;
        _ = this.SafetyIdentifier;
        foreach (var item in this.SafetySettings ?? [])
        {
            item.Validate();
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
        this.Speed?.Validate();
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
        this.SystemInstruction?.Validate();
        _ = this.Temperature;
        this.Thinking?.Validate();
        this.ToolChoice?.Validate();
        if (this.ToolConfig != null)
        {
            foreach (var item in this.ToolConfig.Values)
            {
                item?.Validate();
            }
        }
        foreach (var item in this.Tools ?? [])
        {
            item.Validate();
        }
        _ = this.TopK;
        _ = this.TopLogprobs;
        _ = this.TopP;
        _ = this.User;
        _ = this.Verbosity;
        if (this.WebSearchOptions != null)
        {
            foreach (var item in this.WebSearchOptions.Values)
            {
                item?.Validate();
            }
        }
    }

    public ChatCompletionCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCompletionCreateParams(ChatCompletionCreateParams chatCompletionCreateParams)
        : base(chatCompletionCreateParams) { }
#pragma warning restore CS8618

    public ChatCompletionCreateParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCompletionCreateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCompletionCreateParamsFromRaw.FromRawUnchecked"/>
    public static ChatCompletionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChatCompletionCreateParams(ChatCompletionCreateParamsModel model)
        : this()
    {
        this.Model = model;
    }
}

class ChatCompletionCreateParamsFromRaw : IFromRawJson<ChatCompletionCreateParams>
{
    /// <inheritdoc/>
    public ChatCompletionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCompletionCreateParams.FromRawUnchecked(rawData);
}

/// <summary>
/// Model identifier. Accepts model ID strings, lists for routing, or DedalusModel
/// objects with per-model settings.
/// </summary>
[JsonConverter(typeof(ChatCompletionCreateParamsModelConverter))]
public record class ChatCompletionCreateParamsModel : ModelBase
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

    public ChatCompletionCreateParamsModel(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsModel(DedalusModel value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsModel(
        IReadOnlyList<DedalusModelChoice> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ChatCompletionCreateParamsModel(JsonElement element)
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
    /// if (instance.TryPickID(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickID([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DedalusModel"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDedalus(out var value)) {
    ///     // `value` is of type `DedalusModel`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDedalus([NotNullWhen(true)] out DedalusModel? value)
    {
        value = this.Value as DedalusModel;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>DedalusModelChoice</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDedalusModelChoices(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;DedalusModelChoice&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDedalusModelChoices(
        [NotNullWhen(true)] out IReadOnlyList<DedalusModelChoice>? value
    )
    {
        value = this.Value as IReadOnlyList<DedalusModelChoice>;
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
    ///     (DedalusModel value) =&gt; {...},
    ///     (IReadOnlyList&lt;DedalusModelChoice&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @modelID,
        System::Action<DedalusModel> dedalus,
        System::Action<IReadOnlyList<DedalusModelChoice>> dedalusModelChoices
    )
    {
        switch (this.Value)
        {
            case string value:
                @modelID(value);
                break;
            case DedalusModel value:
                dedalus(value);
                break;
            case IReadOnlyList<DedalusModelChoice> value:
                dedalusModelChoices(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of ChatCompletionCreateParamsModel"
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
    ///     (DedalusModel value) =&gt; {...},
    ///     (IReadOnlyList&lt;DedalusModelChoice&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @modelID,
        System::Func<DedalusModel, T> dedalus,
        System::Func<IReadOnlyList<DedalusModelChoice>, T> dedalusModelChoices
    )
    {
        return this.Value switch
        {
            string value => @modelID(value),
            DedalusModel value => dedalus(value),
            IReadOnlyList<DedalusModelChoice> value => dedalusModelChoices(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of ChatCompletionCreateParamsModel"
            ),
        };
    }

    public static implicit operator ChatCompletionCreateParamsModel(string value) => new(value);

    public static implicit operator ChatCompletionCreateParamsModel(DedalusModel value) =>
        new(value);

    public static implicit operator ChatCompletionCreateParamsModel(
        List<DedalusModelChoice> value
    ) => new((IReadOnlyList<DedalusModelChoice>)value);

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
                "Data did not match any variant of ChatCompletionCreateParamsModel"
            );
        }
        this.Switch(
            (_) => { },
            (dedalus) => dedalus.Validate(),
            (dedalusModelChoices) =>
            {
                foreach (var item in dedalusModelChoices)
                {
                    item.Validate();
                }
            }
        );
    }

    public virtual bool Equals(ChatCompletionCreateParamsModel? other) =>
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
            DedalusModel _ => 1,
            IReadOnlyList<DedalusModelChoice> _ => 2,
            _ => -1,
        };
    }
}

sealed class ChatCompletionCreateParamsModelConverter
    : JsonConverter<ChatCompletionCreateParamsModel>
{
    public override ChatCompletionCreateParamsModel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<DedalusModel>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

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
            var deserialized = JsonSerializer.Deserialize<List<DedalusModelChoice>>(
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
        ChatCompletionCreateParamsModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Credentials for MCP server authentication. Each credential is matched to servers
/// by connection name.
/// </summary>
[JsonConverter(typeof(ChatCompletionCreateParamsCredentialsConverter))]
public record class ChatCompletionCreateParamsCredentials : ModelBase
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

    public ChatCompletionCreateParamsCredentials(Credential value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsCredentials(
        IReadOnlyList<Credential> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ChatCompletionCreateParamsCredentials(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Credential"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCredential(out var value)) {
    ///     // `value` is of type `Credential`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCredential([NotNullWhen(true)] out Credential? value)
    {
        value = this.Value as Credential;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>Credential</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMcp(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;Credential&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMcp([NotNullWhen(true)] out IReadOnlyList<Credential>? value)
    {
        value = this.Value as IReadOnlyList<Credential>;
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
    ///     (Credential value) =&gt; {...},
    ///     (IReadOnlyList&lt;Credential&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<Credential> credential,
        System::Action<IReadOnlyList<Credential>> mcpCredentials
    )
    {
        switch (this.Value)
        {
            case Credential value:
                credential(value);
                break;
            case IReadOnlyList<Credential> value:
                mcpCredentials(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of ChatCompletionCreateParamsCredentials"
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
    ///     (Credential value) =&gt; {...},
    ///     (IReadOnlyList&lt;Credential&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<Credential, T> credential,
        System::Func<IReadOnlyList<Credential>, T> mcpCredentials
    )
    {
        return this.Value switch
        {
            Credential value => credential(value),
            IReadOnlyList<Credential> value => mcpCredentials(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of ChatCompletionCreateParamsCredentials"
            ),
        };
    }

    public static implicit operator ChatCompletionCreateParamsCredentials(Credential value) =>
        new(value);

    public static implicit operator ChatCompletionCreateParamsCredentials(List<Credential> value) =>
        new((IReadOnlyList<Credential>)value);

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
                "Data did not match any variant of ChatCompletionCreateParamsCredentials"
            );
        }
        this.Switch(
            (credential) => credential.Validate(),
            (mcpCredentials) =>
            {
                foreach (var item in mcpCredentials)
                {
                    item.Validate();
                }
            }
        );
    }

    public virtual bool Equals(ChatCompletionCreateParamsCredentials? other) =>
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
            Credential _ => 0,
            IReadOnlyList<Credential> _ => 1,
            _ => -1,
        };
    }
}

sealed class ChatCompletionCreateParamsCredentialsConverter
    : JsonConverter<ChatCompletionCreateParamsCredentials?>
{
    public override ChatCompletionCreateParamsCredentials? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Credential>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Credential>>(element, options);
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
        ChatCompletionCreateParamsCredentials? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// MCP server identifiers. Accepts marketplace slugs, URLs, or MCPServerSpec objects.
/// MCP tools are executed server-side and billed separately.
/// </summary>
[JsonConverter(typeof(ChatCompletionCreateParamsMcpServersConverter))]
public record class ChatCompletionCreateParamsMcpServers : ModelBase
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

    public ChatCompletionCreateParamsMcpServers(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsMcpServers(McpServerSpec value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsMcpServers(
        IReadOnlyList<UnnamedSchemaWithArrayParent0> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ChatCompletionCreateParamsMcpServers(JsonElement element)
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
    /// type <see cref="McpServerSpec"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickServerSpec(out var value)) {
    ///     // `value` is of type `McpServerSpec`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickServerSpec([NotNullWhen(true)] out McpServerSpec? value)
    {
        value = this.Value as McpServerSpec;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>UnnamedSchemaWithArrayParent0</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMcpServers(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;UnnamedSchemaWithArrayParent0&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMcpServers(
        [NotNullWhen(true)] out IReadOnlyList<UnnamedSchemaWithArrayParent0>? value
    )
    {
        value = this.Value as IReadOnlyList<UnnamedSchemaWithArrayParent0>;
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
    ///     (McpServerSpec value) =&gt; {...},
    ///     (IReadOnlyList&lt;UnnamedSchemaWithArrayParent0&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<McpServerSpec> serverSpec,
        System::Action<IReadOnlyList<UnnamedSchemaWithArrayParent0>> mcpServers
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case McpServerSpec value:
                serverSpec(value);
                break;
            case IReadOnlyList<UnnamedSchemaWithArrayParent0> value:
                mcpServers(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of ChatCompletionCreateParamsMcpServers"
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
    ///     (McpServerSpec value) =&gt; {...},
    ///     (IReadOnlyList&lt;UnnamedSchemaWithArrayParent0&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<McpServerSpec, T> serverSpec,
        System::Func<IReadOnlyList<UnnamedSchemaWithArrayParent0>, T> mcpServers
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            McpServerSpec value => serverSpec(value),
            IReadOnlyList<UnnamedSchemaWithArrayParent0> value => mcpServers(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of ChatCompletionCreateParamsMcpServers"
            ),
        };
    }

    public static implicit operator ChatCompletionCreateParamsMcpServers(string value) =>
        new(value);

    public static implicit operator ChatCompletionCreateParamsMcpServers(McpServerSpec value) =>
        new(value);

    public static implicit operator ChatCompletionCreateParamsMcpServers(
        List<UnnamedSchemaWithArrayParent0> value
    ) => new((IReadOnlyList<UnnamedSchemaWithArrayParent0>)value);

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
                "Data did not match any variant of ChatCompletionCreateParamsMcpServers"
            );
        }
        this.Switch(
            (_) => { },
            (serverSpec) => serverSpec.Validate(),
            (mcpServers) =>
            {
                foreach (var item in mcpServers)
                {
                    item.Validate();
                }
            }
        );
    }

    public virtual bool Equals(ChatCompletionCreateParamsMcpServers? other) =>
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
            McpServerSpec _ => 1,
            IReadOnlyList<UnnamedSchemaWithArrayParent0> _ => 2,
            _ => -1,
        };
    }
}

sealed class ChatCompletionCreateParamsMcpServersConverter
    : JsonConverter<ChatCompletionCreateParamsMcpServers?>
{
    public override ChatCompletionCreateParamsMcpServers? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<McpServerSpec>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

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
            var deserialized = JsonSerializer.Deserialize<List<UnnamedSchemaWithArrayParent0>>(
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
        ChatCompletionCreateParamsMcpServers? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Developer-provided instructions that the model should follow, regardless of messages
/// sent by the user. With o1 models and newer, `developer` messages replace the previous
/// `system` messages.
///
/// <para>Fields: - content (required): str | Annotated[list[ChatCompletionRequestMessageContentPartText],
/// MinLen(1), ArrayTitle("ChatCompletionRequestDeveloperMessageContentArray")] -
/// role (required): Literal["developer"] - name (optional): str</para>
/// </summary>
[JsonConverter(typeof(ChatCompletionCreateParamsMessageConverter))]
public record class ChatCompletionCreateParamsMessage : ModelBase
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

    public JsonElement Role
    {
        get
        {
            return Match(
                chatCompletionDeveloperMessageParam: (x) => x.Role,
                chatCompletionSystemMessageParam: (x) => x.Role,
                chatCompletionUserMessageParam: (x) => x.Role,
                chatCompletionAssistantMessageParam: (x) => x.Role,
                chatCompletionToolMessageParam: (x) => x.Role,
                chatCompletionFunctionMessageParam: (x) => x.Role
            );
        }
    }

    public string? Name
    {
        get
        {
            return Match<string?>(
                chatCompletionDeveloperMessageParam: (x) => x.Name,
                chatCompletionSystemMessageParam: (x) => x.Name,
                chatCompletionUserMessageParam: (x) => x.Name,
                chatCompletionAssistantMessageParam: (x) => x.Name,
                chatCompletionToolMessageParam: (_) => null,
                chatCompletionFunctionMessageParam: (x) => x.Name
            );
        }
    }

    public ChatCompletionCreateParamsMessage(
        ChatCompletionDeveloperMessageParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsMessage(
        ChatCompletionSystemMessageParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsMessage(
        ChatCompletionUserMessageParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsMessage(
        ChatCompletionAssistantMessageParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsMessage(
        ChatCompletionToolMessageParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsMessage(
        ChatCompletionFunctionMessageParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsMessage(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ChatCompletionDeveloperMessageParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChatCompletionDeveloperMessageParam(out var value)) {
    ///     // `value` is of type `ChatCompletionDeveloperMessageParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChatCompletionDeveloperMessageParam(
        [NotNullWhen(true)] out ChatCompletionDeveloperMessageParam? value
    )
    {
        value = this.Value as ChatCompletionDeveloperMessageParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ChatCompletionSystemMessageParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChatCompletionSystemMessageParam(out var value)) {
    ///     // `value` is of type `ChatCompletionSystemMessageParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChatCompletionSystemMessageParam(
        [NotNullWhen(true)] out ChatCompletionSystemMessageParam? value
    )
    {
        value = this.Value as ChatCompletionSystemMessageParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ChatCompletionUserMessageParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChatCompletionUserMessageParam(out var value)) {
    ///     // `value` is of type `ChatCompletionUserMessageParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChatCompletionUserMessageParam(
        [NotNullWhen(true)] out ChatCompletionUserMessageParam? value
    )
    {
        value = this.Value as ChatCompletionUserMessageParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ChatCompletionAssistantMessageParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChatCompletionAssistantMessageParam(out var value)) {
    ///     // `value` is of type `ChatCompletionAssistantMessageParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChatCompletionAssistantMessageParam(
        [NotNullWhen(true)] out ChatCompletionAssistantMessageParam? value
    )
    {
        value = this.Value as ChatCompletionAssistantMessageParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ChatCompletionToolMessageParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChatCompletionToolMessageParam(out var value)) {
    ///     // `value` is of type `ChatCompletionToolMessageParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChatCompletionToolMessageParam(
        [NotNullWhen(true)] out ChatCompletionToolMessageParam? value
    )
    {
        value = this.Value as ChatCompletionToolMessageParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ChatCompletionFunctionMessageParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChatCompletionFunctionMessageParam(out var value)) {
    ///     // `value` is of type `ChatCompletionFunctionMessageParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChatCompletionFunctionMessageParam(
        [NotNullWhen(true)] out ChatCompletionFunctionMessageParam? value
    )
    {
        value = this.Value as ChatCompletionFunctionMessageParam;
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
    ///     (ChatCompletionDeveloperMessageParam value) =&gt; {...},
    ///     (ChatCompletionSystemMessageParam value) =&gt; {...},
    ///     (ChatCompletionUserMessageParam value) =&gt; {...},
    ///     (ChatCompletionAssistantMessageParam value) =&gt; {...},
    ///     (ChatCompletionToolMessageParam value) =&gt; {...},
    ///     (ChatCompletionFunctionMessageParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ChatCompletionDeveloperMessageParam> chatCompletionDeveloperMessageParam,
        System::Action<ChatCompletionSystemMessageParam> chatCompletionSystemMessageParam,
        System::Action<ChatCompletionUserMessageParam> chatCompletionUserMessageParam,
        System::Action<ChatCompletionAssistantMessageParam> chatCompletionAssistantMessageParam,
        System::Action<ChatCompletionToolMessageParam> chatCompletionToolMessageParam,
        System::Action<ChatCompletionFunctionMessageParam> chatCompletionFunctionMessageParam
    )
    {
        switch (this.Value)
        {
            case ChatCompletionDeveloperMessageParam value:
                chatCompletionDeveloperMessageParam(value);
                break;
            case ChatCompletionSystemMessageParam value:
                chatCompletionSystemMessageParam(value);
                break;
            case ChatCompletionUserMessageParam value:
                chatCompletionUserMessageParam(value);
                break;
            case ChatCompletionAssistantMessageParam value:
                chatCompletionAssistantMessageParam(value);
                break;
            case ChatCompletionToolMessageParam value:
                chatCompletionToolMessageParam(value);
                break;
            case ChatCompletionFunctionMessageParam value:
                chatCompletionFunctionMessageParam(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of ChatCompletionCreateParamsMessage"
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
    ///     (ChatCompletionDeveloperMessageParam value) =&gt; {...},
    ///     (ChatCompletionSystemMessageParam value) =&gt; {...},
    ///     (ChatCompletionUserMessageParam value) =&gt; {...},
    ///     (ChatCompletionAssistantMessageParam value) =&gt; {...},
    ///     (ChatCompletionToolMessageParam value) =&gt; {...},
    ///     (ChatCompletionFunctionMessageParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ChatCompletionDeveloperMessageParam, T> chatCompletionDeveloperMessageParam,
        System::Func<ChatCompletionSystemMessageParam, T> chatCompletionSystemMessageParam,
        System::Func<ChatCompletionUserMessageParam, T> chatCompletionUserMessageParam,
        System::Func<ChatCompletionAssistantMessageParam, T> chatCompletionAssistantMessageParam,
        System::Func<ChatCompletionToolMessageParam, T> chatCompletionToolMessageParam,
        System::Func<ChatCompletionFunctionMessageParam, T> chatCompletionFunctionMessageParam
    )
    {
        return this.Value switch
        {
            ChatCompletionDeveloperMessageParam value => chatCompletionDeveloperMessageParam(value),
            ChatCompletionSystemMessageParam value => chatCompletionSystemMessageParam(value),
            ChatCompletionUserMessageParam value => chatCompletionUserMessageParam(value),
            ChatCompletionAssistantMessageParam value => chatCompletionAssistantMessageParam(value),
            ChatCompletionToolMessageParam value => chatCompletionToolMessageParam(value),
            ChatCompletionFunctionMessageParam value => chatCompletionFunctionMessageParam(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of ChatCompletionCreateParamsMessage"
            ),
        };
    }

    public static implicit operator ChatCompletionCreateParamsMessage(
        ChatCompletionDeveloperMessageParam value
    ) => new(value);

    public static implicit operator ChatCompletionCreateParamsMessage(
        ChatCompletionSystemMessageParam value
    ) => new(value);

    public static implicit operator ChatCompletionCreateParamsMessage(
        ChatCompletionUserMessageParam value
    ) => new(value);

    public static implicit operator ChatCompletionCreateParamsMessage(
        ChatCompletionAssistantMessageParam value
    ) => new(value);

    public static implicit operator ChatCompletionCreateParamsMessage(
        ChatCompletionToolMessageParam value
    ) => new(value);

    public static implicit operator ChatCompletionCreateParamsMessage(
        ChatCompletionFunctionMessageParam value
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
                "Data did not match any variant of ChatCompletionCreateParamsMessage"
            );
        }
        this.Switch(
            (chatCompletionDeveloperMessageParam) => chatCompletionDeveloperMessageParam.Validate(),
            (chatCompletionSystemMessageParam) => chatCompletionSystemMessageParam.Validate(),
            (chatCompletionUserMessageParam) => chatCompletionUserMessageParam.Validate(),
            (chatCompletionAssistantMessageParam) => chatCompletionAssistantMessageParam.Validate(),
            (chatCompletionToolMessageParam) => chatCompletionToolMessageParam.Validate(),
            (chatCompletionFunctionMessageParam) => chatCompletionFunctionMessageParam.Validate()
        );
    }

    public virtual bool Equals(ChatCompletionCreateParamsMessage? other) =>
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
            ChatCompletionDeveloperMessageParam _ => 0,
            ChatCompletionSystemMessageParam _ => 1,
            ChatCompletionUserMessageParam _ => 2,
            ChatCompletionAssistantMessageParam _ => 3,
            ChatCompletionToolMessageParam _ => 4,
            ChatCompletionFunctionMessageParam _ => 5,
            _ => -1,
        };
    }
}

sealed class ChatCompletionCreateParamsMessageConverter
    : JsonConverter<ChatCompletionCreateParamsMessage>
{
    public override ChatCompletionCreateParamsMessage? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? role;
        try
        {
            role = element.GetProperty("role").GetString();
        }
        catch
        {
            role = null;
        }

        switch (role)
        {
            case "developer":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ChatCompletionDeveloperMessageParam>(
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
            case "system":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ChatCompletionSystemMessageParam>(
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
            case "user":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ChatCompletionUserMessageParam>(
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
            case "assistant":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ChatCompletionAssistantMessageParam>(
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
            case "tool":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ChatCompletionToolMessageParam>(
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
            case "function":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ChatCompletionFunctionMessageParam>(
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
                return new ChatCompletionCreateParamsMessage(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChatCompletionCreateParamsMessage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Allows toggling between the reasoning mode and no system prompt. When set to `reasoning`
/// the system prompt for reasoning models will be used.
/// </summary>
[JsonConverter(typeof(ChatCompletionCreateParamsPromptModeConverter))]
public enum ChatCompletionCreateParamsPromptMode
{
    Reasoning,
}

sealed class ChatCompletionCreateParamsPromptModeConverter
    : JsonConverter<ChatCompletionCreateParamsPromptMode>
{
    public override ChatCompletionCreateParamsPromptMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "reasoning" => ChatCompletionCreateParamsPromptMode.Reasoning,
            _ => (ChatCompletionCreateParamsPromptMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChatCompletionCreateParamsPromptMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChatCompletionCreateParamsPromptMode.Reasoning => "reasoning",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An object specifying the format that the model must output.  Setting to `{ "type":
/// "json_schema", "json_schema": {...} }` enables Structured Outputs which ensures
/// the model will match your supplied JSON schema. Learn more in the [Structured
/// Outputs guide](/docs/guides/structured-outputs).  Setting to `{ "type": "json_object"
/// }` enables the older JSON mode, which ensures the message the model generates
/// is valid JSON. Using `json_schema` is preferred for models that support it.
/// </summary>
[JsonConverter(typeof(ChatCompletionCreateParamsResponseFormatConverter))]
public record class ChatCompletionCreateParamsResponseFormat : ModelBase
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
            return Match(text: (x) => x.Type, jsonSchema: (x) => x.Type, jsonObject: (x) => x.Type);
        }
    }

    public ChatCompletionCreateParamsResponseFormat(
        ResponseFormatText value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsResponseFormat(
        ResponseFormatJsonSchema value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsResponseFormat(
        ResponseFormatJsonObject value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsResponseFormat(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ResponseFormatText"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickText(out var value)) {
    ///     // `value` is of type `ResponseFormatText`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickText([NotNullWhen(true)] out ResponseFormatText? value)
    {
        value = this.Value as ResponseFormatText;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ResponseFormatJsonSchema"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonSchema(out var value)) {
    ///     // `value` is of type `ResponseFormatJsonSchema`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonSchema([NotNullWhen(true)] out ResponseFormatJsonSchema? value)
    {
        value = this.Value as ResponseFormatJsonSchema;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ResponseFormatJsonObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonObject(out var value)) {
    ///     // `value` is of type `ResponseFormatJsonObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonObject([NotNullWhen(true)] out ResponseFormatJsonObject? value)
    {
        value = this.Value as ResponseFormatJsonObject;
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
    ///     (ResponseFormatText value) =&gt; {...},
    ///     (ResponseFormatJsonSchema value) =&gt; {...},
    ///     (ResponseFormatJsonObject value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ResponseFormatText> text,
        System::Action<ResponseFormatJsonSchema> jsonSchema,
        System::Action<ResponseFormatJsonObject> jsonObject
    )
    {
        switch (this.Value)
        {
            case ResponseFormatText value:
                text(value);
                break;
            case ResponseFormatJsonSchema value:
                jsonSchema(value);
                break;
            case ResponseFormatJsonObject value:
                jsonObject(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of ChatCompletionCreateParamsResponseFormat"
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
    ///     (ResponseFormatText value) =&gt; {...},
    ///     (ResponseFormatJsonSchema value) =&gt; {...},
    ///     (ResponseFormatJsonObject value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ResponseFormatText, T> text,
        System::Func<ResponseFormatJsonSchema, T> jsonSchema,
        System::Func<ResponseFormatJsonObject, T> jsonObject
    )
    {
        return this.Value switch
        {
            ResponseFormatText value => text(value),
            ResponseFormatJsonSchema value => jsonSchema(value),
            ResponseFormatJsonObject value => jsonObject(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of ChatCompletionCreateParamsResponseFormat"
            ),
        };
    }

    public static implicit operator ChatCompletionCreateParamsResponseFormat(
        ResponseFormatText value
    ) => new(value);

    public static implicit operator ChatCompletionCreateParamsResponseFormat(
        ResponseFormatJsonSchema value
    ) => new(value);

    public static implicit operator ChatCompletionCreateParamsResponseFormat(
        ResponseFormatJsonObject value
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
                "Data did not match any variant of ChatCompletionCreateParamsResponseFormat"
            );
        }
        this.Switch(
            (text) => text.Validate(),
            (jsonSchema) => jsonSchema.Validate(),
            (jsonObject) => jsonObject.Validate()
        );
    }

    public virtual bool Equals(ChatCompletionCreateParamsResponseFormat? other) =>
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
            ResponseFormatText _ => 0,
            ResponseFormatJsonSchema _ => 1,
            ResponseFormatJsonObject _ => 2,
            _ => -1,
        };
    }
}

sealed class ChatCompletionCreateParamsResponseFormatConverter
    : JsonConverter<ChatCompletionCreateParamsResponseFormat?>
{
    public override ChatCompletionCreateParamsResponseFormat? Read(
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
                    var deserialized = JsonSerializer.Deserialize<ResponseFormatText>(
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
            case "json_schema":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ResponseFormatJsonSchema>(
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
            case "json_object":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ResponseFormatJsonObject>(
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
                return new ChatCompletionCreateParamsResponseFormat(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChatCompletionCreateParamsResponseFormat? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Safety setting, affecting the safety-blocking behavior.
///
/// <para>Passing a safety setting for a category changes the allowed probability
/// that content is blocked.</para>
///
/// <para>Fields: - threshold (required): Literal["HARM_BLOCK_THRESHOLD_UNSPECIFIED",
/// "BLOCK_LOW_AND_ABOVE", "BLOCK_MEDIUM_AND_ABOVE", "BLOCK_ONLY_HIGH", "BLOCK_NONE",
/// "OFF"] - category (required): HarmCategory</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChatCompletionCreateParamsSafetySetting,
        ChatCompletionCreateParamsSafetySettingFromRaw
    >)
)]
public sealed record class ChatCompletionCreateParamsSafetySetting : JsonModel
{
    /// <summary>
    /// Required. The category for this setting.
    /// </summary>
    public required ApiEnum<string, ChatCompletionCreateParamsSafetySettingCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChatCompletionCreateParamsSafetySettingCategory>
            >("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Required. Controls the probability threshold at which harm is blocked.
    /// </summary>
    public required ApiEnum<string, ChatCompletionCreateParamsSafetySettingThreshold> Threshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChatCompletionCreateParamsSafetySettingThreshold>
            >("threshold");
        }
        init { this._rawData.Set("threshold", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.Threshold.Validate();
    }

    public ChatCompletionCreateParamsSafetySetting() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCompletionCreateParamsSafetySetting(
        ChatCompletionCreateParamsSafetySetting chatCompletionCreateParamsSafetySetting
    )
        : base(chatCompletionCreateParamsSafetySetting) { }
#pragma warning restore CS8618

    public ChatCompletionCreateParamsSafetySetting(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCompletionCreateParamsSafetySetting(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCompletionCreateParamsSafetySettingFromRaw.FromRawUnchecked"/>
    public static ChatCompletionCreateParamsSafetySetting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatCompletionCreateParamsSafetySettingFromRaw
    : IFromRawJson<ChatCompletionCreateParamsSafetySetting>
{
    /// <inheritdoc/>
    public ChatCompletionCreateParamsSafetySetting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCompletionCreateParamsSafetySetting.FromRawUnchecked(rawData);
}

/// <summary>
/// Required. The category for this setting.
/// </summary>
[JsonConverter(typeof(ChatCompletionCreateParamsSafetySettingCategoryConverter))]
public enum ChatCompletionCreateParamsSafetySettingCategory
{
    HarmCategoryUnspecified,
    HarmCategoryDerogatory,
    HarmCategoryToxicity,
    HarmCategoryViolence,
    HarmCategorySexual,
    HarmCategoryMedical,
    HarmCategoryDangerous,
    HarmCategoryHarassment,
    HarmCategoryHateSpeech,
    HarmCategorySexuallyExplicit,
    HarmCategoryDangerousContent,
    HarmCategoryCivicIntegrity,
}

sealed class ChatCompletionCreateParamsSafetySettingCategoryConverter
    : JsonConverter<ChatCompletionCreateParamsSafetySettingCategory>
{
    public override ChatCompletionCreateParamsSafetySettingCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "HARM_CATEGORY_UNSPECIFIED" =>
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified,
            "HARM_CATEGORY_DEROGATORY" =>
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryDerogatory,
            "HARM_CATEGORY_TOXICITY" =>
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryToxicity,
            "HARM_CATEGORY_VIOLENCE" =>
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryViolence,
            "HARM_CATEGORY_SEXUAL" =>
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategorySexual,
            "HARM_CATEGORY_MEDICAL" =>
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryMedical,
            "HARM_CATEGORY_DANGEROUS" =>
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryDangerous,
            "HARM_CATEGORY_HARASSMENT" =>
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryHarassment,
            "HARM_CATEGORY_HATE_SPEECH" =>
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryHateSpeech,
            "HARM_CATEGORY_SEXUALLY_EXPLICIT" =>
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategorySexuallyExplicit,
            "HARM_CATEGORY_DANGEROUS_CONTENT" =>
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryDangerousContent,
            "HARM_CATEGORY_CIVIC_INTEGRITY" =>
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryCivicIntegrity,
            _ => (ChatCompletionCreateParamsSafetySettingCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChatCompletionCreateParamsSafetySettingCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryUnspecified =>
                    "HARM_CATEGORY_UNSPECIFIED",
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryDerogatory =>
                    "HARM_CATEGORY_DEROGATORY",
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryToxicity =>
                    "HARM_CATEGORY_TOXICITY",
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryViolence =>
                    "HARM_CATEGORY_VIOLENCE",
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategorySexual =>
                    "HARM_CATEGORY_SEXUAL",
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryMedical =>
                    "HARM_CATEGORY_MEDICAL",
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryDangerous =>
                    "HARM_CATEGORY_DANGEROUS",
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryHarassment =>
                    "HARM_CATEGORY_HARASSMENT",
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryHateSpeech =>
                    "HARM_CATEGORY_HATE_SPEECH",
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategorySexuallyExplicit =>
                    "HARM_CATEGORY_SEXUALLY_EXPLICIT",
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryDangerousContent =>
                    "HARM_CATEGORY_DANGEROUS_CONTENT",
                ChatCompletionCreateParamsSafetySettingCategory.HarmCategoryCivicIntegrity =>
                    "HARM_CATEGORY_CIVIC_INTEGRITY",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Required. Controls the probability threshold at which harm is blocked.
/// </summary>
[JsonConverter(typeof(ChatCompletionCreateParamsSafetySettingThresholdConverter))]
public enum ChatCompletionCreateParamsSafetySettingThreshold
{
    HarmBlockThresholdUnspecified,
    BlockLowAndAbove,
    BlockMediumAndAbove,
    BlockOnlyHigh,
    BlockNone,
    Off,
}

sealed class ChatCompletionCreateParamsSafetySettingThresholdConverter
    : JsonConverter<ChatCompletionCreateParamsSafetySettingThreshold>
{
    public override ChatCompletionCreateParamsSafetySettingThreshold Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "HARM_BLOCK_THRESHOLD_UNSPECIFIED" =>
                ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified,
            "BLOCK_LOW_AND_ABOVE" =>
                ChatCompletionCreateParamsSafetySettingThreshold.BlockLowAndAbove,
            "BLOCK_MEDIUM_AND_ABOVE" =>
                ChatCompletionCreateParamsSafetySettingThreshold.BlockMediumAndAbove,
            "BLOCK_ONLY_HIGH" => ChatCompletionCreateParamsSafetySettingThreshold.BlockOnlyHigh,
            "BLOCK_NONE" => ChatCompletionCreateParamsSafetySettingThreshold.BlockNone,
            "OFF" => ChatCompletionCreateParamsSafetySettingThreshold.Off,
            _ => (ChatCompletionCreateParamsSafetySettingThreshold)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChatCompletionCreateParamsSafetySettingThreshold value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChatCompletionCreateParamsSafetySettingThreshold.HarmBlockThresholdUnspecified =>
                    "HARM_BLOCK_THRESHOLD_UNSPECIFIED",
                ChatCompletionCreateParamsSafetySettingThreshold.BlockLowAndAbove =>
                    "BLOCK_LOW_AND_ABOVE",
                ChatCompletionCreateParamsSafetySettingThreshold.BlockMediumAndAbove =>
                    "BLOCK_MEDIUM_AND_ABOVE",
                ChatCompletionCreateParamsSafetySettingThreshold.BlockOnlyHigh => "BLOCK_ONLY_HIGH",
                ChatCompletionCreateParamsSafetySettingThreshold.BlockNone => "BLOCK_NONE",
                ChatCompletionCreateParamsSafetySettingThreshold.Off => "OFF",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The inference speed mode for this request. `"fast"` enables high output-tokens-per-second inference.
/// </summary>
[JsonConverter(typeof(ChatCompletionCreateParamsSpeedConverter))]
public enum ChatCompletionCreateParamsSpeed
{
    Standard,
    Fast,
}

sealed class ChatCompletionCreateParamsSpeedConverter
    : JsonConverter<ChatCompletionCreateParamsSpeed>
{
    public override ChatCompletionCreateParamsSpeed Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => ChatCompletionCreateParamsSpeed.Standard,
            "fast" => ChatCompletionCreateParamsSpeed.Fast,
            _ => (ChatCompletionCreateParamsSpeed)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChatCompletionCreateParamsSpeed value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChatCompletionCreateParamsSpeed.Standard => "standard",
                ChatCompletionCreateParamsSpeed.Fast => "fast",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Sequences that stop generation
/// </summary>
[JsonConverter(typeof(ChatCompletionCreateParamsStopConverter))]
public record class ChatCompletionCreateParamsStop : ModelBase
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

    public ChatCompletionCreateParamsStop(IReadOnlyList<string> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ChatCompletionCreateParamsStop(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsStop(JsonElement element)
    {
        this._element = element;
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
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<IReadOnlyList<string>> strings,
        System::Action<string> @string
    )
    {
        switch (this.Value)
        {
            case IReadOnlyList<string> value:
                strings(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of ChatCompletionCreateParamsStop"
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
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<IReadOnlyList<string>, T> strings,
        System::Func<string, T> @string
    )
    {
        return this.Value switch
        {
            IReadOnlyList<string> value => strings(value),
            string value => @string(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of ChatCompletionCreateParamsStop"
            ),
        };
    }

    public static implicit operator ChatCompletionCreateParamsStop(List<string> value) =>
        new((IReadOnlyList<string>)value);

    public static implicit operator ChatCompletionCreateParamsStop(string value) => new(value);

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
                "Data did not match any variant of ChatCompletionCreateParamsStop"
            );
        }
    }

    public virtual bool Equals(ChatCompletionCreateParamsStop? other) =>
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
            IReadOnlyList<string> _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class ChatCompletionCreateParamsStopConverter
    : JsonConverter<ChatCompletionCreateParamsStop?>
{
    public override ChatCompletionCreateParamsStop? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(element, options);
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

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChatCompletionCreateParamsStop? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// System instruction/prompt
/// </summary>
[JsonConverter(typeof(ChatCompletionCreateParamsSystemInstructionConverter))]
public record class ChatCompletionCreateParamsSystemInstruction : ModelBase
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

    public ChatCompletionCreateParamsSystemInstruction(
        IReadOnlyDictionary<string, JsonValueInput?> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public ChatCompletionCreateParamsSystemInstruction(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsSystemInstruction(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>JsonValueInput?</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonObjectInput(out var value)) {
    ///     // `value` is of type `IReadOnlyDictionary&lt;string, JsonValueInput?&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonObjectInput(
        [NotNullWhen(true)] out IReadOnlyDictionary<string, JsonValueInput?>? value
    )
    {
        value = this.Value as IReadOnlyDictionary<string, JsonValueInput?>;
        return value != null;
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
    ///     (IReadOnlyDictionary&lt;string, JsonValueInput?&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<IReadOnlyDictionary<string, JsonValueInput?>> jsonObjectInput,
        System::Action<string> @string
    )
    {
        switch (this.Value)
        {
            case IReadOnlyDictionary<string, JsonValueInput?> value:
                jsonObjectInput(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of ChatCompletionCreateParamsSystemInstruction"
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
    ///     (IReadOnlyDictionary&lt;string, JsonValueInput?&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<IReadOnlyDictionary<string, JsonValueInput?>, T> jsonObjectInput,
        System::Func<string, T> @string
    )
    {
        return this.Value switch
        {
            IReadOnlyDictionary<string, JsonValueInput?> value => jsonObjectInput(value),
            string value => @string(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of ChatCompletionCreateParamsSystemInstruction"
            ),
        };
    }

    public static implicit operator ChatCompletionCreateParamsSystemInstruction(
        Dictionary<string, JsonValueInput?> value
    ) => new((IReadOnlyDictionary<string, JsonValueInput?>)value);

    public static implicit operator ChatCompletionCreateParamsSystemInstruction(string value) =>
        new(value);

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
                "Data did not match any variant of ChatCompletionCreateParamsSystemInstruction"
            );
        }
        this.Switch(
            (jsonObjectInput) =>
            {
                foreach (var item in jsonObjectInput.Values)
                {
                    item?.Validate();
                }
            },
            (_) => { }
        );
    }

    public virtual bool Equals(ChatCompletionCreateParamsSystemInstruction? other) =>
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
            IReadOnlyDictionary<string, JsonValueInput?> _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class ChatCompletionCreateParamsSystemInstructionConverter
    : JsonConverter<ChatCompletionCreateParamsSystemInstruction?>
{
    public override ChatCompletionCreateParamsSystemInstruction? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonValueInput?>>(
                element,
                options
            );
            if (deserialized != null)
            {
                foreach (var item in deserialized.Values)
                {
                    item?.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

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

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChatCompletionCreateParamsSystemInstruction? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Extended thinking configuration (Anthropic-specific)
/// </summary>
[JsonConverter(typeof(ChatCompletionCreateParamsThinkingConverter))]
public record class ChatCompletionCreateParamsThinking : ModelBase
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

    public JsonElement? Type
    {
        get
        {
            return Match<JsonElement?>(
                configEnabled: (x) => x.Type,
                configDisabled: (x) => x.Type,
                adaptive: (_) => null
            );
        }
    }

    public ChatCompletionCreateParamsThinking(
        ThinkingConfigEnabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsThinking(
        ThinkingConfigDisabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsThinking(
        ChatCompletionCreateParamsThinkingAdaptive value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsThinking(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ThinkingConfigEnabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickConfigEnabled(out var value)) {
    ///     // `value` is of type `ThinkingConfigEnabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickConfigEnabled([NotNullWhen(true)] out ThinkingConfigEnabled? value)
    {
        value = this.Value as ThinkingConfigEnabled;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ThinkingConfigDisabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickConfigDisabled(out var value)) {
    ///     // `value` is of type `ThinkingConfigDisabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickConfigDisabled([NotNullWhen(true)] out ThinkingConfigDisabled? value)
    {
        value = this.Value as ThinkingConfigDisabled;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ChatCompletionCreateParamsThinkingAdaptive"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAdaptive(out var value)) {
    ///     // `value` is of type `ChatCompletionCreateParamsThinkingAdaptive`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAdaptive(
        [NotNullWhen(true)] out ChatCompletionCreateParamsThinkingAdaptive? value
    )
    {
        value = this.Value as ChatCompletionCreateParamsThinkingAdaptive;
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
    ///     (ThinkingConfigEnabled value) =&gt; {...},
    ///     (ThinkingConfigDisabled value) =&gt; {...},
    ///     (ChatCompletionCreateParamsThinkingAdaptive value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ThinkingConfigEnabled> configEnabled,
        System::Action<ThinkingConfigDisabled> configDisabled,
        System::Action<ChatCompletionCreateParamsThinkingAdaptive> adaptive
    )
    {
        switch (this.Value)
        {
            case ThinkingConfigEnabled value:
                configEnabled(value);
                break;
            case ThinkingConfigDisabled value:
                configDisabled(value);
                break;
            case ChatCompletionCreateParamsThinkingAdaptive value:
                adaptive(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of ChatCompletionCreateParamsThinking"
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
    ///     (ThinkingConfigEnabled value) =&gt; {...},
    ///     (ThinkingConfigDisabled value) =&gt; {...},
    ///     (ChatCompletionCreateParamsThinkingAdaptive value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ThinkingConfigEnabled, T> configEnabled,
        System::Func<ThinkingConfigDisabled, T> configDisabled,
        System::Func<ChatCompletionCreateParamsThinkingAdaptive, T> adaptive
    )
    {
        return this.Value switch
        {
            ThinkingConfigEnabled value => configEnabled(value),
            ThinkingConfigDisabled value => configDisabled(value),
            ChatCompletionCreateParamsThinkingAdaptive value => adaptive(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of ChatCompletionCreateParamsThinking"
            ),
        };
    }

    public static implicit operator ChatCompletionCreateParamsThinking(
        ThinkingConfigEnabled value
    ) => new(value);

    public static implicit operator ChatCompletionCreateParamsThinking(
        ThinkingConfigDisabled value
    ) => new(value);

    public static implicit operator ChatCompletionCreateParamsThinking(
        ChatCompletionCreateParamsThinkingAdaptive value
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
                "Data did not match any variant of ChatCompletionCreateParamsThinking"
            );
        }
        this.Switch(
            (configEnabled) => configEnabled.Validate(),
            (configDisabled) => configDisabled.Validate(),
            (adaptive) => adaptive.Validate()
        );
    }

    public virtual bool Equals(ChatCompletionCreateParamsThinking? other) =>
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
            ThinkingConfigEnabled _ => 0,
            ThinkingConfigDisabled _ => 1,
            ChatCompletionCreateParamsThinkingAdaptive _ => 2,
            _ => -1,
        };
    }
}

sealed class ChatCompletionCreateParamsThinkingConverter
    : JsonConverter<ChatCompletionCreateParamsThinking?>
{
    public override ChatCompletionCreateParamsThinking? Read(
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
            case "enabled":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThinkingConfigEnabled>(
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
            case "disabled":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThinkingConfigDisabled>(
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
            case "adaptive":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ChatCompletionCreateParamsThinkingAdaptive>(
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
                return new ChatCompletionCreateParamsThinking(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChatCompletionCreateParamsThinking? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Schema for ThinkingConfigAdaptive.
///
/// <para>Fields: - type (required): Literal["adaptive"]</para>
/// </summary>
[JsonConverter(typeof(ChatCompletionCreateParamsThinkingAdaptiveConverter))]
public record class ChatCompletionCreateParamsThinkingAdaptive
{
    public JsonElement Element { get; private init; }

    public ChatCompletionCreateParamsThinkingAdaptive()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "adaptive"
            }
            """
        );
    }

    internal ChatCompletionCreateParamsThinkingAdaptive(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DedalusInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new ChatCompletionCreateParamsThinkingAdaptive())
        {
            throw new DedalusInvalidDataException(
                "Invalid value given for 'ChatCompletionCreateParamsThinkingAdaptive'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(ChatCompletionCreateParamsThinkingAdaptive? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class ChatCompletionCreateParamsThinkingAdaptiveConverter
    : JsonConverter<ChatCompletionCreateParamsThinkingAdaptive>
{
    public override ChatCompletionCreateParamsThinkingAdaptive? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChatCompletionCreateParamsThinkingAdaptive value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

/// <summary>
/// Controls which (if any) tool is called by the model. `none` means the model will
/// not call any tool and instead generates a message. `auto` means the model can
/// pick between generating a message or calling one or more tools. `required` means
/// the model must call one or more tools. Specifying a particular tool via `{"type":
/// "function", "function": {"name": "my_function"}}` forces the model to call that
/// tool.  `none` is the default when no tools are present. `auto` is the default
/// if tools are present.
/// </summary>
[JsonConverter(typeof(ChatCompletionCreateParamsToolChoiceConverter))]
public record class ChatCompletionCreateParamsToolChoice : ModelBase
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

    public JsonElement? Type
    {
        get
        {
            return Match<JsonElement?>(
                @string: (_) => null,
                auto: (x) => x.Type,
                any: (x) => x.Type,
                tool: (x) => x.Type,
                none: (x) => x.Type
            );
        }
    }

    public bool? DisableParallelToolUse
    {
        get
        {
            return Match<bool?>(
                @string: (_) => null,
                auto: (x) => x.DisableParallelToolUse,
                any: (x) => x.DisableParallelToolUse,
                tool: (x) => x.DisableParallelToolUse,
                none: (_) => null
            );
        }
    }

    public ChatCompletionCreateParamsToolChoice(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsToolChoice(ToolChoiceAuto value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsToolChoice(ToolChoiceAny value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsToolChoice(ToolChoiceTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsToolChoice(ToolChoiceNone value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChatCompletionCreateParamsToolChoice(JsonElement element)
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
    /// type <see cref="ToolChoiceAuto"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAuto(out var value)) {
    ///     // `value` is of type `ToolChoiceAuto`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAuto([NotNullWhen(true)] out ToolChoiceAuto? value)
    {
        value = this.Value as ToolChoiceAuto;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolChoiceAny"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAny(out var value)) {
    ///     // `value` is of type `ToolChoiceAny`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAny([NotNullWhen(true)] out ToolChoiceAny? value)
    {
        value = this.Value as ToolChoiceAny;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolChoiceTool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTool(out var value)) {
    ///     // `value` is of type `ToolChoiceTool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTool([NotNullWhen(true)] out ToolChoiceTool? value)
    {
        value = this.Value as ToolChoiceTool;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolChoiceNone"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNone(out var value)) {
    ///     // `value` is of type `ToolChoiceNone`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNone([NotNullWhen(true)] out ToolChoiceNone? value)
    {
        value = this.Value as ToolChoiceNone;
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
    ///     (ToolChoiceAuto value) =&gt; {...},
    ///     (ToolChoiceAny value) =&gt; {...},
    ///     (ToolChoiceTool value) =&gt; {...},
    ///     (ToolChoiceNone value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<ToolChoiceAuto> auto,
        System::Action<ToolChoiceAny> any,
        System::Action<ToolChoiceTool> tool,
        System::Action<ToolChoiceNone> none
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case ToolChoiceAuto value:
                auto(value);
                break;
            case ToolChoiceAny value:
                any(value);
                break;
            case ToolChoiceTool value:
                tool(value);
                break;
            case ToolChoiceNone value:
                none(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of ChatCompletionCreateParamsToolChoice"
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
    ///     (ToolChoiceAuto value) =&gt; {...},
    ///     (ToolChoiceAny value) =&gt; {...},
    ///     (ToolChoiceTool value) =&gt; {...},
    ///     (ToolChoiceNone value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<ToolChoiceAuto, T> auto,
        System::Func<ToolChoiceAny, T> any,
        System::Func<ToolChoiceTool, T> tool,
        System::Func<ToolChoiceNone, T> none
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            ToolChoiceAuto value => auto(value),
            ToolChoiceAny value => any(value),
            ToolChoiceTool value => tool(value),
            ToolChoiceNone value => none(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of ChatCompletionCreateParamsToolChoice"
            ),
        };
    }

    public static implicit operator ChatCompletionCreateParamsToolChoice(string value) =>
        new(value);

    public static implicit operator ChatCompletionCreateParamsToolChoice(ToolChoiceAuto value) =>
        new(value);

    public static implicit operator ChatCompletionCreateParamsToolChoice(ToolChoiceAny value) =>
        new(value);

    public static implicit operator ChatCompletionCreateParamsToolChoice(ToolChoiceTool value) =>
        new(value);

    public static implicit operator ChatCompletionCreateParamsToolChoice(ToolChoiceNone value) =>
        new(value);

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
                "Data did not match any variant of ChatCompletionCreateParamsToolChoice"
            );
        }
        this.Switch(
            (_) => { },
            (auto) => auto.Validate(),
            (any) => any.Validate(),
            (tool) => tool.Validate(),
            (none) => none.Validate()
        );
    }

    public virtual bool Equals(ChatCompletionCreateParamsToolChoice? other) =>
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
            ToolChoiceAuto _ => 1,
            ToolChoiceAny _ => 2,
            ToolChoiceTool _ => 3,
            ToolChoiceNone _ => 4,
            _ => -1,
        };
    }
}

sealed class ChatCompletionCreateParamsToolChoiceConverter
    : JsonConverter<ChatCompletionCreateParamsToolChoice?>
{
    public override ChatCompletionCreateParamsToolChoice? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolChoiceAuto>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolChoiceAny>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolChoiceTool>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolChoiceNone>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

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

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChatCompletionCreateParamsToolChoice? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
