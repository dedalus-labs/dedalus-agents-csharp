using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models;

/// <summary>
/// Structured MCP server specification.
///
/// <para>Slug-based: {"slug": "dedalus-labs/brave-search", "name": "github-integration",
/// "version": "v1.0.0"} URL-based:  {"url": "https://mcp.dedaluslabs.ai/acme/my-server/mcp",
/// "name": "custom-server"}</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<McpServerSpec, McpServerSpecFromRaw>))]
public sealed record class McpServerSpec : JsonModel
{
    /// <summary>
    /// Server instance name for credential matching.
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
    /// Encrypted credential blobs keyed by connection name. Values are base64url
    /// ciphertext produced by the SDK (client-side encryption with the AS public key).
    /// </summary>
    public IReadOnlyDictionary<string, string>? Credentials
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("credentials");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "credentials",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Marketplace identifier.
    /// </summary>
    public string? Slug
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("slug");
        }
        init { this._rawData.Set("slug", value); }
    }

    /// <summary>
    /// Direct URL to MCP server endpoint (Pro users).
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Version constraint for slug-based servers.
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
        _ = this.Name;
        _ = this.Credentials;
        _ = this.Slug;
        _ = this.Url;
        _ = this.Version;
    }

    public McpServerSpec() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public McpServerSpec(McpServerSpec mcpServerSpec)
        : base(mcpServerSpec) { }
#pragma warning restore CS8618

    public McpServerSpec(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    McpServerSpec(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="McpServerSpecFromRaw.FromRawUnchecked"/>
    public static McpServerSpec FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public McpServerSpec(string name)
        : this()
    {
        this.Name = name;
    }
}

class McpServerSpecFromRaw : IFromRawJson<McpServerSpec>
{
    /// <inheritdoc/>
    public McpServerSpec FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        McpServerSpec.FromRawUnchecked(rawData);
}
