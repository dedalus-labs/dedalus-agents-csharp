using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DedalusSdk.Core;

namespace DedalusSdk.Models.Chat.Completions;

/// <summary>
/// Breakdown of tokens used in the prompt.
///
/// <para>Fields: - audio_tokens (optional): int - cached_tokens (optional): int</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PromptTokensDetails, PromptTokensDetailsFromRaw>))]
public sealed record class PromptTokensDetails : JsonModel
{
    /// <summary>
    /// Audio input tokens present in the prompt.
    /// </summary>
    public long? AudioTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("audio_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audio_tokens", value);
        }
    }

    /// <summary>
    /// Cached tokens present in the prompt.
    /// </summary>
    public long? CachedTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("cached_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cached_tokens", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AudioTokens;
        _ = this.CachedTokens;
    }

    public PromptTokensDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PromptTokensDetails(PromptTokensDetails promptTokensDetails)
        : base(promptTokensDetails) { }
#pragma warning restore CS8618

    public PromptTokensDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PromptTokensDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PromptTokensDetailsFromRaw.FromRawUnchecked"/>
    public static PromptTokensDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PromptTokensDetailsFromRaw : IFromRawJson<PromptTokensDetails>
{
    /// <inheritdoc/>
    public PromptTokensDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PromptTokensDetails.FromRawUnchecked(rawData);
}
