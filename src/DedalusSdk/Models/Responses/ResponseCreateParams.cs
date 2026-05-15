using System;
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

namespace DedalusSdk.Models.Responses;

/// <summary>
/// Create a response using the OpenAI Responses API.
///
/// <para>This endpoint routes directly to OpenAI's Responses API. Only OpenAI models
/// are supported.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ResponseCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Whether to run the model response in the background. [Learn more](https://platform.openai.com/docs/guides/background).
    /// </summary>
    public bool? Background
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("background");
        }
        init { this._rawBodyData.Set("background", value); }
    }

    /// <summary>
    /// Conversation that this response belongs to. Items from this conversation
    /// are prepended to the input items, and output items from this response are
    /// automatically added after completion.
    /// </summary>
    public Conversation? Conversation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Conversation>("conversation");
        }
        init { this._rawBodyData.Set("conversation", value); }
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
    /// Penalizes new tokens based on their frequency in the text so far.
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
    /// Specify additional output data to include in the model response. Currently
    /// supported values are: - `web_search_call.action.sources`: Include the sources
    /// of the web search tool call. - `code_interpreter_call.outputs`: Includes
    /// the outputs of python code execution   in code interpreter tool call items.
    /// - `computer_call_output.output.image_url`: Include image urls from the computer
    /// call output. - `file_search_call.results`: Include the search results of
    ///  the file search tool call. - `message.input_image.image_url`: Include image
    /// urls from the input message. - `message.output_text.logprobs`: Include logprobs
    /// with assistant messages. - `reasoning.encrypted_content`: Includes an encrypted
    /// version of reasoning   tokens in reasoning item outputs. This enables reasoning
    /// items to be used in   multi-turn conversations when using the Responses API
    /// statelessly (like   when the `store` parameter is set to `false`, or when
    /// an organization is   enrolled in the zero data retention program).
    /// </summary>
    public IReadOnlyList<string>? Include
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("include");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "include",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Text, image, or file inputs to the model, used to generate a response.
    ///
    /// <para>Learn more: - [Text inputs and outputs](https://platform.openai.com/docs/guides/text)
    /// - [Image inputs](https://platform.openai.com/docs/guides/images) - [File
    /// inputs](https://platform.openai.com/docs/guides/pdf-files) - [Conversation
    /// state](https://platform.openai.com/docs/guides/conversation-state) - [Function calling](https://platform.openai.com/docs/guides/function-calling)</para>
    /// </summary>
    public Input? Input
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Input>("input");
        }
        init { this._rawBodyData.Set("input", value); }
    }

    /// <summary>
    /// A system (or developer) message inserted into the model's context.
    ///
    /// <para>When using along with `previous_response_id`, the instructions from
    /// a previous response will not be carried over to the next response. This makes
    /// it simple to swap out system (or developer) messages in new responses.</para>
    /// </summary>
    public Instructions? Instructions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Instructions>("instructions");
        }
        init { this._rawBodyData.Set("instructions", value); }
    }

    /// <summary>
    /// An upper bound for the number of tokens that can be generated for a response,
    /// including visible output tokens and [reasoning tokens](https://platform.openai.com/docs/guides/reasoning).
    /// </summary>
    public long? MaxOutputTokens
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("max_output_tokens");
        }
        init { this._rawBodyData.Set("max_output_tokens", value); }
    }

    /// <summary>
    /// The maximum number of total calls to built-in tools that can be processed
    /// in a response. This maximum number applies across all built-in tool calls,
    /// not per individual tool. Any further attempts to call a tool by the model
    /// will be ignored.
    /// </summary>
    public long? MaxToolCalls
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("max_tool_calls");
        }
        init { this._rawBodyData.Set("max_tool_calls", value); }
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
    /// Set of up to 16 key-value string pairs that can be attached to the response
    /// for structured metadata and later querying via the API or dashboard.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Model ID used to generate the response, like `gpt-4o` or `o3`. OpenAI offers
    /// a wide range of models with different capabilities, performance characteristics,
    /// and price points. Refer to the [model guide](https://platform.openai.com/docs/models)
    /// to browse and compare available models.
    /// </summary>
    public Model? Model
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Model>("model");
        }
        init { this._rawBodyData.Set("model", value); }
    }

    /// <summary>
    /// Whether to allow the model to run tool calls in parallel.
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
    /// Penalizes new tokens based on whether they appear in the text so far.
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
    /// Unique ID of the previous response to continue from when creating multi-turn
    /// conversations. Cannot be used together with `conversation`.
    /// </summary>
    public string? PreviousResponseID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("previous_response_id");
        }
        init { this._rawBodyData.Set("previous_response_id", value); }
    }

    /// <summary>
    /// Stored prompt template reference (BYOK).
    /// </summary>
    public Prompt? Prompt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Prompt>("prompt");
        }
        init { this._rawBodyData.Set("prompt", value); }
    }

    /// <summary>
    /// Used by OpenAI to cache responses for similar requests to optimize your cache
    /// hit rates. Replaces the `user` field. [Learn more](https://platform.openai.com/docs/guides/prompt-caching).
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
    /// **gpt-5 and o-series models only**
    ///
    /// <para>Configuration options for [reasoning models](https://platform.openai.com/docs/guides/reasoning).</para>
    /// </summary>
    public IReadOnlyDictionary<string, JsonValueInput?>? Reasoning
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "reasoning"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "reasoning",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A stable identifier used to help detect users of your application that may
    /// be violating OpenAI's usage policies. The IDs should be a string that uniquely
    /// identifies each user. We recommend hashing their username or email address,
    /// in order to avoid sending us any identifying information. [Learn more](https://platform.openai.com/docs/guides/safety-best-practices#safety-identifiers).
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
    /// Specifies the processing type used for serving the request.   - If set to
    /// 'auto', then the request will be processed with the service tier configured
    /// in the Project settings. Unless otherwise configured, the Project will use
    /// 'default'.   - If set to 'default', then the request will be processed with
    /// the standard pricing and performance for the selected model.   - If set to
    /// '[flex](https://platform.openai.com/docs/guides/flex-processing)' or '[priority](https://openai.com/api-priority-processing/)',
    /// then the request will be processed with the corresponding service tier.
    ///  - When not set, the default behavior is 'auto'.
    ///
    /// <para>  When the `service_tier` parameter is set, the response body will
    /// include the `service_tier` value based on the processing mode actually used
    /// to serve the request. This response value may be different from the value
    /// set in the parameter.</para>
    /// </summary>
    public ApiEnum<string, ServiceTier>? ServiceTier
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ServiceTier>>("service_tier");
        }
        init { this._rawBodyData.Set("service_tier", value); }
    }

    /// <summary>
    /// Whether to store the generated response for later retrieval via the Responses API.
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
    /// If set to true, the model response data will be streamed to the client as
    /// it is generated using [server-sent events](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events#Event_stream_format).
    /// See the [Streaming section below](https://platform.openai.com/docs/api-reference/responses-streaming)
    /// for more information.
    /// </summary>
    public bool? Stream
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("stream");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("stream", value);
        }
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
    /// What sampling temperature to use, between 0 and 2. Higher values like 0.8
    /// will make the output more random, while lower values like 0.2 will make it
    /// more focused and deterministic. We generally recommend altering this or `top_p`
    /// but not both.
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
    /// Configuration options for a text response from the model. Can be plain text
    /// or structured JSON data. Learn more: - [Text inputs and outputs](https://platform.openai.com/docs/guides/text)
    /// - [Structured Outputs](https://platform.openai.com/docs/guides/structured-outputs)
    /// </summary>
    public IReadOnlyDictionary<string, JsonValueInput?>? Text
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "text"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "text",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// How the model should select which tool (or tools) to use when generating a
    /// response. See the `tools` parameter to see how to specify which tools the
    /// model can call.
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
    /// An array of tools the model may call while generating a response. You can
    /// specify which tool to use by setting the `tool_choice` parameter.
    ///
    /// <para>We support the following categories of tools: - **Built-in tools**:
    /// Tools that are provided by OpenAI that extend the   model's capabilities,
    /// like [web search](https://platform.openai.com/docs/guides/tools-web-search)
    ///   or [file search](https://platform.openai.com/docs/guides/tools-file-search).
    /// Learn more about   [built-in tools](https://platform.openai.com/docs/guides/tools).
    /// - **MCP Tools**: Integrations with third-party systems via custom MCP servers
    ///   or predefined connectors such as Google Drive and SharePoint. Learn more
    /// about   [MCP Tools](https://platform.openai.com/docs/guides/tools-connectors-mcp).
    /// - **Function calls (custom tools)**: Functions that are defined by you,
    ///  enabling the model to call your own code with strongly typed arguments
    ///  and outputs. Learn more about   [function calling](https://platform.openai.com/docs/guides/function-calling).
    /// You can also use   custom tools to call your own code.</para>
    /// </summary>
    public IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>>? Tools
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<FrozenDictionary<string, JsonValueInput?>>
            >("tools");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<FrozenDictionary<string, JsonValueInput?>>?>(
                "tools",
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
    /// An integer between 0 and 20 specifying the number of most likely tokens to
    /// return at each token position, each with an associated log probability.
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
    /// An alternative to sampling with temperature, called nucleus sampling, where
    /// the model considers the results of the tokens with top_p probability mass.
    /// So 0.1 means only the tokens comprising the top 10% probability mass are considered.
    ///
    /// <para>We generally recommend altering this or `temperature` but not both.</para>
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
    /// The truncation strategy to use for the model response. - `auto`: If the input
    /// to this Response exceeds   the model's context window size, the model will
    /// truncate the   response to fit the context window by dropping items from
    /// the beginning of the conversation. - `disabled` (default): If the input size
    /// will exceed the context window   size for a model, the request will fail with
    /// a 400 error.
    /// </summary>
    public ApiEnum<string, Truncation>? Truncation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Truncation>>("truncation");
        }
        init { this._rawBodyData.Set("truncation", value); }
    }

    /// <summary>
    /// This field is being replaced by `safety_identifier` and `prompt_cache_key`.
    /// Use `prompt_cache_key` instead to maintain caching optimizations. A stable
    /// identifier for your end-users. Used to boost cache hit rates by better bucketing
    /// similar requests and  to help OpenAI detect and prevent abuse. [Learn more](https://platform.openai.com/docs/guides/safety-best-practices#safety-identifiers).
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

    public ResponseCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResponseCreateParams(ResponseCreateParams responseCreateParams)
        : base(responseCreateParams)
    {
        this._rawBodyData = new(responseCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ResponseCreateParams(
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
    ResponseCreateParams(
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
    public static ResponseCreateParams FromRawUnchecked(
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

    public virtual bool Equals(ResponseCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/responses")
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
/// Conversation that this response belongs to. Items from this conversation are prepended
/// to the input items, and output items from this response are automatically added
/// after completion.
/// </summary>
[JsonConverter(typeof(ConversationConverter))]
public record class Conversation : ModelBase
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

    public Conversation(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Conversation(ResponseConversationParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Conversation(JsonElement element)
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
    /// type <see cref="ResponseConversationParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickResponseConversationParam(out var value)) {
    ///     // `value` is of type `ResponseConversationParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickResponseConversationParam(
        [NotNullWhen(true)] out ResponseConversationParam? value
    )
    {
        value = this.Value as ResponseConversationParam;
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
    ///     (ResponseConversationParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<ResponseConversationParam> responseConversationParam
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case ResponseConversationParam value:
                responseConversationParam(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of Conversation"
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
    ///     (ResponseConversationParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<ResponseConversationParam, T> responseConversationParam
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            ResponseConversationParam value => responseConversationParam(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of Conversation"
            ),
        };
    }

    public static implicit operator Conversation(string value) => new(value);

    public static implicit operator Conversation(ResponseConversationParam value) => new(value);

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
            throw new DedalusInvalidDataException("Data did not match any variant of Conversation");
        }
        this.Switch(
            (_) => { },
            (responseConversationParam) => responseConversationParam.Validate()
        );
    }

    public virtual bool Equals(Conversation? other) =>
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
            ResponseConversationParam _ => 1,
            _ => -1,
        };
    }
}

sealed class ConversationConverter : JsonConverter<Conversation?>
{
    public override Conversation? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ResponseConversationParam>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
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
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        Conversation? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Conversation reference for continuing a Responses session.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ResponseConversationParam, ResponseConversationParamFromRaw>)
)]
public sealed record class ResponseConversationParam : JsonModel
{
    /// <summary>
    /// Identifier of the existing conversation.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public ResponseConversationParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResponseConversationParam(ResponseConversationParam responseConversationParam)
        : base(responseConversationParam) { }
#pragma warning restore CS8618

