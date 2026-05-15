using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models;

/// <summary>
/// Result of a single MCP tool execution.
///
/// <para>Provides visibility into MCP tool calls including the full input arguments
/// and structured output, enabling debugging and audit trails.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<McpToolResult, McpToolResultFromRaw>))]
public sealed record class McpToolResult : JsonModel
{
    /// <summary>
    /// Input arguments passed to the tool.
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
    /// Whether the tool execution resulted in an error.
    /// </summary>
    public required bool IsError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_error");
        }
        init { this._rawData.Set("is_error", value); }
    }

    /// <summary>
    /// Name of the MCP server that handled the tool.
    /// </summary>
    public required string ServerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("server_name");
        }
        init { this._rawData.Set("server_name", value); }
    }

    /// <summary>
    /// Name of the MCP tool that was executed.
    /// </summary>
    public required string ToolName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tool_name");
        }
        init { this._rawData.Set("tool_name", value); }
    }

    /// <summary>
    /// Execution time in milliseconds.
    /// </summary>
    public long? DurationMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("duration_ms");
        }
        init { this._rawData.Set("duration_ms", value); }
    }

    /// <summary>
    /// Structured result from the tool (parsed from structuredContent or content).
    /// </summary>
    public JsonValueInput? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JsonValueInput>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Arguments.Values)
        {
            item?.Validate();
        }
        _ = this.IsError;
        _ = this.ServerName;
        _ = this.ToolName;
        _ = this.DurationMs;
        this.Result?.Validate();
    }

    public McpToolResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public McpToolResult(McpToolResult mcpToolResult)
        : base(mcpToolResult) { }
#pragma warning restore CS8618

    public McpToolResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    McpToolResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="McpToolResultFromRaw.FromRawUnchecked"/>
    public static McpToolResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class McpToolResultFromRaw : IFromRawJson<McpToolResult>
{
    /// <inheritdoc/>
    public McpToolResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        McpToolResult.FromRawUnchecked(rawData);
}
