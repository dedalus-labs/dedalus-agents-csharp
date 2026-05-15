using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models.Chat.Completions;

/// <summary>
/// Server-side call blocked until pending client calls complete.
///
/// <para>Carries full spec for stateless resumption on subsequent turns.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DeferredCallResponse, DeferredCallResponseFromRaw>))]
public sealed record class DeferredCallResponse : JsonModel
{
    /// <summary>
    /// Unique identifier for this deferred call.
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
    /// Name of the tool.
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
    /// Input arguments for the tool call.
    /// </summary>
    public IReadOnlyDictionary<string, JsonValueInput?>? Arguments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonValueInput?>>(
                "arguments"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonValueInput?>?>(
                "arguments",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// IDs of pending client calls blocking this call.
    /// </summary>
    public IReadOnlyList<string>? BlockedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("blocked_by");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "blocked_by",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// IDs of calls this depends on.
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

    /// <summary>
    /// Execution venue (server or client).
    /// </summary>
    public string? Venue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("venue");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("venue", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        if (this.Arguments != null)
        {
            foreach (var item in this.Arguments.Values)
            {
                item?.Validate();
            }
        }
        _ = this.BlockedBy;
        _ = this.Dependencies;
        _ = this.Venue;
    }

    public DeferredCallResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeferredCallResponse(DeferredCallResponse deferredCallResponse)
        : base(deferredCallResponse) { }
#pragma warning restore CS8618

    public DeferredCallResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeferredCallResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeferredCallResponseFromRaw.FromRawUnchecked"/>
    public static DeferredCallResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeferredCallResponseFromRaw : IFromRawJson<DeferredCallResponse>
{
    /// <inheritdoc/>
    public DeferredCallResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DeferredCallResponse.FromRawUnchecked(rawData);
}