    public ResponseConversationParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResponseConversationParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResponseConversationParamFromRaw.FromRawUnchecked"/>
    public static ResponseConversationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ResponseConversationParam(string id)
        : this()
    {
        this.ID = id;
    }
}

class ResponseConversationParamFromRaw : IFromRawJson<ResponseConversationParam>
{
    /// <inheritdoc/>
    public ResponseConversationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ResponseConversationParam.FromRawUnchecked(rawData);
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
        Action<Credential> credential,
        Action<IReadOnlyList<Credential>> mcpCredentials
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
        Func<Credential, T> credential,
        Func<IReadOnlyList<Credential>, T> mcpCredentials
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
        Type typeToConvert,
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
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
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
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
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
/// Text, image, or file inputs to the model, used to generate a response.
///
/// <para>Learn more: - [Text inputs and outputs](https://platform.openai.com/docs/guides/text)
/// - [Image inputs](https://platform.openai.com/docs/guides/images) - [File inputs](https://platform.openai.com/docs/guides/pdf-files)
/// - [Conversation state](https://platform.openai.com/docs/guides/conversation-state)
/// - [Function calling](https://platform.openai.com/docs/guides/function-calling)</para>
/// </summary>
[JsonConverter(typeof(InputConverter))]
public record class Input : ModelBase
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

