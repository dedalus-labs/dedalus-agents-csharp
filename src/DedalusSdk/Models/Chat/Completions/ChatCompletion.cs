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
/// Chat completion response for Dedalus API.
///
/// <para>OpenAI-compatible chat completion response with Dedalus extensions. Maintains
/// full compatibility with OpenAI API while providing additional features like server-side
/// tool execution tracking and MCP error reporting.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChatCompletion, ChatCompletionFromRaw>))]
public sealed record class ChatCompletion : JsonModel
{
    /// <summary>
    /// A unique identifier for the chat completion.
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
    /// A list of chat completion choices. Can be more than one if `n` is greater
    /// than 1.
    /// </summary>
    public required IReadOnlyList<Choice> Choices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Choice>>("choices");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Choice>>(
                "choices",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The Unix timestamp (in seconds) of when the chat completion was created.
    /// </summary>
    public required long Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    /// <summary>
    /// The model used for the chat completion.
    /// </summary>
    public required string Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    /// <summary>
    /// The object type, which is always `chat.completion`.
    /// </summary>
    public JsonElement Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("object");
        }
        init { this._rawData.Set("object", value); }
    }

    /// <summary>
    /// Stable session ID for cross-turn handoff state. Echo this on the next request
    /// to resume server-side execution.
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
    /// Server tools blocked on client results.
    /// </summary>
    public IReadOnlyList<DeferredCallResponse>? Deferred
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DeferredCallResponse>>(
                "deferred"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<DeferredCallResponse>?>(
                "deferred",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// MCP server failures keyed by server name.
    /// </summary>
    public IReadOnlyDictionary<string, McpServerErrorsItem>? McpServerErrors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, McpServerErrorsItem>>(
                "mcp_server_errors"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, McpServerErrorsItem>?>(
                "mcp_server_errors",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Detailed results of MCP tool executions including inputs, outputs, and timing.
    /// Provides full visibility into server-side tool execution for debugging and
    /// audit purposes.
    /// </summary>
    public IReadOnlyList<McpToolResult>? McpToolResults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<McpToolResult>>(
                "mcp_tool_results"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<McpToolResult>?>(
                "mcp_tool_results",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Client tools to execute, with dependency ordering.
    /// </summary>
    public IReadOnlyList<PendingTool>? PendingTools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PendingTool>>("pending_tools");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PendingTool>?>(
                "pending_tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Completed server tool outputs keyed by call ID.
    /// </summary>
    public IReadOnlyDictionary<string, JsonValueInput?>? ServerResults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "server_results"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "server_results",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Specifies the processing type used for serving the request.   - If set to
    /// 'auto', then the request will be processed with the service tier configured
    /// in the Project settings. Unless otherwise configured, the Project will use
    /// 'default'.   - If set to 'default', then the request will be processed with
    /// the standard pricing and performance for the selected model.   - If set to
    /// '[flex](/docs/guides/flex-processing)' or '[priority](https://openai.com/api-priority-processing/)',
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ServiceTier>>("service_tier");
        }
        init { this._rawData.Set("service_tier", value); }
    }

    /// <summary>
    /// This fingerprint represents the backend configuration that the model runs with.
    ///
    /// <para>Can be used in conjunction with the `seed` request parameter to understand
    /// when backend changes have been made that might impact determinism.</para>
    /// </summary>
    public string? SystemFingerprint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("system_fingerprint");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("system_fingerprint", value);
        }
    }

    /// <summary>
    /// List of tool names that were executed server-side (e.g., MCP tools). Only
    /// present when tools were executed on the server rather than returned for client-side execution.
    /// </summary>
    public IReadOnlyList<string>? ToolsExecuted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tools_executed");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "tools_executed",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number of internal LLM calls made during this request. SDKs can sum this across
    /// their outer loop to track total LLM calls.
    /// </summary>
    public long? TurnsConsumed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("turns_consumed");
        }
        init { this._rawData.Set("turns_consumed", value); }
    }

    /// <summary>
    /// Usage statistics for the completion request.
    /// </summary>
    public CompletionUsage? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CompletionUsage>("usage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usage", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Choices)
        {
            item.Validate();
        }
        _ = this.Created;
        _ = this.Model;
        if (
            !JsonElement.DeepEquals(
                this.Object,
                JsonSerializer.SerializeToElement("chat.completion")
            )
        )
        {
            throw new DedalusInvalidDataException("Invalid value given for constant");
        }
        _ = this.CorrelationID;
        foreach (var item in this.Deferred ?? [])
        {
            item.Validate();
        }
        if (this.McpServerErrors != null)
        {
            foreach (var item in this.McpServerErrors.Values)
            {
                item.Validate();
            }
        }
        foreach (var item in this.McpToolResults ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.PendingTools ?? [])
        {
            item.Validate();
        }
        if (this.ServerResults != null)
        {
            foreach (var item in this.ServerResults.Values)
            {
                item?.Validate();
            }
        }
        this.ServiceTier?.Validate();
        _ = this.SystemFingerprint;
        _ = this.ToolsExecuted;
        _ = this.TurnsConsumed;
        this.Usage?.Validate();
    }

    public ChatCompletion()
    {
        this.Object = JsonSerializer.SerializeToElement("chat.completion");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCompletion(ChatCompletion chatCompletion)
        : base(chatCompletion) { }
#pragma warning restore CS8618

    public ChatCompletion(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("chat.completion");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCompletion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCompletionFromRaw.FromRawUnchecked"/>
    public static ChatCompletion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatCompletionFromRaw : IFromRawJson<ChatCompletion>
{
    /// <inheritdoc/>
    public ChatCompletion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChatCompletion.FromRawUnchecked(rawData);
}

/// <summary>
/// Error details for a single MCP server failure.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<McpServerErrorsItem, McpServerErrorsItemFromRaw>))]
public sealed record class McpServerErrorsItem : JsonModel
{
    /// <summary>
    /// Human-readable error message.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// Machine-readable error code.
    /// </summary>
    public string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// Suggested action for the user.
    /// </summary>
    public string? Recommendation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("recommendation");
        }
        init { this._rawData.Set("recommendation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Code;
        _ = this.Recommendation;
    }

    public McpServerErrorsItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public McpServerErrorsItem(McpServerErrorsItem mcpServerErrorsItem)
        : base(mcpServerErrorsItem) { }
#pragma warning restore CS8618

    public McpServerErrorsItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    McpServerErrorsItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="McpServerErrorsItemFromRaw.FromRawUnchecked"/>
    public static McpServerErrorsItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public McpServerErrorsItem(string message)
        : this()
    {
        this.Message = message;
    }
}

class McpServerErrorsItemFromRaw : IFromRawJson<McpServerErrorsItem>
{
    /// <inheritdoc/>
    public McpServerErrorsItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        McpServerErrorsItem.FromRawUnchecked(rawData);
}

/// <summary>
/// Client-side tool call the SDK must execute.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PendingTool, PendingToolFromRaw>))]
public sealed record class PendingTool : JsonModel
{
    /// <summary>
    /// Unique identifier for this tool call.
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
    /// Input arguments for the tool call.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonValueInput?> Arguments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonValueInput?>>(
                "arguments"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>>(
                "arguments",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Name of the tool to execute.
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
    /// IDs of other pending calls that must complete first.
    /// </summary>
    public IReadOnlyList<string>? Dependencies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("dependencies");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "dependencies",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Arguments.Values)
        {
            item?.Validate();
        }
        _ = this.Name;
        _ = this.Dependencies;
    }

    public PendingTool() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PendingTool(PendingTool pendingTool)
        : base(pendingTool) { }
#pragma warning restore CS8618

    public PendingTool(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PendingTool(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PendingToolFromRaw.FromRawUnchecked"/>
    public static PendingTool FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PendingToolFromRaw : IFromRawJson<PendingTool>
{
    /// <inheritdoc/>
    public PendingTool FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PendingTool.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the processing type used for serving the request.   - If set to 'auto',
/// then the request will be processed with the service tier configured in the Project
/// settings. Unless otherwise configured, the Project will use 'default'.   - If
/// set to 'default', then the request will be processed with the standard pricing
/// and performance for the selected model.   - If set to '[flex](/docs/guides/flex-processing)'
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
    Flex,
    Scale,
    Priority,
}

sealed class ServiceTierConverter : JsonConverter<ServiceTier>
{
    public override ServiceTier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => ServiceTier.Auto,
            "default" => ServiceTier.Default,
            "flex" => ServiceTier.Flex,
            "scale" => ServiceTier.Scale,
            "priority" => ServiceTier.Priority,
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
                ServiceTier.Flex => "flex",
                ServiceTier.Scale => "scale",
                ServiceTier.Priority => "priority",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
