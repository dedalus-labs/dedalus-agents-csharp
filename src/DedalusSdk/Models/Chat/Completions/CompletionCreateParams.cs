using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;
using DedalusSdk.Exceptions;
using System = System;

namespace DedalusSdk.Models.Chat.Completions;

/// <summary>
/// Create a chat completion.
///
/// <para>Generates a model response for the given conversation and configuration.
/// Supports OpenAI-compatible parameters and provider-specific extensions.</para>
///
/// <para>Headers:   - Authorization: bearer key for the calling account.   - X-Provider
/// / X-Provider-Key: optional headers for using your own provider API key.</para>
///
/// <para>Behavior:   - If multiple models are supplied, the first one is used, and
/// the agent may hand off to another model.   - Tools may be invoked on the server
/// or signaled for the client to run.   - Streaming responses emit incremental deltas;
/// non-streaming returns a single object.   - Usage metrics are computed when available
/// and returned in the response.</para>
///
/// <para>Responses:   - 200 OK: JSON completion object with choices, message content,
/// and usage.   - 400 Bad Request: validation error.   - 401 Unauthorized: authentication
/// failed.   - 402 Payment Required or 429 Too Many Requests: quota, balance, or
/// rate limit issue.   - 500 Internal Server Error: unexpected failure.</para>
///
/// <para>Billing:   - Token usage metered by the selected model(s).   - Tool calls
/// and MCP sessions may be billed separately.   - Streaming is settled after the
/// stream ends via an async task.</para>
///
/// <para>Example (non-streaming HTTP):   POST /v1/chat/completions   Content-Type:
/// application/json   Authorization: Bearer &lt;key&gt;</para>
///
/// <para>  {     "model": "provider/model-name",     "messages": [{"role": "user",
/// "content": "Hello"}]   }</para>
///
/// <para>  200 OK   {     "id": "cmpl_123",     "object": "chat.completion",
/// "choices": [       {"index": 0, "message": {"role": "assistant", "content": "Hi
/// there!"}, "finish_reason": "stop"}     ],     "usage": {"prompt_tokens": 3, "completion_tokens":
/// 4, "total_tokens": 7}   }</para>
///
/// <para>Example (streaming over SSE):   POST /v1/chat/completions   Accept: text/event-stream</para>
///
/// <para>  data: {"id":"cmpl_123","choices":[{"index":0,"delta":{"content":"Hi"}}]}
///   data: {"id":"cmpl_123","choices":[{"index":0,"delta":{"content":" there!"}}]}
///   data: [DONE]</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CompletionCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Model identifier. Accepts model ID strings, lists for routing, or DedalusModel
    /// objects with per-model settings.
    /// </summary>
    public required Model Model
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Model>("model");
        }
        init { this._rawBodyData.Set("model", value); }
    }

    /// <summary>
    /// Agent attributes. Values in [0.0, 1.0].
    /// </summary>
    public IReadOnlyDictionary<string, double>? AgentAttributes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, double>>(
                "agent_attributes"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, double>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ChatCompletionAudioParam>("audio");
        }
        init { this._rawBodyData.Set("audio", value); }
    }

    /// <summary>
    /// Execute tools server-side. If false, returns raw tool calls for manual handling.
    /// </summary>
    public bool? AutomaticToolExecution
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("automatic_tool_execution");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("automatic_tool_execution", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("cached_content");
        }
        init { this._rawBodyData.Set("cached_content", value); }
    }

    /// <summary>
    /// Stable session ID for resuming a previous handoff. Returned by the server
    /// on handoff; echo it on the next request to resume.
    /// </summary>
    public string? CorrelationID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("correlation_id");
        }
        init { this._rawBodyData.Set("correlation_id", value); }
    }

    /// <summary>
    /// Credentials for MCP server authentication. Each credential is matched to
    /// servers by connection name.
    /// </summary>
    public Credentials? Credentials
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Credentials>("credentials");
        }
        init { this._rawBodyData.Set("credentials", value); }
    }

    /// <summary>
    /// If set to `true`, the request returns a `request_id`. You can then get the
    /// deferred response by GET `/v1/chat/deferred-completion/{request_id}`.
    /// </summary>
    public bool? Deferred
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("deferred");
        }
        init { this._rawBodyData.Set("deferred", value); }
    }

    /// <summary>
    /// Tier 2 stateless resumption. Deferred tool specs from a previous handoff response,
    /// sent back verbatim so the server can resume without Redis.
    /// </summary>
    public IReadOnlyList<DeferredCallResponse>? DeferredCalls
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<DeferredCallResponse>>(
                "deferred_calls"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<DeferredCallResponse>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("frequency_penalty");
        }
        init { this._rawBodyData.Set("frequency_penalty", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("function_call");
        }
        init { this._rawBodyData.Set("function_call", value); }
    }

    /// <summary>
    /// Deprecated in favor of `tools`.  A list of functions the model may generate
    /// JSON inputs for.
    /// </summary>
    public IReadOnlyList<ChatCompletionFunctions>? Functions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ChatCompletionFunctions>>(
                "functions"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ChatCompletionFunctions>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "generation_config"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, JsonValueInput?>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<FrozenDictionary<string, JsonElement>>
            >("guardrails");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "handoff_config"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("handoff_mode");
        }
        init { this._rawBodyData.Set("handoff_mode", value); }
    }

    /// <summary>
    /// Specifies the geographic region for inference processing. If not specified,
    /// the workspace's `default_inference_geo` is used.
    /// </summary>
    public string? InferenceGeo
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("inference_geo");
        }
        init { this._rawBodyData.Set("inference_geo", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, long>>("logit_bias");
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, long>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("logprobs");
        }
        init { this._rawBodyData.Set("logprobs", value); }
    }

    /// <summary>
    /// Maximum tokens in completion (newer parameter name)
    /// </summary>
    public long? MaxCompletionTokens
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("max_completion_tokens");
        }
        init { this._rawBodyData.Set("max_completion_tokens", value); }
    }

    /// <summary>
    /// Maximum tokens in completion
    /// </summary>
    public long? MaxTokens
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("max_tokens");
        }
        init { this._rawBodyData.Set("max_tokens", value); }
    }

    /// <summary>
    /// Maximum conversation turns.
    /// </summary>
    public long? MaxTurns
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("max_turns");
        }
        init { this._rawBodyData.Set("max_turns", value); }
    }

    /// <summary>
    /// MCP server identifiers. Accepts marketplace slugs, URLs, or MCPServerSpec
    /// objects. MCP tools are executed server-side and billed separately.
    /// </summary>
    public McpServers? McpServers
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<McpServers>("mcp_servers");
        }
        init { this._rawBodyData.Set("mcp_servers", value); }
    }

    /// <summary>
    /// Conversation history (OpenAI: messages, Google: contents, Responses: input)
    /// </summary>
    public IReadOnlyList<Message>? Messages
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Message>>("messages");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Message>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "metadata"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, JsonValueInput?>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("modalities");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
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
            this._rawBodyData.Freeze();
            var value = this._rawBodyData.GetNullableClass<
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
            this._rawBodyData.Set<FrozenDictionary<string, FrozenDictionary<string, double>>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("n");
        }
        init { this._rawBodyData.Set("n", value); }
    }

    public IReadOnlyDictionary<string, JsonValueInput?>? OutputConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "output_config"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, JsonValueInput?>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("parallel_tool_calls");
        }
        init { this._rawBodyData.Set("parallel_tool_calls", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PredictionContent>("prediction");
        }
        init { this._rawBodyData.Set("prediction", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("presence_penalty");
        }
        init { this._rawBodyData.Set("presence_penalty", value); }
    }

    /// <summary>
    /// Used by OpenAI to cache responses for similar requests to optimize your cache
    /// hit rates. Replaces the `user` field. [Learn more](/docs/guides/prompt-caching).
    /// </summary>
    public string? PromptCacheKey
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("prompt_cache_key");
        }
        init { this._rawBodyData.Set("prompt_cache_key", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("prompt_cache_retention");
        }
        init { this._rawBodyData.Set("prompt_cache_retention", value); }
    }

    /// <summary>
    /// Allows toggling between the reasoning mode and no system prompt. When set
    /// to `reasoning` the system prompt for reasoning models will be used.
    /// </summary>
    public ApiEnum<string, PromptMode>? PromptMode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, PromptMode>>("prompt_mode");
        }
        init { this._rawBodyData.Set("prompt_mode", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("reasoning_effort");
        }
        init { this._rawBodyData.Set("reasoning_effort", value); }
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
    public ResponseFormat? ResponseFormat
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ResponseFormat>("response_format");
        }
        init { this._rawBodyData.Set("response_format", value); }
    }

    /// <summary>
    /// Whether to inject a safety prompt before all conversations.
    /// </summary>
    public bool? SafePrompt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("safe_prompt");
        }
        init { this._rawBodyData.Set("safe_prompt", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("safety_identifier");
        }
        init { this._rawBodyData.Set("safety_identifier", value); }
    }

    /// <summary>
    /// Safety/content filtering settings (Google-specific)
    /// </summary>
    public IReadOnlyList<SafetySetting>? SafetySettings
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<SafetySetting>>(
                "safety_settings"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<SafetySetting>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "search_parameters"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, JsonValueInput?>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("seed");
        }
        init { this._rawBodyData.Set("seed", value); }
    }

    /// <summary>
    /// Service tier for request processing
    /// </summary>
    public string? ServiceTier
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("service_tier");
        }
        init { this._rawBodyData.Set("service_tier", value); }
    }

    /// <summary>
    /// The inference speed mode for this request. `"fast"` enables high output-tokens-per-second inference.
    /// </summary>
    public ApiEnum<string, Speed>? Speed
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Speed>>("speed");
        }
        init { this._rawBodyData.Set("speed", value); }
    }

    /// <summary>
    /// Sequences that stop generation
    /// </summary>
    public Stop? Stop
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Stop>("stop");
        }
        init { this._rawBodyData.Set("stop", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("store");
        }
        init { this._rawBodyData.Set("store", value); }
    }

    /// <summary>
    /// Options for streaming response. Only set this when you set `stream: true`.
    /// </summary>
    public IReadOnlyDictionary<string, JsonValueInput?>? StreamOptions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "stream_options"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "stream_options",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// System instruction/prompt
    /// </summary>
    public SystemInstruction? SystemInstruction
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SystemInstruction>("system_instruction");
        }
        init { this._rawBodyData.Set("system_instruction", value); }
    }

    /// <summary>
    /// Sampling temperature (0-2 for most providers)
    /// </summary>
    public double? Temperature
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("temperature");
        }
        init { this._rawBodyData.Set("temperature", value); }
    }

    /// <summary>
    /// Extended thinking configuration (Anthropic-specific)
    /// </summary>
    public Thinking? Thinking
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Thinking>("thinking");
        }
        init { this._rawBodyData.Set("thinking", value); }
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
    public ToolChoice? ToolChoice
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ToolChoice>("tool_choice");
        }
        init { this._rawBodyData.Set("tool_choice", value); }
    }

    /// <summary>
    /// Tool calling configuration (Google-specific)
    /// </summary>
    public IReadOnlyDictionary<string, JsonValueInput?>? ToolConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "tool_config"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, JsonValueInput?>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ChatCompletionToolParam>>(
                "tools"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ChatCompletionToolParam>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("top_k");
        }
        init { this._rawBodyData.Set("top_k", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("top_logprobs");
        }
        init { this._rawBodyData.Set("top_logprobs", value); }
    }

    /// <summary>
    /// Nucleus sampling threshold
    /// </summary>
    public double? TopP
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("top_p");
        }
        init { this._rawBodyData.Set("top_p", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("user");
        }
        init { this._rawBodyData.Set("user", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("verbosity");
        }
        init { this._rawBodyData.Set("verbosity", value); }
    }

    /// <summary>
    /// This tool searches the web for relevant results to use in a response. Learn
    /// more about the [web search tool](/docs/guides/tools-web-search?api-mode=chat).
    /// </summary>
    public IReadOnlyDictionary<string, JsonValueInput?>? WebSearchOptions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "web_search_options"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "web_search_options",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public CompletionCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CompletionCreateParams(CompletionCreateParams completionCreateParams)
        : base(completionCreateParams)
    {
        this._rawBodyData = new(completionCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CompletionCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompletionCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CompletionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CompletionCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/chat/completions"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Model identifier. Accepts model ID strings, lists for routing, or DedalusModel
/// objects with per-model settings.
/// </summary>
[JsonConverter(typeof(ModelConverter))]
public record class Model : ModelBase
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

    public Model(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Model(DedalusModel value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Model(IReadOnlyList<DedalusModelChoice> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Model(JsonElement element)
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
                throw new DedalusInvalidDataException("Data did not match any variant of Model");
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
            _ => throw new DedalusInvalidDataException("Data did not match any variant of Model"),
        };
    }

    public static implicit operator Model(string value) => new(value);

    public static implicit operator Model(DedalusModel value) => new(value);

    public static implicit operator Model(List<DedalusModelChoice> value) =>
        new((IReadOnlyList<DedalusModelChoice>)value);

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
            throw new DedalusInvalidDataException("Data did not match any variant of Model");
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

    public virtual bool Equals(Model? other) =>
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

sealed class ModelConverter : JsonConverter<Model>
{
    public override Model? Read(
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

    public override void Write(Utf8JsonWriter writer, Model value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Credentials for MCP server authentication. Each credential is matched to servers
/// by connection name.
/// </summary>
[JsonConverter(typeof(CredentialsConverter))]
public record class Credentials : ModelBase
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

    public Credentials(Credential value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Credentials(IReadOnlyList<Credential> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Credentials(JsonElement element)
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
                    "Data did not match any variant of Credentials"
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
                "Data did not match any variant of Credentials"
            ),
        };
    }

    public static implicit operator Credentials(Credential value) => new(value);

    public static implicit operator Credentials(List<Credential> value) =>
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
            throw new DedalusInvalidDataException("Data did not match any variant of Credentials");
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

    public virtual bool Equals(Credentials? other) =>
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

sealed class CredentialsConverter : JsonConverter<Credentials?>
{
    public override Credentials? Read(
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
        Credentials? value,
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
[JsonConverter(typeof(McpServersConverter))]
public record class McpServers : ModelBase
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

    public McpServers(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public McpServers(McpServerSpec value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public McpServers(
        IReadOnlyList<UnnamedSchemaWithArrayParent0> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public McpServers(JsonElement element)
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
                    "Data did not match any variant of McpServers"
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
                "Data did not match any variant of McpServers"
            ),
        };
    }

    public static implicit operator McpServers(string value) => new(value);

    public static implicit operator McpServers(McpServerSpec value) => new(value);

    public static implicit operator McpServers(List<UnnamedSchemaWithArrayParent0> value) =>
        new((IReadOnlyList<UnnamedSchemaWithArrayParent0>)value);

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
            throw new DedalusInvalidDataException("Data did not match any variant of McpServers");
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

    public virtual bool Equals(McpServers? other) =>
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

sealed class McpServersConverter : JsonConverter<McpServers?>
{
    public override McpServers? Read(
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
        McpServers? value,
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
[JsonConverter(typeof(MessageConverter))]
public record class Message : ModelBase
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

    public Message(ChatCompletionDeveloperMessageParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Message(ChatCompletionSystemMessageParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Message(ChatCompletionUserMessageParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Message(ChatCompletionAssistantMessageParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Message(ChatCompletionToolMessageParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Message(ChatCompletionFunctionMessageParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Message(JsonElement element)
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
                throw new DedalusInvalidDataException("Data did not match any variant of Message");
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
            _ => throw new DedalusInvalidDataException("Data did not match any variant of Message"),
        };
    }

    public static implicit operator Message(ChatCompletionDeveloperMessageParam value) =>
        new(value);

    public static implicit operator Message(ChatCompletionSystemMessageParam value) => new(value);

    public static implicit operator Message(ChatCompletionUserMessageParam value) => new(value);

    public static implicit operator Message(ChatCompletionAssistantMessageParam value) =>
        new(value);

    public static implicit operator Message(ChatCompletionToolMessageParam value) => new(value);

    public static implicit operator Message(ChatCompletionFunctionMessageParam value) => new(value);

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
            throw new DedalusInvalidDataException("Data did not match any variant of Message");
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

    public virtual bool Equals(Message? other) =>
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

sealed class MessageConverter : JsonConverter<Message>
{
    public override Message? Read(
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
                return new Message(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Message value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Allows toggling between the reasoning mode and no system prompt. When set to `reasoning`
/// the system prompt for reasoning models will be used.
/// </summary>
[JsonConverter(typeof(PromptModeConverter))]
public enum PromptMode
{
    Reasoning,
}

sealed class PromptModeConverter : JsonConverter<PromptMode>
{
    public override PromptMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "reasoning" => PromptMode.Reasoning,
            _ => (PromptMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromptMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PromptMode.Reasoning => "reasoning",
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
[JsonConverter(typeof(ResponseFormatConverter))]
public record class ResponseFormat : ModelBase
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

    public ResponseFormat(ResponseFormatText value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ResponseFormat(ResponseFormatJsonSchema value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ResponseFormat(ResponseFormatJsonObject value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ResponseFormat(JsonElement element)
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
                    "Data did not match any variant of ResponseFormat"
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
                "Data did not match any variant of ResponseFormat"
            ),
        };
    }

    public static implicit operator ResponseFormat(ResponseFormatText value) => new(value);

    public static implicit operator ResponseFormat(ResponseFormatJsonSchema value) => new(value);

    public static implicit operator ResponseFormat(ResponseFormatJsonObject value) => new(value);

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
                "Data did not match any variant of ResponseFormat"
            );
        }
        this.Switch(
            (text) => text.Validate(),
            (jsonSchema) => jsonSchema.Validate(),
            (jsonObject) => jsonObject.Validate()
        );
    }

    public virtual bool Equals(ResponseFormat? other) =>
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

sealed class ResponseFormatConverter : JsonConverter<ResponseFormat?>
{
    public override ResponseFormat? Read(
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
                return new ResponseFormat(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResponseFormat? value,
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
[JsonConverter(typeof(JsonModelConverter<SafetySetting, SafetySettingFromRaw>))]
public sealed record class SafetySetting : JsonModel
{
    /// <summary>
    /// Required. The category for this setting.
    /// </summary>
    public required ApiEnum<string, Category> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Category>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Required. Controls the probability threshold at which harm is blocked.
    /// </summary>
    public required ApiEnum<string, Threshold> Threshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Threshold>>("threshold");
        }
        init { this._rawData.Set("threshold", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
        this.Threshold.Validate();
    }

    public SafetySetting() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SafetySetting(SafetySetting safetySetting)
        : base(safetySetting) { }
#pragma warning restore CS8618

    public SafetySetting(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SafetySetting(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SafetySettingFromRaw.FromRawUnchecked"/>
    public static SafetySetting FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SafetySettingFromRaw : IFromRawJson<SafetySetting>
{
    /// <inheritdoc/>
    public SafetySetting FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SafetySetting.FromRawUnchecked(rawData);
}

/// <summary>
/// Required. The category for this setting.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
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

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "HARM_CATEGORY_UNSPECIFIED" => Category.HarmCategoryUnspecified,
            "HARM_CATEGORY_DEROGATORY" => Category.HarmCategoryDerogatory,
            "HARM_CATEGORY_TOXICITY" => Category.HarmCategoryToxicity,
            "HARM_CATEGORY_VIOLENCE" => Category.HarmCategoryViolence,
            "HARM_CATEGORY_SEXUAL" => Category.HarmCategorySexual,
            "HARM_CATEGORY_MEDICAL" => Category.HarmCategoryMedical,
            "HARM_CATEGORY_DANGEROUS" => Category.HarmCategoryDangerous,
            "HARM_CATEGORY_HARASSMENT" => Category.HarmCategoryHarassment,
            "HARM_CATEGORY_HATE_SPEECH" => Category.HarmCategoryHateSpeech,
            "HARM_CATEGORY_SEXUALLY_EXPLICIT" => Category.HarmCategorySexuallyExplicit,
            "HARM_CATEGORY_DANGEROUS_CONTENT" => Category.HarmCategoryDangerousContent,
            "HARM_CATEGORY_CIVIC_INTEGRITY" => Category.HarmCategoryCivicIntegrity,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.HarmCategoryUnspecified => "HARM_CATEGORY_UNSPECIFIED",
                Category.HarmCategoryDerogatory => "HARM_CATEGORY_DEROGATORY",
                Category.HarmCategoryToxicity => "HARM_CATEGORY_TOXICITY",
                Category.HarmCategoryViolence => "HARM_CATEGORY_VIOLENCE",
                Category.HarmCategorySexual => "HARM_CATEGORY_SEXUAL",
                Category.HarmCategoryMedical => "HARM_CATEGORY_MEDICAL",
                Category.HarmCategoryDangerous => "HARM_CATEGORY_DANGEROUS",
                Category.HarmCategoryHarassment => "HARM_CATEGORY_HARASSMENT",
                Category.HarmCategoryHateSpeech => "HARM_CATEGORY_HATE_SPEECH",
                Category.HarmCategorySexuallyExplicit => "HARM_CATEGORY_SEXUALLY_EXPLICIT",
                Category.HarmCategoryDangerousContent => "HARM_CATEGORY_DANGEROUS_CONTENT",
                Category.HarmCategoryCivicIntegrity => "HARM_CATEGORY_CIVIC_INTEGRITY",
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
[JsonConverter(typeof(ThresholdConverter))]
public enum Threshold
{
    HarmBlockThresholdUnspecified,
    BlockLowAndAbove,
    BlockMediumAndAbove,
    BlockOnlyHigh,
    BlockNone,
    Off,
}

sealed class ThresholdConverter : JsonConverter<Threshold>
{
    public override Threshold Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "HARM_BLOCK_THRESHOLD_UNSPECIFIED" => Threshold.HarmBlockThresholdUnspecified,
            "BLOCK_LOW_AND_ABOVE" => Threshold.BlockLowAndAbove,
            "BLOCK_MEDIUM_AND_ABOVE" => Threshold.BlockMediumAndAbove,
            "BLOCK_ONLY_HIGH" => Threshold.BlockOnlyHigh,
            "BLOCK_NONE" => Threshold.BlockNone,
            "OFF" => Threshold.Off,
            _ => (Threshold)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Threshold value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Threshold.HarmBlockThresholdUnspecified => "HARM_BLOCK_THRESHOLD_UNSPECIFIED",
                Threshold.BlockLowAndAbove => "BLOCK_LOW_AND_ABOVE",
                Threshold.BlockMediumAndAbove => "BLOCK_MEDIUM_AND_ABOVE",
                Threshold.BlockOnlyHigh => "BLOCK_ONLY_HIGH",
                Threshold.BlockNone => "BLOCK_NONE",
                Threshold.Off => "OFF",
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
[JsonConverter(typeof(SpeedConverter))]
public enum Speed
{
    Standard,
    Fast,
}

sealed class SpeedConverter : JsonConverter<Speed>
{
    public override Speed Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => Speed.Standard,
            "fast" => Speed.Fast,
            _ => (Speed)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Speed value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Speed.Standard => "standard",
                Speed.Fast => "fast",
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

    public Stop(IReadOnlyList<string> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Stop(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Stop(JsonElement element)
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
            _ => throw new DedalusInvalidDataException("Data did not match any variant of Stop"),
        };
    }

    public static implicit operator Stop(List<string> value) => new((IReadOnlyList<string>)value);

    public static implicit operator Stop(string value) => new(value);

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
            IReadOnlyList<string> _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class StopConverter : JsonConverter<Stop?>
{
    public override Stop? Read(
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

    public override void Write(Utf8JsonWriter writer, Stop? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// System instruction/prompt
/// </summary>
[JsonConverter(typeof(SystemInstructionConverter))]
public record class SystemInstruction : ModelBase
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

    public SystemInstruction(
        IReadOnlyDictionary<string, JsonValueInput?> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public SystemInstruction(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SystemInstruction(JsonElement element)
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
                    "Data did not match any variant of SystemInstruction"
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
                "Data did not match any variant of SystemInstruction"
            ),
        };
    }

    public static implicit operator SystemInstruction(Dictionary<string, JsonValueInput?> value) =>
        new((IReadOnlyDictionary<string, JsonValueInput?>)value);

    public static implicit operator SystemInstruction(string value) => new(value);

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
                "Data did not match any variant of SystemInstruction"
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

    public virtual bool Equals(SystemInstruction? other) =>
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

sealed class SystemInstructionConverter : JsonConverter<SystemInstruction?>
{
    public override SystemInstruction? Read(
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
        SystemInstruction? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Extended thinking configuration (Anthropic-specific)
/// </summary>
[JsonConverter(typeof(ThinkingConverter))]
public record class Thinking : ModelBase
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

    public Thinking(ThinkingConfigEnabled value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Thinking(ThinkingConfigDisabled value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Thinking(Adaptive value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Thinking(JsonElement element)
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
    /// type <see cref="Adaptive"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAdaptive(out var value)) {
    ///     // `value` is of type `Adaptive`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAdaptive([NotNullWhen(true)] out Adaptive? value)
    {
        value = this.Value as Adaptive;
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
    ///     (Adaptive value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ThinkingConfigEnabled> configEnabled,
        System::Action<ThinkingConfigDisabled> configDisabled,
        System::Action<Adaptive> adaptive
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
            case Adaptive value:
                adaptive(value);
                break;
            default:
                throw new DedalusInvalidDataException("Data did not match any variant of Thinking");
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
    ///     (Adaptive value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ThinkingConfigEnabled, T> configEnabled,
        System::Func<ThinkingConfigDisabled, T> configDisabled,
        System::Func<Adaptive, T> adaptive
    )
    {
        return this.Value switch
        {
            ThinkingConfigEnabled value => configEnabled(value),
            ThinkingConfigDisabled value => configDisabled(value),
            Adaptive value => adaptive(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of Thinking"
            ),
        };
    }

    public static implicit operator Thinking(ThinkingConfigEnabled value) => new(value);

    public static implicit operator Thinking(ThinkingConfigDisabled value) => new(value);

    public static implicit operator Thinking(Adaptive value) => new(value);

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
            throw new DedalusInvalidDataException("Data did not match any variant of Thinking");
        }
        this.Switch(
            (configEnabled) => configEnabled.Validate(),
            (configDisabled) => configDisabled.Validate(),
            (adaptive) => adaptive.Validate()
        );
    }

    public virtual bool Equals(Thinking? other) =>
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
            Adaptive _ => 2,
            _ => -1,
        };
    }
}

sealed class ThinkingConverter : JsonConverter<Thinking?>
{
    public override Thinking? Read(
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
                    var deserialized = JsonSerializer.Deserialize<Adaptive>(element, options);
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
                return new Thinking(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        Thinking? value,
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
[JsonConverter(typeof(AdaptiveConverter))]
public record class Adaptive
{
    public JsonElement Element { get; private init; }

    public Adaptive()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "adaptive"
            }
            """
        );
    }

    internal Adaptive(JsonElement element)
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
        if (this != new Adaptive())
        {
            throw new DedalusInvalidDataException("Invalid value given for 'Adaptive'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(Adaptive? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class AdaptiveConverter : JsonConverter<Adaptive>
{
    public override Adaptive? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(Utf8JsonWriter writer, Adaptive value, JsonSerializerOptions options)
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
[JsonConverter(typeof(ToolChoiceConverter))]
public record class ToolChoice : ModelBase
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

    public ToolChoice(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolChoice(ToolChoiceAuto value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolChoice(ToolChoiceAny value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolChoice(ToolChoiceTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolChoice(ToolChoiceNone value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolChoice(JsonElement element)
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
                    "Data did not match any variant of ToolChoice"
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
                "Data did not match any variant of ToolChoice"
            ),
        };
    }

    public static implicit operator ToolChoice(string value) => new(value);

    public static implicit operator ToolChoice(ToolChoiceAuto value) => new(value);

    public static implicit operator ToolChoice(ToolChoiceAny value) => new(value);

    public static implicit operator ToolChoice(ToolChoiceTool value) => new(value);

    public static implicit operator ToolChoice(ToolChoiceNone value) => new(value);

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
            throw new DedalusInvalidDataException("Data did not match any variant of ToolChoice");
        }
        this.Switch(
            (_) => { },
            (auto) => auto.Validate(),
            (any) => any.Validate(),
            (tool) => tool.Validate(),
            (none) => none.Validate()
        );
    }

    public virtual bool Equals(ToolChoice? other) =>
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

sealed class ToolChoiceConverter : JsonConverter<ToolChoice?>
{
    public override ToolChoice? Read(
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
        ToolChoice? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