    public Input(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(
        IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(
            Enumerable.Select(value, (item) => FrozenDictionary.ToFrozenDictionary(item))
        );
        this._element = element;
    }

    public Input(JsonElement element)
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
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>Dictionary&lt;string, JsonValueInput?&gt;</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonValueInputs(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;IReadOnlyDictionary&lt;string, JsonValueInput?&gt;&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonValueInputs(
        [NotNullWhen(true)] out IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>>? value
    )
    {
        value = this.Value as IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>>;
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
    ///     (IReadOnlyList&lt;IReadOnlyDictionary&lt;string, JsonValueInput?&gt;&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>>> jsonValueInputs
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>> value:
                jsonValueInputs(value);
                break;
            default:
                throw new DedalusInvalidDataException("Data did not match any variant of Input");
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
    ///     (IReadOnlyList&lt;IReadOnlyDictionary&lt;string, JsonValueInput?&gt;&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>>, T> jsonValueInputs
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>> value => jsonValueInputs(
                value
            ),
            _ => throw new DedalusInvalidDataException("Data did not match any variant of Input"),
        };
    }

    public static implicit operator Input(string value) => new(value);

    public static implicit operator Input(List<Dictionary<string, JsonValueInput?>> value) =>
        new((IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>>)value);

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
            throw new DedalusInvalidDataException("Data did not match any variant of Input");
        }
        this.Switch(
            (_) => { },
            (jsonValueInputs) =>
            {
                foreach (var item in jsonValueInputs)
                {
                    foreach (var item1 in item.Values)
                    {
                        item1?.Validate();
                    }
                }
            }
        );
    }

    public virtual bool Equals(Input? other) =>
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
            IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>> _ => 1,
            _ => -1,
        };
    }
}

sealed class InputConverter : JsonConverter<Input?>
{
    public override Input? Read(
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
            var deserialized = JsonSerializer.Deserialize<
                List<Dictionary<string, JsonValueInput?>>
            >(element, options);
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    foreach (var item1 in item.Values)
                    {
                        item1?.Validate();
                    }
                }
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Input? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// A system (or developer) message inserted into the model's context.
///
/// <para>When using along with `previous_response_id`, the instructions from a previous
/// response will not be carried over to the next response. This makes it simple
/// to swap out system (or developer) messages in new responses.</para>
/// </summary>
[JsonConverter(typeof(InstructionsConverter))]
public record class Instructions : ModelBase
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

    public Instructions(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Instructions(
        IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(
            Enumerable.Select(value, (item) => FrozenDictionary.ToFrozenDictionary(item))
        );
        this._element = element;
    }

    public Instructions(JsonElement element)
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
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>Dictionary&lt;string, JsonValueInput?&gt;</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonValueInputs(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;IReadOnlyDictionary&lt;string, JsonValueInput?&gt;&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonValueInputs(
        [NotNullWhen(true)] out IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>>? value
    )
    {
        value = this.Value as IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>>;
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
    ///     (IReadOnlyList&lt;IReadOnlyDictionary&lt;string, JsonValueInput?&gt;&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>>> jsonValueInputs
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>> value:
                jsonValueInputs(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of Instructions"
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
    ///     (IReadOnlyList&lt;IReadOnlyDictionary&lt;string, JsonValueInput?&gt;&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>>, T> jsonValueInputs
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>> value => jsonValueInputs(
                value
            ),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of Instructions"
            ),
        };
    }

    public static implicit operator Instructions(string value) => new(value);

    public static implicit operator Instructions(List<Dictionary<string, JsonValueInput?>> value) =>
        new((IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>>)value);

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
            throw new DedalusInvalidDataException("Data did not match any variant of Instructions");
        }
        this.Switch(
            (_) => { },
            (jsonValueInputs) =>
            {
                foreach (var item in jsonValueInputs)
                {
                    foreach (var item1 in item.Values)
                    {
                        item1?.Validate();
                    }
                }
            }
        );
    }

    public virtual bool Equals(Instructions? other) =>
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
            IReadOnlyList<IReadOnlyDictionary<string, JsonValueInput?>> _ => 1,
            _ => -1,
        };
    }
}

sealed class InstructionsConverter : JsonConverter<Instructions?>
{
    public override Instructions? Read(
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
            var deserialized = JsonSerializer.Deserialize<
                List<Dictionary<string, JsonValueInput?>>
            >(element, options);
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    foreach (var item1 in item.Values)
                    {
                        item1?.Validate();
                    }
                }
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        Instructions? value,
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
        Action<string> @string,
        Action<McpServerSpec> serverSpec,
        Action<IReadOnlyList<UnnamedSchemaWithArrayParent0>> mcpServers
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
        Func<string, T> @string,
        Func<McpServerSpec, T> serverSpec,
        Func<IReadOnlyList<UnnamedSchemaWithArrayParent0>, T> mcpServers
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
        Type typeToConvert,
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
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
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
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
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
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
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
/// Model ID used to generate the response, like `gpt-4o` or `o3`. OpenAI offers a
/// wide range of models with different capabilities, performance characteristics,
/// and price points. Refer to the [model guide](https://platform.openai.com/docs/models)
/// to browse and compare available models.
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
    /// if (instance.TryPickModels(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;DedalusModelChoice&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickModels([NotNullWhen(true)] out IReadOnlyList<DedalusModelChoice>? value)
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
        Action<string> @modelID,
        Action<DedalusModel> dedalus,
        Action<IReadOnlyList<DedalusModelChoice>> models
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
                models(value);
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
        Func<string, T> @modelID,
        Func<DedalusModel, T> dedalus,
        Func<IReadOnlyList<DedalusModelChoice>, T> models
    )
    {
        return this.Value switch
        {
            string value => @modelID(value),
            DedalusModel value => dedalus(value),
            IReadOnlyList<DedalusModelChoice> value => models(value),
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
            (models) =>
            {
                foreach (var item in models)
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

sealed class ModelConverter : JsonConverter<Model?>
{
    public override Model? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
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
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
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
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Model? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Stored prompt template reference (BYOK).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Prompt, PromptFromRaw>))]
public sealed record class Prompt : JsonModel
{
    /// <summary>
    /// Identifier of the stored prompt.
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
    /// Variables to substitute into the stored prompt template.
    /// </summary>
    public IReadOnlyDictionary<string, JsonValueInput?>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "variables"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "variables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Optional version identifier of the stored prompt.
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
        if (this.Variables != null)
        {
            foreach (var item in this.Variables.Values)
            {
                item?.Validate();
            }
        }
        _ = this.Version;
    }

    public Prompt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Prompt(Prompt prompt)
        : base(prompt) { }
#pragma warning restore CS8618

    public Prompt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Prompt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PromptFromRaw.FromRawUnchecked"/>
    public static Prompt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Prompt(string id)
        : this()
    {
        this.ID = id;
    }
}

class PromptFromRaw : IFromRawJson<Prompt>
{
    /// <inheritdoc/>
    public Prompt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Prompt.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the processing type used for serving the request.   - If set to 'auto',
/// then the request will be processed with the service tier configured in the Project
/// settings. Unless otherwise configured, the Project will use 'default'.   - If
/// set to 'default', then the request will be processed with the standard pricing
/// and performance for the selected model.   - If set to '[flex](https://platform.openai.com/docs/guides/flex-processing)'
/// or '[priority](https://openai.com/api-priority-processing/)', then the request
/// will be processed with the corresponding service tier.   - When not set, the default
/// behavior is 'auto'.
///
/// <para>  When the `service_tier` parameter is set, the response body will include
/// the `service_tier` value based on the processing mode actually used to serve the
/// request. This response value may be different from the value set in the parameter.</para>
/// </summary>
[JsonConverter(typeof(ServiceTierConverter))]
public enum ServiceTier
{
    Auto,
    Default,
}

sealed class ServiceTierConverter : JsonConverter<ServiceTier>
{
    public override ServiceTier Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => ServiceTier.Auto,
            "default" => ServiceTier.Default,
            _ => (ServiceTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ServiceTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ServiceTier.Auto => "auto",
                ServiceTier.Default => "default",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// How the model should select which tool (or tools) to use when generating a response.
/// See the `tools` parameter to see how to specify which tools the model can call.
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

    public ToolChoice(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolChoice(
        IReadOnlyDictionary<string, JsonValueInput?> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
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
    ///     (IReadOnlyDictionary&lt;string, JsonValueInput?&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<IReadOnlyDictionary<string, JsonValueInput?>> jsonObjectInput
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyDictionary<string, JsonValueInput?> value:
                jsonObjectInput(value);
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
    ///     (IReadOnlyDictionary&lt;string, JsonValueInput?&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<IReadOnlyDictionary<string, JsonValueInput?>, T> jsonObjectInput
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyDictionary<string, JsonValueInput?> value => jsonObjectInput(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of ToolChoice"
            ),
        };
    }

    public static implicit operator ToolChoice(string value) => new(value);

    public static implicit operator ToolChoice(Dictionary<string, JsonValueInput?> value) =>
        new((IReadOnlyDictionary<string, JsonValueInput?>)value);

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
            (jsonObjectInput) =>
            {
                foreach (var item in jsonObjectInput.Values)
                {
                    item?.Validate();
                }
            }
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
            IReadOnlyDictionary<string, JsonValueInput?> _ => 1,
            _ => -1,
        };
    }
}

sealed class ToolChoiceConverter : JsonConverter<ToolChoice?>
{
    public override ToolChoice? Read(
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
        catch (Exception e) when (e is JsonException || e is DedalusInvalidDataException)
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

/// <summary>
/// The truncation strategy to use for the model response. - `auto`: If the input
/// to this Response exceeds   the model's context window size, the model will truncate
/// the   response to fit the context window by dropping items from the beginning
/// of the conversation. - `disabled` (default): If the input size will exceed the
/// context window   size for a model, the request will fail with a 400 error.
/// </summary>
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
